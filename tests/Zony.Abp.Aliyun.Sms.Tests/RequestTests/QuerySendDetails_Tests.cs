using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shouldly;
using Xunit;
using Zony.Abp.Aliyun.Common;
using Zony.Abp.Aliyun.Common.Configurations;
using Zony.Abp.Aliyun.Sms.Model.Request;
using Zony.Abp.Aliyun.Sms.Model.Response;
using Zony.Abp.Aliyun.Tests;

namespace Zony.Abp.Aliyun.Sms.Tests.RequestTests
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