using Microsoft.Extensions.Options;
using EasyAbp.Abp.Aliyun.Common;
using EasyAbp.Abp.Aliyun.Tests;
using Volo.Abp.Json;

namespace EasyAbp.Abp.Aliyun.Sms.Tests
{
    public class AbpAliyunSmsTestBase : AbpAliyunTestBase<AbpAliyunSmsTestsModule>
    {
        protected readonly IJsonSerializer JsonSerializer;
        protected readonly IAliyunApiRequester AliyunApiRequester;
        protected readonly AbpAliyunSmsOptions AbpAliyunSmsOptions;

        public AbpAliyunSmsTestBase()
        {
            JsonSerializer = GetRequiredService<IJsonSerializer>();
            AliyunApiRequester = GetRequiredService<IAliyunApiRequester>();
            AbpAliyunSmsOptions = GetRequiredService<IOptions<AbpAliyunSmsOptions>>().Value;
        }
    }
}