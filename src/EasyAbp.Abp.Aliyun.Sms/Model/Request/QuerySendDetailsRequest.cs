using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request
{
    public class QuerySendDetailsRequest : CommonRequest
    {
        private QuerySendDetailsRequest()
        {
            RequestParameters["Action"] = "QuerySendDetails";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 调用 QuerySendDetails 接口，查看短信发送记录和发送状态。
        /// </summary>
        /// <remarks>
        /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/102352.html。<br/>
        /// 可以根据短信发送日期查看发送记录和短信内容，也可以添加发送流水号，根据流水号查询指定日期指定请求的发送详情。<br/>
        /// 如果指定日期短信发送量较大，可以分页查看。指定每页显示的短信详情数量和查看的页数，即可分页查看发送记录。
        /// </remarks>
        /// <param name="phoneNumber">
        /// 接收短信的手机号码。<br/>
        /// 格式:<br/>
        /// 国内短信：11位手机号码，例如1590000****。<br/>
        /// 国际/港澳台消息：国际区号+号码，例如8520000****。
        /// </param>
        /// <param name="sendDate">
        /// 短信发送日期，支持查询最近30天的记录。<br/>
        /// 格式为 yyyyMMdd，例如 20181225。
        /// </param>
        /// <param name="pageSize">
        /// 分页查看发送记录，指定每页显示的短信记录数量。<br/>
        /// 取值范围为1~50。
        /// </param>
        /// <param name="currentPage">分页查看发送记录，指定发送记录的当前页码。</param>
        /// <param name="bizId">
        /// 发送回执ID，即发送流水号。<br/>
        /// 调用发送接口 SendSms 或 SendBatchSms 发送短信时，返回值中的 BizId 字段。
        /// </param>
        public QuerySendDetailsRequest(string phoneNumber,
            string sendDate,
            int pageSize,
            int currentPage,
            string bizId = null) : this()
        {
            AddParameter("PhoneNumber",phoneNumber);
            AddParameter("SendDate",sendDate);
            AddParameter("PageSize",pageSize.ToString());
            AddParameter("CurrentPage",currentPage.ToString());
            AddParameter("BizId",bizId);
        }
    }
}