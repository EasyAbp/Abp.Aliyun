using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.LiveVideo.DomainManage.Model
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