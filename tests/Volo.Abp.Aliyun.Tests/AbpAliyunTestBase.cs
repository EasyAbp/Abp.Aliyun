using Volo.Abp.Modularity;

namespace Volo.Abp.Aliyun.Tests
{
    public class AbpAliyunTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}