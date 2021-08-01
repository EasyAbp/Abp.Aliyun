using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsSign
{
    /// <summary>
    /// 用于删除短信签名的请求定义。<br/>
    /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/121209.html。<br/>
    /// 不支持删除正在审核中的签名。<br/>
    /// 短信签名删除后不可恢复，请谨慎操作。
    /// </summary>
    public class DeleteSmsSignRequest : CommonRequest
    {
        /// <summary>
        /// 构建一个新的 <see cref="DeleteSmsSignRequest"/> 对象。
        /// </summary>
        protected DeleteSmsSignRequest()
        {
            RequestParameters["Action"] = "DeleteSmsSign";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 构建一个新的 <see cref="DeleteSmsSignRequest"/> 对象。
        /// </summary>
        /// <param name="signName">短信签名。</param>
        public DeleteSmsSignRequest(string signName) : this()
        {
            AddParameter("SignName", signName);
        }
    }
}