using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Response.SmsTemplate
{
    public class QuerySmsTemplateResponse : CommonResponse
    {
        /// <summary>
        /// 审核备注。
        /// </summary>
        /// <remarks>
        /// 如果审核状态为审核通过或审核中，参数 Reason 显示为“无审核备注”。<br/>
        /// 如果审核状态为审核未通过，参数 Reason 显示审核的具体原因。
        /// </remarks>
        /// <example>示例值: 非验证码类型短信，请选择短信通知类型为推广短信。</example>
        public string Reason { get; set; }

        /// <summary>
        /// 短信模板的创建日期和时间。
        /// </summary>
        /// <example>示例值: 2019-06-04 11:42:17	。</example>
        public string CreateDate { get; set; }

        /// <summary>
        /// 短信模板 CODE。
        /// </summary>
        /// <example>示例值: SMS_167035184 。</example>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 模板内容。
        /// </summary>
        /// <example>示例值: 亲爱的会员！阿里云短信服务祝您新年快乐！</example>
        public string TemplateContent { get; set; }

        /// <summary>
        /// 模板名称。
        /// </summary>
        /// <example>示例值: 阿里云短信测试模板。</example>
        public string TemplateName { get; set; }

        /// <summary>
        /// 模板审核状态。
        /// </summary>
        /// <example>示例值: 1 。</example>
        /// <remarks>
        /// 0: 审核中。<br/>
        /// 1: 审核通过。<br/>
        /// 2: 审核失败，请在返回参数Reason中查看审核失败原因。
        /// </remarks>
        public int TemplateStatus { get; set; }

        /// <summary>
        /// 短信类型。
        /// </summary>
        /// <example>示例值: 1。</example>
        /// <remarks>
        /// 0: 验证码。<br/>
        /// 1: 短信通知。<br/>
        /// 2: 推广短信。<br/>
        /// 3: 国际/港澳台消息。
        /// </remarks>
        public int TemplateType { get; set; }
    }
}