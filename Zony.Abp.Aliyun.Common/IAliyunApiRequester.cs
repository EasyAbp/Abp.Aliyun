using System.Threading.Tasks;
using Zony.Abp.Aliyun.Common.Model;

namespace Zony.Abp.Aliyun.Common
{
    /// <summary>
    /// 对阿里云 API 进行请求的 请求者 接口定义。
    /// </summary>
    public interface IAliyunApiRequester
    {
        /// <summary>
        /// 发起一个新的命令/查询请求，需要手动指定目标 URL。
        /// </summary>
        /// <param name="request">要发起的请求实例。</param>
        /// <param name="url">目标 API 的路径。</param>
        /// <typeparam name="TResponse">
        /// 请求的返回值类型，框架会自动将数据反序列化为指定的类型。
        /// </typeparam>
        /// <returns>请求的返回值数据。</returns>
        Task<TResponse> SendRequestAsync<TResponse>(ICommonRequest request,string url) where TResponse : ICommonResponse;
    }
}