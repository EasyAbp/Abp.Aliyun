namespace Zony.Abp.Aliyun.Common.Model
{
    public abstract class CommonResponse : ICommonResponse
    {
        public string RequestId { get; protected set; }
    }
}