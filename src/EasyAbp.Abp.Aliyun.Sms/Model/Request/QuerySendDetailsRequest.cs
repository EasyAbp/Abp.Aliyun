using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request
{
    public class QuerySendDetailsRequest : CommonRequest
    {
        public QuerySendDetailsRequest()
        {
            RequestParameters["Action"] = "QuerySendDetails";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        public QuerySendDetailsRequest(string phoneNumber,
            string sendDate,
            int pageSize,
            int currentPage) : this()
        {
            RequestParameters.Add("PhoneNumber",phoneNumber);
            RequestParameters.Add("SendDate",sendDate);
            RequestParameters.Add("PageSize",pageSize.ToString());
            RequestParameters.Add("CurrentPage",currentPage.ToString());
        }
    }
}