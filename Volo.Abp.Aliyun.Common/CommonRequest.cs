using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Volo.Abp.Aliyun.Common
{
    public abstract class CommonRequest : ICommonRequest
    {
        public bool IsSetCommonParameters { get; private set; }
        
        public SortedDictionary<string, string> RequestParameters { get; }
        
        public HttpMethod Method { get; protected set; }

        public CommonRequest()
        {
            RequestParameters = new SortedDictionary<string, string>
            {
                {"Format","json"},
                {"SignatureMethod","HMAC-SHA1"},
                {"Version","2017-05-25"},
                {"SignatureVersion","1.0"},
                {"Timestamp",DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")},
                {"Action",""}
            };
            
            IsSetCommonParameters = false;
        }
        
        /// <summary>
        /// 设置公共参数，开发人员不需要主动调用本方法。
        /// </summary>
        public virtual ICommonRequest SetCommonParameters(string accessKeyId,Guid signNonce)
        {
            if(!RequestParameters.ContainsKey("AccessKeyId")) RequestParameters.Add("AccessKeyId",accessKeyId);
            if(!RequestParameters.ContainsKey("SignatureNonce")) RequestParameters.Add("SignatureNonce",signNonce.ToString());

            IsSetCommonParameters = true;
            return this;
        }

        /// <summary>
        /// 计算签名参数，开发人员不需要主动调用本方法。
        /// </summary>
        public virtual ICommonRequest SetSignature(string accessKey)
        {
            var paraStr = GetQueryString();
            var signBuilder= new StringBuilder();

            signBuilder.Append(Method)
                .Append(HttpUtility.UrlEncode("/"))
                .Append("&")
                .Append(HttpUtility.UrlEncode(paraStr));

            var signStr = signBuilder.ToString()
                .Replace("%2f", "%2F")
                .Replace("%3d", "%3D")
                .Replace("%2b", "%2B")
                .Replace("%253a", "%253A");
            
            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes($"{accessKey}&"));
            signStr = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(signStr)));
            
            RequestParameters.Add("Signature",signStr);
            
            return this;
        }

        /// <summary>
        /// 根据 <see cref="ICommonRequest.RequestParameters"/> 字典生成 HTTP 请求的 GET 查询串。
        /// </summary>
        public virtual string GetQueryString()
        {
            var sb = new StringBuilder();
            
            foreach (var requestParameter in RequestParameters)
            {
                sb.Append("&")
                    .Append(HttpUtility.UrlEncode(requestParameter.Key))
                    .Append("=")
                    .Append(HttpUtility.UrlEncode(requestParameter.Value));
            }

            return sb.ToString().Substring(1);
        }

        /// <summary>
        /// 根据 <see cref="ICommonRequest.RequestParameters"/> 字典生成 HTTP 请求的 POST 查询参数。
        /// </summary>
        public virtual string GetPostString()
        {
            return JsonConvert.SerializeObject(RequestParameters);
        }

        /// <summary>
        /// 用于标识请求参数体是否准备好。
        /// </summary>
        public virtual bool IsReady()
        {
            return IsSetCommonParameters;
        }
    }
}