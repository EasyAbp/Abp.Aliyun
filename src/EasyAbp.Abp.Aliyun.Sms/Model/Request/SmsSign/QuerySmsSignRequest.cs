using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsSign
{
    /// <summary>
    /// 用于查询短信签名申请状态的请求定义。<br/>
    /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/121210.html。<br/>
    /// 申请短信签名后，您可以在控制台或通过接口 QuerySmsSign 查看短信签名的申请状态。如果未通过审核，接口会返回未通过审核的原因，请针对具体原因修改签名并重新提交审核。
    /// </summary>
    public class QuerySmsSignRequest : CommonRequest
    {
        /// <summary>
        /// 构造一个新的 <see cref="QuerySmsSignRequest"/> 对象。
        /// </summary>
        protected QuerySmsSignRequest()
        {
            RequestParameters["Action"] = "QuerySmsSign";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 构造一个新的 <see cref="QuerySmsSignRequest"/> 对象。
        /// </summary>
        /// <param name="signName">签名名称。</param>
        public QuerySmsSignRequest(string signName) : this()
        {
            AddParameter("SignName", signName);
        }
    }
}