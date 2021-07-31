using System.Threading.Tasks;
using Shouldly;
using Xunit;
using EasyAbp.Abp.Aliyun.Sms.Model.Request;
using EasyAbp.Abp.Aliyun.Sms.Model.Response;

namespace EasyAbp.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class QuerySendDetailsTests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new QuerySendDetailsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
                "20210731",
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