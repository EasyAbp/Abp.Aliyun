using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsTemplate
{
    /// <summary>
    /// 用于查询短信模板的审核状态的请求定义。
    /// </summary>
    /// <remarks>
    /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/121206.htm。<br/>
    /// 申请短信模板后，可以通过接口 QuerySmsTemplate 查询短信模板的审核状态。如果审核未通过，会返回审核失败的原因，请针对具体原因重新修改短信模板。
    /// </remarks>
    public class QuerySmsTemplateRequest : CommonRequest
    {
        /// <summary>
        /// 构建一个新的 <see cref="QuerySmsTemplateRequest"/> 对象。
        /// </summary>
        protected QuerySmsTemplateRequest()
        {
            RequestParameters["Action"] = "DeleteSmsTemplate";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 构建一个新的 <see cref="QuerySmsTemplateRequest"/> 对象。
        /// </summary>
        /// <param name="templateCode">短信模板 CODE。您可以在控制台模板管理页面或 API 接口 AddSmsTemplate 的返回参数中获取短信模板 CODE。</param>
        public QuerySmsTemplateRequest(string templateCode) : this()
        {
            AddParameter("TemplateCode", templateCode);
        }
    }
}