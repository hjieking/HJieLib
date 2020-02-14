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
        /// 功能模块（操作表名）
        /// </summary>
        public string KeyValue { get; set; }
        /// <summary>
        /// 修改前的值
        /// </summary>
        public string OldValue { get; set; }
        /// <summary>
        /// 修改后的值
        /// </summary>
        public string NewValue { get; set; }
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
        public string OperateTime { get; set; }
    }
}
