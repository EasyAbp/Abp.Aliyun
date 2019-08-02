using System.Collections.Generic;

namespace Volo.Abp.Aliyun.Common
{
    public interface ICommonRequest
    {
        SortedDictionary<string,string> Parameters { get; }
    }
}