using System.Threading.Tasks;

namespace Volo.Abp.Aliyun.Common
{
    public interface IAliyunApiRequester
    {
        Task<TResponse> SendRequestAsync<TResponse>(ICommonRequest request,string url) where TResponse : ICommonResponse;
    }
}