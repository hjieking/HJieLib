using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hj.SqlSugarFactoryTest
{
    public class Department
    {
        /// <summary>
        /// 创建者Id
        /// </summary>
        public Guid? CreateId { get; set; }

        /// <summary>
        /// 创建者名称
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改者Id
        /// </summary>
        public Guid? ModifyId { get; set; }

        /// <summary>
        /// 修改者名称
        /// </summary>
        public string ModifyBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 假删除标识
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 树形结构数据表 Key   ID
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        /// 层次结构
        /// </summary>
        public string Hierarchy { get; set; }

        /// <summary>
        /// 标识  科室编码
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 名称  科室简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary> 
        /// 描述  科室全称
        /// </summary>
        public string FullName { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }


        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string USCC { get; set; }

        /// <summary>
        /// 组织类型
        /// </summary>
        public string OrgType { get; set; }

        /// <summary>
        /// 组织科室代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 办公地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// 科室职能
        /// </summary>
        public string OrgFunction { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
