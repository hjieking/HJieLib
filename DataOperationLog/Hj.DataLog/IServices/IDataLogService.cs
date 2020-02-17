using System;
using System.Collections.Generic;
using System.Text;
using Hj.DataLog.Models;

namespace Hj.DataLog.IServices
{
    public interface IDataLogService
    {
        int Add(Models.DataLog dataLog);
    }
}
