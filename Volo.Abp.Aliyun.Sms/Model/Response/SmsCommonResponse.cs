using Volo.Abp.Aliyun.Common;

namespace Volo.Abp.Aliyun.Sms.Model.Response
{
    public class SmsCommonResponse : CommonResponse
    {
        public string Message { get; set; }
        
        public string Code { get; set; }
    }
}