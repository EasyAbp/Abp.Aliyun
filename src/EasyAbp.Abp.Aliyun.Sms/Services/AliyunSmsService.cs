using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 发送短信。
        /// </summary>
        /// <param name="phoneNumber">需要发送的手机号码。</param>
        /// <param name="smsTemplate">需要发送的短信信息。</param>
        /// <remarks>
        /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/101414.html?spm=a2c4g.11186623.6.632.6a701040dg1NZb。
        /// </remarks>
        public async Task<SmsCommonResponse> SendMessageAsync(string phoneNumber, ISmsTemplate smsTemplate)
        {
            return await AliyunApiRequester.SendRequestAsync<SendSmsResponse>(new SendSmsRequest(phoneNumber,
                    smsTemplate.SignName,
                    smsTemplate.TemplateCode,
                    smsTemplate.TemplateContent),
                _smsOptions.EndPoint);
        }

        /// <summary>
        /// 批量发送短信。
        /// </summary>
        /// <param name="phoneNumbers">需要发送的手机号码组。</param>
        /// <param name="smsTemplates">需要发送的短信信息。</param>
        /// <remarks>
        /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/102364.html?spm=a2c4g.11186623.6.633.7e1d65f48NL2Rj。
        /// </remarks>
        public async Task<SmsCommonResponse> SendBatchSmsAsync(IEnumerable<string> phoneNumbers, IEnumerable<ISmsTemplate> smsTemplates)
        {
            var templates = smsTemplates.ToList();

            if (!templates.Any())
            {
                throw new ArgumentNullException(nameof(smsTemplates), $"The {nameof(smsTemplates)} sequence is empty!");
            }
            
            var signNames = templates.Select(t => t.SignName);
            var templateCode = templates.First().TemplateCode;
            var templateParams = templates.Select(t => t.TemplateContent);

            return await AliyunApiRequester.SendRequestAsync<SendSmsResponse>(new SendBatchSmsRequest(phoneNumbers,
                    signNames,
                    templateCode,
                    templateParams),
                _smsOptions.EndPoint);
        }
    }
}