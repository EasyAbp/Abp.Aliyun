using Volo.Abp.Modularity;
using Zony.Abp.Aliyun.Tests;

namespace Zony.Abp.Aliyun.Sms.Tests
{
    [DependsOn(typeof(AbpAliyunTestsModule),
        typeof(AbpAliyunSmsModule))]
    public class AbpAliyunSmsTestsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
        }
    }
}