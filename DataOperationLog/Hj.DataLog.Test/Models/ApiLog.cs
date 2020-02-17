using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hj.DataLog.Test.Models
{
    /// <summary>
    /// API访问日志
    /// </summary>
    public class ApiLog
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public int ALgID { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// 响应时间
        /// </summary>
        public long ResponseTime { get; set; }

        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime AccessTime { get; set; }

        /// <summary>
        /// 请求的URL
        /// </summary>
        public string AccessApiUrl { get; set; }

        /// <summary>
        /// HTTP的方法（GET\PUT\POST）
        /// </summary>
        public string AccessAction { get; set; }

        /// <summary>
        /// 请求Get的参数
        /// </summary>
        public string AccessParameterGet { get; set; }

        /// <summary>
        /// 请求POST的参数
        /// </summary>
        public string AccessParameterPost { get; set; }

        /// <summary>
        /// HTTP状态
        /// </summary>
        public int HttpStatus { get; set; }
    }
}
