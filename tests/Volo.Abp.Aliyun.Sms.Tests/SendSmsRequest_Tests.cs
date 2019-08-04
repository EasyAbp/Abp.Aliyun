using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Aliyun.Common;
using Volo.Abp.Aliyun.Sms.Model.Request;
using Volo.Abp.Aliyun.Sms.Model.Response;
using Volo.Abp.Aliyun.Tests;
using Xunit;

namespace Volo.Abp.Aliyun.Sms.Tests
{
    public class SendSmsRequest_Tests : AbpAliyunTestBase<AbpAliyunSmsTestsModule>
    {
        private readonly IAliyunApiRequester _aliyunApiRequester;

        public SendSmsRequest_Tests()
        {
            _aliyunApiRequester = GetRequiredService<IAliyunApiRequester>();
        }
        
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new SendSmsRequest("110", "signName", "templateCode", new
            {
                userName = "张三"
            });
            
            // Act
            var result = await _aliyunApiRequester.SendRequestAsync<SendSmsResponse>(request,"");
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}