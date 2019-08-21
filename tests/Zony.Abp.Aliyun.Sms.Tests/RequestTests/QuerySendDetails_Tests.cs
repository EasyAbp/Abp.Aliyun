using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Zony.Abp.Aliyun.Sms.Model.Request;
using Zony.Abp.Aliyun.Sms.Model.Response;

namespace Zony.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class QuerySendDetails_Tests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new QuerySendDetailsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
                "20190801",
                20, 
                1);
            
            // Act
            var result = await AliyunApiRequester.SendRequestAsync<QuerySendDetailsResponse>(request,
                AbpAliyunSmsOptions.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}