using Zony.Abp.Aliyun.Common;
using Zony.Abp.Aliyun.Common.Model;

namespace Zony.Abp.Aliyun.Sms.Model.Response
{
    public class SmsCommonResponse : CommonResponse
    {
        public string Message { get; set; }
        
        public string Code { get; set; }
    }
}