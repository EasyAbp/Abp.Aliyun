using Volo.Abp;
using Zony.Abp.Aliyun.Common;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Zony.Abp.Aliyun.Tests
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule),
        typeof(AbpAliyunCommonModule))]
    public class AbpAliyunTestsModule : AbpModule
    {
        
    }
}