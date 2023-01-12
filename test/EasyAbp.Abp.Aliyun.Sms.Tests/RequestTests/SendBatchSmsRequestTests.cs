using System.Threading.Tasks;
using EasyAbp.Abp.Aliyun.Sms.Model.Request;
using EasyAbp.Abp.Aliyun.Sms.Model.Response;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class SendBatchSmsRequestTests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new SendBatchSmsRequest(
                JsonSerializer,
                new []{AbpAliyunSmsTestsConsts.TargetPhoneNumber}, 
                new []{AbpAliyunSmsTestsConsts.CompanyName},
                AbpAliyunSmsTestsConsts.TemplateCode, 
                new[]{AbpAliyunSmsTestsConsts.TemplateParamJson});
            
            // Act
            var result = await AliyunApiRequester.SendRequestAsync<SmsCommonResponse>(request,
                AbpAliyunSmsOptions.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}