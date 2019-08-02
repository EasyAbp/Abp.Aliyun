using Volo.Abp.Aliyun.Common;

namespace Volo.Abp.Aliyun.Sms.Model.Request
{
    public class SendSmsResponse : CommonResponse
    {
        public string BizId { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string RequestId { get; set; }
    }
}