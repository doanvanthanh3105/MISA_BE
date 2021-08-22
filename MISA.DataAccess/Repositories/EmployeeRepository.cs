using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int checkDuplicateCode(string employeeCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeCode", employeeCode);
            var res = _dbConnection.QueryFirstOrDefault<int>($"Proc_CheckEmployeeCodeExits", param: parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public string getNewEmployeeCode()
        {
            var res = _dbConnection.QueryFirstOrDefault<String>($"Proc_GetNewEmployeeCode", commandType: CommandType.StoredProcedure);
            return res;
        }

        public Object GetPagingAndFilter(int pageIndex, int pageSize, string employeeFilter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@EmployeeFilter", employeeFilter);
            parameters.Add("@TotalRecord", direction: ParameterDirection.Output);
            parameters.Add("@TotalPage", direction: ParameterDirection.Output);
            var res = _dbConnection.Query<Employee>($"Proc_GetEmployeesFilterPaging", param: parameters, commandType: CommandType.StoredProcedure);

            var totalRecord = parameters.Get<int>("TotalRecord");
            var totalPage = parameters.Get<int>("TotalPage");

            var result = new
            {
                data = res,
                totalRecord = totalRecord,
                totalPage = totalPage
            };

            return result;
        }
    }
}
