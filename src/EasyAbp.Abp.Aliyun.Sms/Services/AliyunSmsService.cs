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
            return await AliyunApiRequester.SendRequestAsync<SmsCommonResponse>(new SendSmsRequest(phoneNumber,
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

            return await AliyunApiRequester.SendRequestAsync<SmsCommonResponse>(new SendBatchSmsRequest(phoneNumbers,
                    signNames,
                    templateCode,
                    templateParams),
                _smsOptions.EndPoint);
        }

        /// <summary>
        /// 查询短信发送记录和发送状态。
        /// </summary>
        /// <param name="currentPage">分页查看发送记录，指定发送记录的当前页码。</param>
        /// <param name="pageSize">
        /// 分页查看发送记录，指定每页显示的短信记录数量。<br/>
        /// 取值范围为1~50。
        /// </param>
        /// <param name="phoneNumber">
        /// 接收短信的手机号码。<br/>
        /// 格式:<br/>
        /// 国内短信：11位手机号码，例如1590000****。<br/>
        /// 国际/港澳台消息：国际区号+号码，例如8520000****。
        /// </param>
        /// <param name="sendDate">
        /// 短信发送日期，支持查询最近30天的记录。<br/>
        /// 格式为 yyyyMMdd，例如 20181225。
        /// </param>
        /// <param name="bizId">
        /// 发送回执ID，即发送流水号。<br/>
        /// 调用发送接口 SendSms 或 SendBatchSms 发送短信时，返回值中的 BizId 字段。
        /// </param>
        /// <remarks>
        /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/102352.html?spm=a2c4g.11186623.6.635.550965f4WeL380。
        /// </remarks>
        public async Task<QuerySendDetailsResponse> QuerySendDetailsAsync(int currentPage, int pageSize, string phoneNumber, DateTime sendDate, string bizId = null)
        {
            return await AliyunApiRequester.SendRequestAsync<QuerySendDetailsResponse>(new QuerySendDetailsRequest(phoneNumber,
                sendDate.ToString("yyyyMMdd"),pageSize,currentPage,bizId),_smsOptions.EndPoint);
        }
    }
}