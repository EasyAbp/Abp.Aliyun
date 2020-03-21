using Volo.Abp;
using EasyAbp.Abp.Aliyun.Common;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using EasyAbp.Abp.Aliyun.Common.Configurations;

namespace EasyAbp.Abp.Aliyun.Tests
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