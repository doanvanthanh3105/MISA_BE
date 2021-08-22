using MISA.ApplicationCore.Const;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Enum;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {

        IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }




        #region Method

        public int checkDuplicateCode(string employeeCode)
        {
            return _employeeRepository.checkDuplicateCode(employeeCode);
        }

        public override bool validateCustom(Employee employee)
        {
            return true;
        }


        

        public override ServiceResult Delete(Guid EmployeeId)
        {
            ServiceResult serviceResult = new ServiceResult();


            var rowAffect = _employeeRepository.Delete(EmployeeId);

            if (rowAffect > 0)
            {
                serviceResult.MISACode = MISACode.IsValid;
                serviceResult.Msg = Properties.Resources.DeleteSuccess;
                serviceResult.Data = rowAffect;
                return serviceResult;
            }

            serviceResult.MISACode = MISACode.NotValid;
            serviceResult.Msg = Properties.Resources.DeleteNotSuccess;
            serviceResult.Data = rowAffect;
            return serviceResult;


            throw new NotImplementedException();
        }

        public string GetNewEmployeeCode()
        {
            return _employeeRepository.getNewEmployeeCode();
            
        }

        public object GetPagingAndFilter(int pageIndex, int pageSize, string employeeFilter)
        {
            return _employeeRepository.GetPagingAndFilter(pageIndex, pageSize, employeeFilter);
        }










        // xoa khach hang

        // sua thong tin khach hang

        #endregion
    }
}
