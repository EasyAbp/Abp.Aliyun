using Volo.Abp.Modularity;
using EasyAbp.Abp.Aliyun.Common;

namespace EasyAbp.Abp.Aliyun.LiveVideo
{
    [DependsOn(typeof(AbpAliyunCommonModule))]
    public class AbpAliyunLiveVideoModule : AbpModule
    {
    }
}