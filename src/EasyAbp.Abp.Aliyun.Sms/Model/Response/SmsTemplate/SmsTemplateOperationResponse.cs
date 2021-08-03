using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Response.SmsTemplate
{
    public class SmsTemplateOperationResponse : CommonResponse
    {
        /// <summary>
        /// 短信模板 CODE。<br/>
        /// 您可以使用模板 CODE 通过 API 接口 QuerySmsTemplate 或在控制台查看模板申请状态和结果。
        /// </summary>
        /// <example>示例值: SMS_152550005。</example>
        public string TemplateCode { get; set; }
    }
}