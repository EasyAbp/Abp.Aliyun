using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;
using Volo.Abp.Json;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request
{
    /// <summary>
    /// 短信发送请求，如果需要发送单条短信的时候，可以使用本参数请求阿里云 API 进行发送。
    /// </summary>
    public class SendSmsRequest : CommonRequest
    {
        public SendSmsRequest()
        {
            RequestParameters["Action"] = "SendSms";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 向指定的号码发送短信。
        /// </summary>
        /// <param name="jsonSerializer">JsonSerializer</param>
        /// <param name="phoneNumber">手机号码。</param>
        /// <param name="signName">短信签名。</param>
        /// <param name="templateCode">短信模版编码。</param>
        /// <param name="templateParam">短信模版内容。</param>
        public SendSmsRequest(
            IJsonSerializer jsonSerializer,
            string phoneNumber,
            string signName,
            string templateCode,
            object templateParam) : this(phoneNumber, signName, templateCode, jsonSerializer.Serialize(templateParam))
        {
        }

        /// <summary>
        /// 向指定的号码发送短信。
        /// </summary>
        /// <param name="phoneNumber">手机号码。</param>
        /// <param name="signName">短信签名。</param>
        /// <param name="templateCode">短信模版编码。</param>
        /// <param name="templateParamJson">短信模版内容。</param>
        public SendSmsRequest(
            string phoneNumber,
            string signName,
            string templateCode,
            string templateParamJson) : this()
        {
            RequestParameters.Add("PhoneNumbers", phoneNumber);
            RequestParameters.Add("SignName", signName);
            RequestParameters.Add("TemplateCode", templateCode);
            RequestParameters.Add("TemplateParam", templateParamJson);
        }
    }
}