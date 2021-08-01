namespace EasyAbp.Abp.Aliyun.Sms.Model.Response.SmsSign
{
    public class QuerySmsSignResponse : SmsSignOperationResponse
    {
        /// <summary>
        /// 审核备注。<br/>
        /// 如果审核状态为审核通过或审核中，参数 Reason 显示为 “无审核备注”。<br/>
        /// 如果审核状态为审核未通过，参数 Reason 显示审核的具体原因。
        /// </summary>
        /// <example>示例值: 文件不能证明信息真实性，请重新上传。</example>
        public string Reason { get; set; }

        /// <summary>
        /// 签名审核状态。其中：<br/>
        /// 0: 审核中。<br/>
        /// 1: 审核通过。<br/>
        /// 2: 审核失败，请在返回参数Reason中查看审核失败原因。
        /// </summary>
        /// <example>示例值: 1 。</example>
        public int SignStatus { get; set; }
    }
}