using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;

using MISA.ApplicationCore;

using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Enum;
using MISA.ApplicationCore.Entity;
using MISA.CukCuk.Web.Api;

namespace MISA.Api
{
    
    public class EmployeeController : BaseEntityController<Employee>
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("DuplicateCode")]
        public IActionResult checkDuplicateCode(string employeeCode)
        {
            try
            {
                var res = _employeeService.checkDuplicateCode(employeeCode);
                return Ok(res);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                
            }
        }

        [HttpGet("NewCode")]
        public IActionResult getNewEmployeeCode()
        {
            try
            {
                var res = _employeeService.GetNewEmployeeCode();
                return Ok(res);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                
            }
        }

        [HttpGet("EmployeeFilter")]
        public IActionResult getPagingAndFilter(int pageIndex, int pageSize, string employeeFilter = null)
        {
            try
            {
                var res = _employeeService.GetPagingAndFilter(pageIndex, pageSize, employeeFilter);
                return Ok(res);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

    }
}
