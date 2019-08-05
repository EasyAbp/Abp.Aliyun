using System.Net.Http;
using Newtonsoft.Json;
using Volo.Abp.Aliyun.Common;

namespace Volo.Abp.Aliyun.Sms.Model.Request
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

        public SendSmsRequest(string phoneNumber,
            string signName,
            string templateCode,
            object templateParam) : this(phoneNumber,signName,templateCode,JsonConvert.SerializeObject(templateParam))
        {

        }
        
        public SendSmsRequest(string phoneNumber,
            string signName,
            string templateCode,
            string templateParamJson) : this()
        {
            RequestParameters.Add("PhoneNumbers",phoneNumber);
            RequestParameters.Add("SignName",signName);
            RequestParameters.Add("TemplateCode",templateCode);
            RequestParameters.Add("TemplateParam =",templateParamJson);
        }
    }
}