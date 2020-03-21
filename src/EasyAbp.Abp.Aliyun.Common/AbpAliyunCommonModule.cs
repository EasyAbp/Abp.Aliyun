using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Aliyun.Common
{
    [DependsOn(typeof(AbpGuidsModule))]
    public class AbpAliyunCommonModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
        }
    }
}