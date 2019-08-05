using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Volo.Abp.Aliyun.Common.Configurations;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Volo.Abp.Aliyun.Common
{
    public class DefaultAliyunApiRequester : IAliyunApiRequester,ITransientDependency
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AbpAliyunOptions _abpAliyunOptions;
        private readonly IGuidGenerator _guidGenerator;

        public DefaultAliyunApiRequester(IHttpClientFactory httpClientFactory,
            IOptions<AbpAliyunOptions> options,
            IGuidGenerator guidGenerator)
        {
            _httpClientFactory = httpClientFactory;
            _guidGenerator = guidGenerator;
            _abpAliyunOptions = options.Value;
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(ICommonRequest request, string url) where TResponse : ICommonResponse
        {
            request.SetCommonParameters(_abpAliyunOptions.AccessKeyId, _guidGenerator.Create());
            request.SetSignature(_abpAliyunOptions.AccessKeySecret);

            if (!request.IsReady()) throw new ArgumentException("API 请求参数没有正确设置。");

            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = request.Method == HttpMethod.Get ? 
                BuildHttpGet(request,url) : 
                BuildHttpPost(request,url);
            
            var result = await client.SendAsync(httpRequestMessage);

            return JsonConvert.DeserializeObject<TResponse>(await result.Content.ReadAsStringAsync());
        }

        private HttpRequestMessage BuildHttpGet(ICommonRequest request,string url)
        {
            var requestUrl = $"{url}?{request.GetQueryString()}";
            return new HttpRequestMessage(HttpMethod.Get, requestUrl);
        }

        private HttpRequestMessage BuildHttpPost(ICommonRequest request,string url)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(request.GetPostString())
            };

            return httpRequest;
        }
    }
}