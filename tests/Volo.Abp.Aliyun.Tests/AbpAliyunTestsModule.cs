using Volo.Abp.Aliyun.Common;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Volo.Abp.Aliyun.Tests
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule),
        typeof(AbpAliyunCommonModule))]
    public class AbpAliyunTestsModule : AbpModule
    {
        
    }
}