using System.Threading.Tasks;

namespace Volo.Abp.Aliyun.Common
{
    /// <summary>
    /// 对阿里云 API 进行请求的 请求者 接口定义。
    /// </summary>
    public interface IAliyunApiRequester
    {
        /// <summary>
        /// 发起一个新的命令/查询请求，需要手动指定目标 URL。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="url"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        Task<TResponse> SendRequestAsync<TResponse>(ICommonRequest request,string url) where TResponse : ICommonResponse;
    }
}