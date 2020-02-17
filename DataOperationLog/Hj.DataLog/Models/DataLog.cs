using System;
using System.Collections.Generic;
using System.Text;

namespace Hj.DataLog.Models
{
    public class DataLog
    {
        public int? ID { get; set; }
        //ID  UserName  UserID  OpaerteTime  IsDel  DataJson   DataID
        public string UserID { get; set; }
        public string UserName { get; set; }
        public DateTime? OperateTime { get; set; }

        public string DataJson { get; set; }

        public string DataID { get; set; }

        public int? IsDel { get; set; }
    }
}
