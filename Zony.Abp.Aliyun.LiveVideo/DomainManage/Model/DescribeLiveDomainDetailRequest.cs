using System.Net.Http;
using Zony.Abp.Aliyun.Common.Model;

namespace Zony.Abp.Aliyun.LiveVideo.DomainManage.Model
{
    public class DescribeLiveDomainDetailRequest : CommonRequest
    {
        public DescribeLiveDomainDetailRequest()
        {
            RequestParameters["Action"] = "DescribeLiveDomainDetail";
            RequestParameters["Version"] = "2016-11-01";
            Method = HttpMethod.Get;
        }

        public DescribeLiveDomainDetailRequest(string domainName)
        {
            
        }
    }
}