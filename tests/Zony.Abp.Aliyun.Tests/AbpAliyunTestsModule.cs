using Volo.Abp;
using Zony.Abp.Aliyun.Common;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Zony.Abp.Aliyun.Common.Configurations;

namespace Zony.Abp.Aliyun.Tests
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule),
        typeof(AbpAliyunCommonModule))]
    public class AbpAliyunTestsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAliyunOptions>(op =>
            {
                op.AccessKeyId = AbpAliyunTestsConsts.AccessKeyId;
                op.AccessKeySecret = AbpAliyunTestsConsts.AccessKeySecret;
            });
        }
    }
}