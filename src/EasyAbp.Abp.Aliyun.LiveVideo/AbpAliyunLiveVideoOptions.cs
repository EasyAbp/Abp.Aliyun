namespace EasyAbp.Abp.Aliyun.LiveVideo
{
    public class AbpAliyunLiveVideoOptions
    {
        public string EndPoint { get; set; }

        public AbpAliyunLiveVideoOptions()
        {
            EndPoint = "https://live.aliyuncs.com";
        }
    }
}