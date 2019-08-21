using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Zony.Abp.Aliyun.Sms.Model.Request;
using Zony.Abp.Aliyun.Sms.Model.Response;

namespace Zony.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class SendSmsRequest_Tests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new SendSmsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
                AbpAliyunSmsTestsConsts.CompanyName,
                AbpAliyunSmsTestsConsts.TemplateCode, 
                AbpAliyunSmsTestsConsts.TemplateParamJson);
            
            // Act
            var result = await AliyunApiRequester.SendRequestAsync<SendSmsResponse>(request,
                AbpAliyunSmsOptions.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}