using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Enum
{
    public enum MISACode
    {
        IsValid = 100,
        NotValid = 900,
        Success = 200
    }

    public enum EntityStatus
    {
        Add = 1,
        Update = 2,
        Delete = 3,
    }
}
