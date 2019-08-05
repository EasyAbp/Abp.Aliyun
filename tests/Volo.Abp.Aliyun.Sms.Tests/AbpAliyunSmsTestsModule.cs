using Volo.Abp.Aliyun.Tests;
using Volo.Abp.Modularity;

namespace Volo.Abp.Aliyun.Sms.Tests
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