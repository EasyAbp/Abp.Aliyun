namespace EasyAbp.Abp.Aliyun.Sms
{
    public class AbpAliyunSmsOptions
    {
        /// <summary>
        /// 阿里云短信服务的公网服务地址，如果用户没有进行配置，则默认为 http://dysmsapi.aliyuncs.com。
        /// </summary>
        public string EndPoint { get; set; }

        public AbpAliyunSmsOptions()
        {
            EndPoint = "http://dysmsapi.aliyuncs.com";
        }
    }
}