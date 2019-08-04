using Volo.Abp.Aliyun.Common;

namespace Volo.Abp.Aliyun.Sms.Model.Response
{
    public class SendSmsResponse : CommonResponse
    {
        public string BizId { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}