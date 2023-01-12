using System.Collections.Generic;
using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;
using Volo.Abp.Json;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request
{
    public class SendBatchSmsRequest : CommonRequest
    {
        public SendBatchSmsRequest()
        {
            RequestParameters["Action"] = "SendBatchSms";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        public SendBatchSmsRequest(
            string phoneNumberJson,
            string signNameJson,
            string templateCode,
            string templateParamJson,
            string smsUpExtendCodeJson = null) : this()
        {
            AddParameter("PhoneNumberJson", phoneNumberJson);
            AddParameter("SignNameJson", signNameJson);
            AddParameter("TemplateCode", templateCode);
            AddParameter("TemplateParamJson", templateParamJson);
            AddParameter("SmsUpExtendCodeJson", smsUpExtendCodeJson);
        }

        public SendBatchSmsRequest(
            IJsonSerializer jsonSerializer,
            IEnumerable<string> phoneNumbers,
            IEnumerable<string> signNames,
            string templateCode,
            IEnumerable<object> templateParams,
            string smsUpExtendCodeJson = null) :
            this(
                jsonSerializer.Serialize(phoneNumbers),
                jsonSerializer.Serialize(signNames),
                templateCode,
                jsonSerializer.Serialize(templateParams),
                smsUpExtendCodeJson)
        {
        }
    }
}