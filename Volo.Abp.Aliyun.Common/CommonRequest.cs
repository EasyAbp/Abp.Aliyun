using System.Collections.Generic;

namespace Volo.Abp.Aliyun.Common
{
    public abstract class CommonRequest : ICommonRequest
    {
        public SortedDictionary<string, string> Parameters { get; }

        public CommonRequest()
        {
            Parameters = new SortedDictionary<string, string>
            {
                
            };
        }
    }
}