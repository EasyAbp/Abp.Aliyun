using System;
using System.Collections.Generic;

namespace Volo.Abp.Aliyun.Common
{
    public interface ICommonRequest
    {
        /// <summary>
        /// 通过 <see cref="ICommonRequest"/> 构建的参数字典。
        /// </summary>
        SortedDictionary<string,string> RequestParameters { get; }

        /// <summary>
        /// 设置公共参数，开发人员不需要主动调用本方法。
        /// </summary>
        ICommonRequest SetCommonParameters(string accessKeyId, Guid signNonce);

        /// <summary>
        /// 计算签名参数，开发人员不需要主动调用本方法。
        /// </summary>
        ICommonRequest SetSignature();

        /// <summary>
        /// 根据 <see cref="RequestParameters"/> 字典生成 HTTP 请求的 GET 查询串。
        /// </summary>
        string GetQueryString();

        /// <summary>
        /// 用于标识请求参数体是否准备好。
        /// </summary>
        bool IsReady();
    }
}