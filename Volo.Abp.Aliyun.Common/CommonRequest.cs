using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Volo.Abp.Aliyun.Common
{
    public abstract class CommonRequest : ICommonRequest
    {
        /// <summary>
        ///     表示当前请求模型是否准备就绪，当调用了 <see cref="SetCommonParameters" /> 方法
        ///     之后，当前属性的值为 true。
        /// </summary>
        public bool IsSetCommonParameters { get; private set; }

        public SortedDictionary<string, string> RequestParameters { get; }

        public HttpMethod Method { get; protected set; }

        public CommonRequest()
        {
            RequestParameters = new SortedDictionary<string, string>(StringComparer.Ordinal)
            {
                {"Format", "json"},
                {"SignatureMethod", "HMAC-SHA1"},
                {"Version", "2017-05-25"},
                {"SignatureVersion", "1.0"},
                {"Timestamp", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")},
                {"Action", ""}
            };

            IsSetCommonParameters = false;
        }

        /// <summary>
        ///     设置公共参数，开发人员不需要主动调用本方法。
        /// </summary>
        public virtual ICommonRequest SetCommonParameters(string accessKeyId, Guid signNonce)
        {
            if (!RequestParameters.ContainsKey("AccessKeyId")) RequestParameters.Add("AccessKeyId", accessKeyId);
            if (!RequestParameters.ContainsKey("SignatureNonce")) RequestParameters.Add("SignatureNonce", signNonce.ToString());

            IsSetCommonParameters = true;
            return this;
        }

        /// <summary>
        ///     计算签名参数，开发人员不需要主动调用本方法。
        /// </summary>
        public virtual ICommonRequest SetSignature(string accessKey)
        {
            var sortedQueryString = GetQueryString();
            var signBuilder = new StringBuilder();

            signBuilder.Append(Method)
                .Append("&")
                .Append(SpecialUrlEncode("/"))
                .Append("&")
                .Append(SpecialUrlEncode(sortedQueryString));

            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes($"{accessKey}&"));
            var signStr = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(signBuilder.ToString())));

            RequestParameters.Add("Signature", signStr);

            return this;
        }

        /// <summary>
        ///     根据 <see cref="ICommonRequest.RequestParameters" /> 字典生成 HTTP 请求的 GET 查询串。
        /// </summary>
        public virtual string GetQueryString()
        {
            var sb = new StringBuilder();

            foreach (var requestParameter in RequestParameters)
                sb.Append("&")
                    .Append(SpecialUrlEncode(requestParameter.Key))
                    .Append("=")
                    .Append(SpecialUrlEncode(requestParameter.Value));

            return sb.ToString().Substring(1);
        }

        /// <summary>
        ///     根据 <see cref="ICommonRequest.RequestParameters" /> 字典生成 HTTP 请求的 POST 查询参数。
        /// </summary>
        public virtual string GetPostString()
        {
            return JsonConvert.SerializeObject(RequestParameters);
        }

        /// <summary>
        ///     用于标识请求参数体是否准备好。
        /// </summary>
        public virtual bool IsReady()
        {
            return IsSetCommonParameters;
        }

        private string SpecialUrlEncode(string srcStr)
        {
            var stringBuilder = new StringBuilder();
            const string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            var bytes = Encoding.UTF8.GetBytes(srcStr);
            foreach (var @byte in bytes)
            {
                var @char = (char) @byte;
                // 如果值是 text 集合内的数据，则使用默认的值。
                if (text.IndexOf(@char) >= 0)
                {
                    stringBuilder.Append(@char);
                }
                else
                {
                    stringBuilder.Append("%")
                        .Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int) @char));
                }
            }

            return stringBuilder.ToString();
        }
    }
}