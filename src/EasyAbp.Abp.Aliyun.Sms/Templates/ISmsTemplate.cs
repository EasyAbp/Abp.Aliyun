namespace EasyAbp.Abp.Aliyun.Sms.Templates
{
    /// <summary>
    /// Sms 模板消息接口，用于定义短信模板。
    /// </summary>
    public interface ISmsTemplate
    {
        /// <summary>
        /// 短信模板所使用的短信签名。
        /// </summary>
        string SignName { get; }
        
        /// <summary>
        /// 短信模板的 Code。
        /// </summary>
        string TemplateCode { get; }
        
        /// <summary>
        /// 短信模板的具体内容。
        /// </summary>
        object TemplateContent { get; }
    }
}