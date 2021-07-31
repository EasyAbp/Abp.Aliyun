namespace EasyAbp.Abp.Aliyun.Common.Model
{
    public abstract class CommonResponse : ICommonResponse
    {
        /// <summary>
        /// 请求 ID。
        /// </summary>
        /// <example>示例值: 819BE656-D2E0-4858-8B21-B2E477085AAF</example>
        public string RequestId { get; set; }

        /// <summary>
        /// 请求状态码。
        /// </summary>
        /// <example>示例值: OK。</example>
        /// <remarks>
        /// 返回OK代表请求成功。<br/>
        /// 其他错误码，请参见错误码列表(https://help.aliyun.com/document_detail/101346.htm?spm=a2c4g.11186623.2.8.31b5223fZQu1cZ)。
        /// </remarks>
        public string Code { get; set; }

        /// <summary>
        /// 状态码的描述。
        /// </summary>
        public string Message { get; set; }
    }
}