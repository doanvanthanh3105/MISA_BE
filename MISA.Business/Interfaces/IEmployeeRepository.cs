
using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// check code nhân viên đã bị trùng hay chưa
        /// </summary>
        /// <param name="employeeCode">code cần đc check</param>
        /// <returns>1:có trùng 0:Không trùng</returns>
        public int checkDuplicateCode(string employeeCode);

        /// <summary>
        /// lấy mã nhân viên mới
        /// </summary>
        /// <returns>mã nhân viên mới</returns>
        public string getNewEmployeeCode();

        /// <summary>
        /// phân trang và lọc dữ liệu
        /// </summary>
        /// <param name="pageIndex">trang số mấy</param>
        /// <param name="pageSize">kích thước trang</param>
        /// <param name="employeeFilter">dữ liệu lọc</param>
        /// <returns>một object gồm tổng bản ghi, tổng trang và các nhân viên trong trang đó</returns>
        public Object GetPagingAndFilter(int pageIndex, int pageSize, string employeeFilter);

        

        
    }
}
