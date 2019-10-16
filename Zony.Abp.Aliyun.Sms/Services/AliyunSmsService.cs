using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Zony.Abp.Aliyun.Common.Services;
using Zony.Abp.Aliyun.Sms.Model.Request;
using Zony.Abp.Aliyun.Sms.Model.Response;
using Zony.Abp.Aliyun.Sms.Templates;

namespace Zony.Abp.Aliyun.Sms.Services
{
    public class AliyunSmsService : BaseAliyunService
    {
        private readonly AbpAliyunSmsOptions _smsOptions;

        public AliyunSmsService(IOptions<AbpAliyunSmsOptions> smsOptions)
        {
            _smsOptions = smsOptions.Value;
        }

        public async Task<SmsCommonResponse> SendMessageAsync(string phoneNumber, ISmsTemplate smsTemplate)
        {
            return await AliyunApiRequester.SendRequestAsync<SendSmsResponse>(new SendSmsRequest(phoneNumber,
                    smsTemplate.SignName,
                    smsTemplate.TemplateCode,
                    smsTemplate.TemplateContent),
                _smsOptions.EndPoint);
        }
    }
}