using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsTemplate
{
    /// <summary>
    /// 用于删除短信模板的请求定义。
    /// </summary>
    public class DeleteSmsTemplateRequest : CommonRequest
    {
        /// <summary>
        /// 构造一个新的 <see cref="DeleteSmsTemplateRequest"/> 对象。
        /// </summary>
        protected DeleteSmsTemplateRequest()
        {
            RequestParameters["Action"] = "DeleteSmsTemplate";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 构造一个新的 <see cref="DeleteSmsTemplateRequest"/> 对象。
        /// </summary>
        /// <param name="templateCode">短信模板 CODE。您可以在控制台模板管理页面或 API 接口 AddSmsTemplate 的返回参数中获取短信模板 CODE。</param>
        public DeleteSmsTemplateRequest(string templateCode)
        {
            AddParameter("TemplateCode", templateCode);
        }
    }
}