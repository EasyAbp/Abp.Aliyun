using EasyAbp.Abp.Aliyun.Common;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Aliyun.Sms
{
    [DependsOn(typeof(AbpAliyunCommonModule))]
    public class AbpAliyunSms : AbpModule
    {
        
    }
}