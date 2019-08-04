namespace Volo.Abp.Aliyun.Sms
{
    public class AbpAliyunSmsOptions
    {
        /// <summary>
        /// 阿里云短信服务的公网服务地址。
        /// </summary>
        public string EndPoint { get; set; }

        public AbpAliyunSmsOptions()
        {
            EndPoint = "http://dysmsapi.aliyuncs.com";
        }
    }
}