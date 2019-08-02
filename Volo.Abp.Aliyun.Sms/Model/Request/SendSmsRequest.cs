using Volo.Abp.Aliyun.Common;

namespace Volo.Abp.Aliyun.Sms.Model.Request
{
    public class SendSmsRequest : CommonRequest
    {
        public SendSmsRequest(string phone)
        {
            
        }

        public string PhoneNumbers { get; set; }

        public string SignName { get; set; }

        public string TemplateCode { get; set; }

        public string AccessKeyId { get; set; }

        public string Action { get; set; }

        public string OutId { get; set; }

        public string SmsUpExtendCode { get; set; }

        public string TemplateParam { get; set; }
    }
}