using System;
using EasyAbp.Abp.Aliyun.Common.Model;

namespace EasyAbp.Abp.Aliyun.LiveVideo.DomainManage.Model
{
    public class DescribeLiveDomainDetailResponse : CommonResponse
    {
    }

    public class DomainDetail
    {
        /// <summary>
        /// 若开启 HTTPS，表示为证书名称。
        /// </summary>
        public string CertName { get; set; }

        /// <summary>
        /// 为直播域名生成一个 CNAME 域名，需要在域名解析服务商处将直播域名 CNAME 解析到该域名。
        /// </summary>
        public string Cname { get; set; }

        /// <summary>
        /// 域名备注，说明信息。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LiveDomainType { get; set; }

        /// <summary>
        /// 直播域名运行状态。取值可以参考：<see cref="DomainStatusConsts"/>。
        /// </summary>
        public string DomainStatus { get; set; }

        /// <summary>
        /// 直播域名。
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 最近修改时间。
        /// </summary>
        public DateTime GmtModified { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime GmtCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Scope { get; set; }
    }
}