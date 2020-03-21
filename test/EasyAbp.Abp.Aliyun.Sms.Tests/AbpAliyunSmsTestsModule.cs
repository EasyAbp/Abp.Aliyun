using Volo.Abp.Modularity;
using EasyAbp.Abp.Aliyun.Tests;

namespace EasyAbp.Abp.Aliyun.Sms.Tests
{
    [DependsOn(typeof(AbpAliyunTestsModule),
        typeof(AbpAliyunSmsModule))]
    public class AbpAliyunSmsTestsModule : AbpModule
    {
        
    }
}