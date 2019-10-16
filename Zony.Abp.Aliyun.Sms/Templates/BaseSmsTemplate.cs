namespace Zony.Abp.Aliyun.Sms.Templates
{
    public abstract class BaseSmsTemplate : ISmsTemplate
    {
        public string SignName { get; }
        
        public string TemplateCode { get; }
        
        public object TemplateContent { get; }
    }
}