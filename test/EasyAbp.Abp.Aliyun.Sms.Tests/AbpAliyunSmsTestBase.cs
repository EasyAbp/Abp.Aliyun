using Microsoft.Extensions.Options;
using EasyAbp.Abp.Aliyun.Common;
using EasyAbp.Abp.Aliyun.Tests;

namespace EasyAbp.Abp.Aliyun.Sms.Tests
{
    public class AbpAliyunSmsTestBase : AbpAliyunTestBase<AbpAliyunSmsTestsModule>
    {
        protected readonly IAliyunApiRequester AliyunApiRequester;
        protected readonly AbpAliyunSmsOptions AbpAliyunSmsOptions;

        public AbpAliyunSmsTestBase()
        {
            AliyunApiRequester = GetRequiredService<IAliyunApiRequester>();
            AbpAliyunSmsOptions = GetRequiredService<IOptions<AbpAliyunSmsOptions>>().Value;
        }
    }
}