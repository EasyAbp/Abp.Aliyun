using System.Threading.Tasks;
using EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsSign;
using EasyAbp.Abp.Aliyun.Sms.Model.Response.SmsSign;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class SmsSignServiceTests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task AddSmsSign_Test()
        {
            var request = new AddSmsSignRequest("成都中飞物联测试",
                0,
                "备注说明",
                new[] {"1"},
                new[] {"2"});

            var response = await AliyunApiRequester.SendRequestAsync<AddSmsSignResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }
    }
}