using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    public class ServiceResult
    {
        
        public Object Data { get; set; }

        public string Msg { get; set; }

        public MISA.ApplicationCore.Enum.MISACode MISACode { get; set; }
    }
}
