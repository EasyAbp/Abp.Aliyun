using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using EasyAbp.Abp.Aliyun.Common.Services;
using EasyAbp.Abp.Aliyun.Sms.Model.Request;
using EasyAbp.Abp.Aliyun.Sms.Model.Response;
using EasyAbp.Abp.Aliyun.Sms.Templates;

namespace EasyAbp.Abp.Aliyun.Sms.Services
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