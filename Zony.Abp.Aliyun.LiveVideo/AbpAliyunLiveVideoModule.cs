using Volo.Abp.Modularity;
using Zony.Abp.Aliyun.Common;

namespace Zony.Abp.Aliyun.LiveVideo
{
    [DependsOn(typeof(AbpAliyunCommonModule))]
    public class AbpAliyunLiveVideoModule : AbpModule
    {
    }
}