using System.Threading.Tasks;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<AbpAliyunSmsOptions> _abpAliyunSmsOptions;

        public SendSmsRequest_Tests()
        {
            _aliyunApiRequester = GetRequiredService<IAliyunApiRequester>();
            _abpAliyunSmsOptions = GetRequiredService<IOptions<AbpAliyunSmsOptions>>();
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
            var result = await _aliyunApiRequester.SendRequestAsync<SendSmsResponse>(request,_abpAliyunSmsOptions.Value.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}