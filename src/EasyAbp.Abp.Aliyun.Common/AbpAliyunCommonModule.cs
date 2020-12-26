using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Aliyun.Common
{
    [DependsOn(
        typeof(AbpGuidsModule),
        typeof(AbpJsonModule))]
    public class AbpAliyunCommonModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
        }
    }
}