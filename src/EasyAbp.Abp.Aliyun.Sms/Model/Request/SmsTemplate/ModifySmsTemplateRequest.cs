using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsTemplate
{
    /// <summary>
    /// 用于修改未通过审核的短信模板的请求定义。
    /// </summary>
    /// <remarks>
    /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/121205.html。<br/>
    /// 您可以通过短信服务 API 接口或短信服务控制台申请短信模板，模板内容需要符合文本短信模板规范或国际/港澳台短信模板规范。<br/>
    /// 短信模板审核流程请参考模板审核流程。<br/>
    /// 注意: 一个自然日最多可以申请 100 个模板，间隔建议您控制在 30S 以上。
    /// </remarks>
    public class ModifySmsTemplateRequest : CommonRequest
    {
        /// <summary>
        /// 构建一个新的 <see cref="ModifySmsTemplateRequest"/> 对象。
        /// </summary>
        protected ModifySmsTemplateRequest()
        {
            RequestParameters["Action"] = "ModifySmsTemplate";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 构建一个新的 <see cref="ModifySmsTemplateRequest"/> 对象。
        /// </summary>
        /// <param name="templateType">
        /// 短信类型。其中: <br/>
        /// 0: 验证码。<br/>
        /// 1: 短信通知。<br/>
        /// 2: 推广短信。<br/>
        /// 3: 国际/港澳台消息。
        /// </param>
        /// <param name="templateName">模板名称，长度为 1~30 个字符。</param>
        /// <param name="templateContent">
        /// 模板内容，长度为1~500个字符。<br/>
        /// 模板内容需要符合文本短信模板规范或国际/港澳台短信模板规范。
        /// </param>
        /// <param name="remark">短信模板申请说明。请在申请说明中描述您的业务使用场景，长度为 1~100 个字符。</param>
        /// <param name="templateCode">短信模板 CODE。您可以在控制台模板管理页面或 API 接口 AddSmsTemplate 的返回参数中获取短信模板 CODE。</param>
        public ModifySmsTemplateRequest(string templateType,
            string templateName,
            string templateContent,
            string remark,
            string templateCode) : this()
        {
            AddParameter("TemplateType", templateType);
            AddParameter("TemplateName", templateName);
            AddParameter("TemplateContent", templateContent);
            AddParameter("Remark", remark);
            AddParameter("TemplateCode", templateCode);
        }
    }
}