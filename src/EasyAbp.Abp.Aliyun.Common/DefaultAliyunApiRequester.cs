using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using EasyAbp.Abp.Aliyun.Common.Configurations;
using EasyAbp.Abp.Aliyun.Common.Model;
using Volo.Abp.Json;

namespace EasyAbp.Abp.Aliyun.Common
{
    public class DefaultAliyunApiRequester : IAliyunApiRequester, ITransientDependency
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AbpAliyunOptions _abpAliyunOptions;
        private readonly IGuidGenerator _guidGenerator;

        public DefaultAliyunApiRequester(
            IJsonSerializer jsonSerializer,
            IHttpClientFactory httpClientFactory,
            IOptions<AbpAliyunOptions> options,
            IGuidGenerator guidGenerator)
        {
            _jsonSerializer = jsonSerializer;
            _httpClientFactory = httpClientFactory;
            _guidGenerator = guidGenerator;
            _abpAliyunOptions = options.Value;
        }

        /// <summary>
        /// 发起一个新的命令/查询请求，需要手动指定目标 URL。
        /// </summary>
        /// <param name="request">要发起的请求实例。</param>
        /// <param name="url">目标 API 的路径。</param>
        /// <typeparam name="TResponse">
        /// 请求的返回值类型，框架会自动将数据反序列化为指定的类型。
        /// </typeparam>
        /// <returns>请求的返回值数据。</returns>
        public async Task<TResponse> SendRequestAsync<TResponse>(ICommonRequest request, string url)
            where TResponse : ICommonResponse
        {
            request.SetCommonParameters(_abpAliyunOptions.AccessKeyId, _guidGenerator.Create());
            request.SetSignature(_abpAliyunOptions.AccessKeySecret);

            if (!request.IsReady()) throw new ArgumentException("API 请求参数没有正确设置。");

            var client = _httpClientFactory.CreateClient();

            // 根据 HTTP 请求方法值，构造不同的参数值。
            var httpRequestMessage = request.Method == HttpMethod.Get
                ? BuildHttpGet(request, url)
                : BuildHttpPost(request, url);

            var result = await client.SendAsync(httpRequestMessage);

            return _jsonSerializer.Deserialize<TResponse>(await result.Content.ReadAsStringAsync());
        }

        private HttpRequestMessage BuildHttpGet(ICommonRequest request, string url)
        {
            var requestUrl = $"{url}?{request.GetQueryString()}";
            return new HttpRequestMessage(HttpMethod.Get, requestUrl);
        }

        private HttpRequestMessage BuildHttpPost(ICommonRequest request, string url)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(ToPostString(request))
            };

            return httpRequest;
        }

        /// <summary>
        /// 根据 <see cref="ICommonRequest.RequestParameters" /> 字典生成 HTTP 请求的 POST 查询参数。
        /// </summary>
        public virtual string ToPostString(ICommonRequest request)
        {
            return _jsonSerializer.Serialize(request.RequestParameters);
        }
    }
}