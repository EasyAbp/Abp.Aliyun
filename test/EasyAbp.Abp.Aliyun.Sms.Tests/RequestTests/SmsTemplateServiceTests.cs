using System.Threading.Tasks;
using EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsTemplate;
using EasyAbp.Abp.Aliyun.Sms.Model.Response.SmsTemplate;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class SmsTemplateServiceTests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task AddSmsTemplate_Test()
        {
            var request = new AddSmsTemplateRequest("0",
                "测试验证码短信模板",
                "我是一条测试验证码短信模板 {code}",
                "我是一条测试备注信息。");

            var response = await AliyunApiRequester.SendRequestAsync<SmsTemplateOperationResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }

        [Fact]
        public async Task ModifySmsTemplate_Test()
        {
            var request = new ModifySmsTemplateRequest("0",
                "(改)测试验证码短信模板",
                "(改)我是一条测试验证码短信模板 {code}",
                "(改)我是一条测试备注信息。",
                "SMS_TEST_CODE");

            var response = await AliyunApiRequester.SendRequestAsync<SmsTemplateOperationResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }

        [Fact]
        public async Task DeleteSmsTemplate_Test()
        {
            var request = new DeleteSmsTemplateRequest("SMS_TEST_CODE");

            var response = await AliyunApiRequester.SendRequestAsync<SmsTemplateOperationResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }

        [Fact]
        public async Task QuerySmsTemplate_Test()
        {
            var request = new QuerySmsTemplateRequest("SMS_TEST_CODE");

            var response = await AliyunApiRequester.SendRequestAsync<QuerySmsTemplateResponse>(request, AbpAliyunSmsOptions.EndPoint);

            response.ShouldNotBeNull();
            response.Code.ShouldBe("OK");
        }
    }
}