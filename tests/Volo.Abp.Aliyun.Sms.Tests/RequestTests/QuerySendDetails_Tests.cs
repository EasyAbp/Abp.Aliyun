using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shouldly;
using Volo.Abp.Aliyun.Common;
using Volo.Abp.Aliyun.Common.Configurations;
using Volo.Abp.Aliyun.Sms.Model.Request;
using Volo.Abp.Aliyun.Sms.Model.Response;
using Volo.Abp.Aliyun.Tests;
using Xunit;

namespace Volo.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class QuerySendDetails_Tests : AbpAliyunTestBase<AbpAliyunSmsTestsModule>
    {
        private readonly IAliyunApiRequester _aliyunApiRequester;
        
        private readonly AbpAliyunSmsOptions _abpAliyunSmsOptions;
        private readonly AbpAliyunOptions _aliyunOptions;

        public QuerySendDetails_Tests()
        {
            _aliyunApiRequester = GetRequiredService<IAliyunApiRequester>();
            _abpAliyunSmsOptions = GetRequiredService<IOptions<AbpAliyunSmsOptions>>().Value;
            _aliyunOptions = GetRequiredService<IOptions<AbpAliyunOptions>>().Value;

            _aliyunOptions.AccessKeyId = AbpAliyunSmsTestsConsts.AccessKeyId;
            _aliyunOptions.AccessKeySecret = AbpAliyunSmsTestsConsts.AccessKeySecret;
        }
        
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new QuerySendDetailsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
                "20190801",
                20, 
                1);
            
            // Act
            var result = await _aliyunApiRequester.SendRequestAsync<QuerySendDetailsResponse>(request,
                _abpAliyunSmsOptions.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}