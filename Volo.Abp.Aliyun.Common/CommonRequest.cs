using System.Collections.Generic;

namespace Volo.Abp.Aliyun.Common
{
    public abstract class CommonRequest : ICommonRequest
    {
        public SortedDictionary<string, string> Parameters { get; }
    }
}