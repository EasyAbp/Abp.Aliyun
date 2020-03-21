using EasyAbp.Abp.Aliyun.Common;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Response
{
    public class SmsCommonResponse : CommonResponse
    {
        public string Message { get; set; }
        
        public string Code { get; set; }
    }
}