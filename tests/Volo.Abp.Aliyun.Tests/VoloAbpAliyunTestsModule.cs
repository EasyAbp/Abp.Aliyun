using Shouldly;
using Volo.Abp.Modularity;

namespace Volo.Abp.Aliyun.Tests
{
    public class VoloAbpAliyunTestsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            int a = 10;
            a.ShouldBe(20);
            base.ConfigureServices(context);
        }
    }
}