using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hj.SqlSugarFactory
{
    /// <summary>
    /// 数据日志
    /// </summary>
    public class DataLog
    {
        public Guid? ID { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 操作模型主键
        /// </summary>
        public string KeyValues { get; set; }
        /// <summary>
        /// 操作前模型值
        /// </summary>
        public string OldValues { get; set; }
        /// <summary>
        /// 操作后模型值
        /// </summary>
        public string NewValues { get; set; }
        /// <summary>
        /// 操作类型（insert、update、delete）
        /// </summary>
        public string OperateType { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// 操作人名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime { get; set; }
    }
}
