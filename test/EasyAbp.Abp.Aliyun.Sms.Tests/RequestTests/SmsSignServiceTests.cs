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

            var response = await AliyunApiRequester.SendRequestAsync<SmsSignOperationResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }

        [Fact]
        public async Task ModifySmsSign_Test()
        {
            var request = new ModifySmsSignRequest("成都中飞物联测试",
                0,
                "备注说明",
                new[] {"1"},
                new[] {"2"});

            var response = await AliyunApiRequester.SendRequestAsync<SmsSignOperationResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }

        [Fact]
        public async Task DeleteSmsSign_Test()
        {
            var request = new DeleteSmsSignRequest("成都中飞物联测试");

            var response = await AliyunApiRequester.SendRequestAsync<SmsSignOperationResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }

        [Fact]
        public async Task QuerySmsSign_Test()
        {
            var request = new QuerySmsSignRequest("成都中飞物联测试");

            var response = await AliyunApiRequester.SendRequestAsync<QuerySmsSignResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
            response.Reason.ShouldNotBeNullOrEmpty();
            response.SignStatus.ShouldBeInRange(0, 2);
        }
    }
}