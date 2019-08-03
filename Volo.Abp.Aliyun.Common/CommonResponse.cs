namespace Volo.Abp.Aliyun.Common
{
    public abstract class CommonResponse : ICommonResponse
    {
        public string RequestId { get; protected set; }
    }
}