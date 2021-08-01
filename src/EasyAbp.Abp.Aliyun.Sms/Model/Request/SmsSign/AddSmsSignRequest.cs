using System.Collections.Generic;
using System.Net.Http;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.Sms.Model.Request.SmsSign
{
    /// <summary>
    /// 用于申请短信签名的请求定义。<br/>
    /// 具体 API 说明信息，可以参考阿里云官方文档: https://help.aliyun.com/document_detail/121207.html。<br/>
    /// 您可以通过短信服务 AP 接口或短信服务控制台申请短信签名，签名需要符合个人用户签名规范或企业用户签名规范。<br/>
    /// 短信签名审核流程请参见签名审核流程。<br/>
    /// 个人用户每天最多可以申请一个短信签名，适用场景默认为 通用。企业用户每天最多可以申请100个签名。
    /// </summary>
    public class AddSmsSignRequest : CommonRequest
    {
        /// <summary>
        /// 构造一个新的 <see cref="AddSmsSignRequest"/> 对象。
        /// </summary>
        protected AddSmsSignRequest()
        {
            RequestParameters["Action"] = "AddSmsSign";
            RequestParameters["Version"] = "2017-05-25";
            Method = HttpMethod.Get;
        }

        /// <summary>
        /// 构造一个新的 <see cref="AddSmsSignRequest"/> 对象。
        /// </summary>
        /// <param name="signName">
        /// 签名名称。<br/>
        /// 签名必须符合 <c>个人用户签名规范</c> 或 <c>企业用户签名规范</c>。
        /// </param>
        /// <param name="signSource">
        /// 签名来源。取值：<br/>
        /// 0: 企事业单位的全称或简称。
        /// 1: 工信部备案网站的全称或简称。
        /// 2: App应用的全称或简称。
        /// 3: 公众号或小程序的全称或简称。
        /// 4: 电商平台店铺名的全称或简称。
        /// 5: 商标名的全称或简称。
        /// </param>
        /// <param name="remark">短信签名申请说明。请在申请说明中详细描述您的业务使用场景，申请工信部备案网站的全称或简称请在此处填写域名，长度不超过200个字符。</param>
        /// <param name="fileSuffix">
        /// 签名的证明文件格式，支持上传多张图片。当前支持JPG、PNG、GIF或JPEG格式的图片。<br/>
        /// 个别场景下，申请签名需要上传证明文件。详细说明请参见个人用户签名规范和企业用户签名规范。
        /// </param>
        /// <param name="fileContents">
        /// 签名的资质证明文件经base64编码后的字符串。图片不超过2 MB。<br/>
        /// 个别场景下，申请签名需要上传证明文件。详细说明请参见个人用户签名规范和企业用户签名规范。
        /// </param>
        public AddSmsSignRequest(string signName,
            int signSource,
            string remark,
            IEnumerable<string> fileSuffix,
            IEnumerable<string> fileContents) : this()
        {
            AddParameter("SignName", signName);
            AddParameter("SignSource", signSource.ToString());
            AddParameter("Remark", remark);

            var index = 1;
            foreach (var suffix in fileSuffix)
            {
                AddParameter($"SignFileList.{index}.FileSuffix", suffix);
                index++;
            }

            index = 0;
            foreach (var fileContent in fileContents)
            {
                AddParameter($"SignFileList.{index}.FileContents", fileContent);
                index++;
            }
        }
    }
}