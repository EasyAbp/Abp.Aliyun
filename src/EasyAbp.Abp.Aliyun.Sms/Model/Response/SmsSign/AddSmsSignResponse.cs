using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Response.SmsSign
{
    public class AddSmsSignResponse : CommonResponse
    {
        /// <summary>
        /// 签名名称。
        /// </summary>
        /// <example>示例值: 阿里云。</example>
        public string SignName { get; set; }
    }
}