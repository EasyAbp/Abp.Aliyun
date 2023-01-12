using System.Collections.Generic;
using System.Text.Json.Serialization;
using EasyAbp.Abp.Aliyun.Common.Model;
using Newtonsoft.Json;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Response
{
    public class QuerySendDetailsResponse : CommonResponse
    {
        /// <summary>
        /// 短信发送总条数。
        /// </summary>
        /// <example>示例值: 1 。</example>
        public int TotalCount { get; set; }

        /// <summary>
        /// 短信发送明细。
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public SmsSendDetailDTOs SmsSendDetailDTOs { get; set; }
    }

    // ReSharper disable once InconsistentNaming
    public class SmsSendDetailDTOs
    {
        [JsonPropertyName("SmsSendDetailDTO")]
        [JsonProperty("SmsSendDetailDTO")]
        public List<SmsSendDetailDto> Items { get; set; }
    }

    /// <summary>
    /// 短信发送明细。
    /// </summary>
    public class SmsSendDetailDto
    {
        /// <summary>
        /// 短信内容。
        /// </summary>
        /// <example>
        /// 示例值: 【阿里云】验证码为：123，您正在登录，若非本人操作，请勿泄露。
        /// </example>
        public string Content { get; set; }

        /// <summary>
        /// 运营商短信状态码。
        /// </summary>
        /// <remarks>
        /// 短信发送成功：DELIVERED。<br/>
        /// 短信发送失败：失败错误码请参见错误码(https://help.aliyun.com/document_detail/101347.htm?spm=a2c4g.11186623.2.9.31b5223fZQu1cZ)。
        /// </remarks>
        /// <example>示例值: DELIVERED</example>
        public string ErrCode { get; set; }

        /// <summary>
        /// 外部流水扩展字段。
        /// </summary>
        /// <example>示例值: 123 。</example>
        public string OutId { get; set; }

        /// <summary>
        /// 接收短信的手机号码。
        /// </summary>
        /// <example>示例值: 15200000000 。</example>
        public string PhoneNum { get; set; }

        /// <summary>
        /// 短信接收日期和时间。
        /// </summary>
        /// <example>示例值: 2019-01-08 16:44:13 。</example>
        public string ReceiveDate { get; set; }

        /// <summary>
        /// 短信发送日期和时间。
        /// </summary>
        /// <example></example>
        public string SendDate { get; set; }

        /// <summary>
        /// 短信发送状态，包括：<br/>
        /// 1: 等待回执。<br/>
        /// 2: 发送失败。<br/>
        /// 3: 发送成功。
        /// </summary>
        public int SendStatus { get; set; }

        /// <summary>
        /// 短信模板ID。
        /// </summary>
        public string TemplateCode { get; set; }
    }
}