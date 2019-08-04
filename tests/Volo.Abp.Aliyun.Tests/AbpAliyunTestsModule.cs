using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Volo.Abp.Aliyun.Tests
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule))]
    public class AbpAliyunTestsModule : AbpModule
    {
        
    }
}