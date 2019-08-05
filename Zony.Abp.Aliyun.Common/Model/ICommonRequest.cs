using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Zony.Abp.Aliyun.Common.Model
{
    public interface ICommonRequest
    {
        /// <summary>
        /// 通过 <see cref="ICommonRequest"/> 构建的参数字典。
        /// </summary>
        SortedDictionary<string,string> RequestParameters { get; }
        
        /// <summary>
        /// 请求的 Http 请求方式，参考 <see cref="HttpMethod"/> 定义的数据。
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// 设置公共参数，开发人员不需要主动调用本方法。
        /// </summary>
        ICommonRequest SetCommonParameters(string accessKeyId, Guid signNonce);

        /// <summary>
        /// 计算签名参数，开发人员不需要主动调用本方法。
        /// </summary>
        ICommonRequest SetSignature(string accessKey);

        /// <summary>
        /// 根据 <see cref="RequestParameters"/> 字典生成 HTTP 请求的 GET 查询参数。
        /// </summary>
        string GetQueryString();

        /// <summary>
        /// 根据 <see cref="RequestParameters"/> 字典生成 HTTP 请求的 POST 查询参数。
        /// </summary>
        string GetPostString();

        /// <summary>
        /// 用于标识请求参数体是否准备好。
        /// </summary>
        bool IsReady();
    }
}