using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Response
{
    public class SmsCommonResponse : CommonResponse
    {
        /// <summary>
        /// 发送回执 ID，根据该参数可以在 <see cref="AbpAliyunSms"/> 的 QuerySendDetailsAsync 方法中查询发送结果。
        /// </summary>
        public string BizId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        
        public string Code { get; set; }
    }
}