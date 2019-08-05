using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shouldly;
using Zony.Abp.Aliyun.Common;
using Zony.Abp.Aliyun.Common.Configurations;
using Zony.Abp.Aliyun.Sms;
using Zony.Abp.Aliyun.Sms.Model.Request;
using Zony.Abp.Aliyun.Sms.Model.Response;
using Zony.Abp.Aliyun.Tests;
using Xunit;

namespace Zony.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class SendSmsRequest_Tests : AbpAliyunTestBase<AbpAliyunSmsTestsModule>
    {
        private readonly IAliyunApiRequester _aliyunApiRequester;
        
        private readonly AbpAliyunSmsOptions _abpAliyunSmsOptions;
        private readonly AbpAliyunOptions _aliyunOptions;

        public SendSmsRequest_Tests()
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
            var request = new SendSmsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
                AbpAliyunSmsTestsConsts.CompanyName,
                AbpAliyunSmsTestsConsts.TemplateCode, 
                AbpAliyunSmsTestsConsts.TemplateParamJson);
            
            // Act
            var result = await _aliyunApiRequester.SendRequestAsync<SendSmsResponse>(request,
                _abpAliyunSmsOptions.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}