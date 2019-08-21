using Microsoft.Extensions.Options;
using Zony.Abp.Aliyun.Common;
using Zony.Abp.Aliyun.Tests;

namespace Zony.Abp.Aliyun.Sms.Tests
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