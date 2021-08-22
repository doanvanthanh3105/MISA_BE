using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Enum;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.ApplicationCore.Entity;
using System.Reflection;
using MISA.ApplicationCore.Const;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class BaseEntityController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        IBaseService<TEntity> _baseService;
        string _tableName;

        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
            _tableName = typeof(TEntity).Name;
        }

        /// <summary>
        /// Lay tat ca bản ghi trong db
        /// </summary>
        /// <returns>các bản ghi của bảng</returns>
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var employees = _baseService.GetAll();
                return Ok(employees);
            }

            catch (Exception e)
            {
                var responseError = new ResponseError();
                responseError.DevMsg = e.Message;
                responseError.UserMsg = MISA.ApplicationCore.Properties.Resources.ServerError;
                responseError.ErrorCode = ErrorCode.ServerError;
                return StatusCode(500, responseError);
            }

        }



        /// <summary>
        /// lay mot bản ghi theo id
        /// </summary>
        /// <param name="id">khóa chính của bản ghi</param>
        /// <returns>bản ghi voi id dc truyen </returns>
        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {


            try
            {
                var employee = _baseService.GetById(id);
                if (employee != null)
                {
                    return Ok(employee);
                }

                return NoContent();
            }
            catch (Exception e)
            {

                var responseError = new ResponseError();
                responseError.DevMsg = e.Message;
                responseError.UserMsg = MISA.ApplicationCore.Properties.Resources.ServerError;
                responseError.ErrorCode = ErrorCode.ServerError;
                return StatusCode(500, responseError);
            }

        }

        /// <summary>
        /// thêm mới bản ghi vào db
        /// </summary>
        /// <param name="entity">bản ghi cần đc thêm mới</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {

            try
            {
                var res = _baseService.Add(entity);

                if (res.MISACode == MISACode.NotValid)
                {
                    return StatusCode(400, res);
                }

                if (res.MISACode == MISACode.IsValid && (int)res.Data > 0)
                {
                    return StatusCode(201, res);
                }
                else if ((int)res.Data == 0)
                {
                    return StatusCode(204);
                }
                else
                {
                    return StatusCode(400, res);
                }

            }
            catch (Exception e)
            {
                var responseError = new ResponseError();
                responseError.DevMsg = e.Message;
                responseError.UserMsg = MISA.ApplicationCore.Properties.Resources.ServerError;
                responseError.ErrorCode = ErrorCode.ServerError;
                return StatusCode(500, responseError);
            }

        }


        /// <summary>
        /// update bản ghi theo id
        /// </summary>
        /// <param name="id">khóa chính của bản ghi</param>
        /// <param name="entity">thông tin cần update</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        [HttpPut("{id}")]

        public IActionResult Put([FromRoute] Guid id, [FromBody] TEntity entity)
        {
            PropertyInfo property = entity.GetType().GetProperty($"{_tableName}Id");
            property.SetValue(entity, id);
            try
            {
                var res = _baseService.Update(entity);

                if (res.MISACode == MISACode.NotValid)
                {
                    return StatusCode(400, res);
                }

                if (res.MISACode == MISACode.IsValid && (int)res.Data > 0)
                {
                    return StatusCode(201, res);
                }
                else if ((int)res.Data == 0)
                {
                    return StatusCode(204);
                }
                else
                {
                    return StatusCode(400, res);
                }

            }
            catch (Exception e)
            {
                var responseError = new ResponseError();
                responseError.DevMsg = e.Message;
                responseError.UserMsg = MISA.ApplicationCore.Properties.Resources.ServerError;
                responseError.ErrorCode = ErrorCode.ServerError;
                return StatusCode(500, responseError);
            }

        }

        /// <summary>
        /// xóa bản ghi theo id
        /// </summary>
        /// <param name="id">khóa chính của bản ghi cần xóa</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                var res = _baseService.Delete(id);
                if((int)res.Data > 0)
                {
                    return Ok(res);
                }

                return StatusCode(204);
                
            }
            catch (Exception e)
            {
                var responseError = new ResponseError();
                responseError.DevMsg = e.Message;
                responseError.UserMsg = MISA.ApplicationCore.Properties.Resources.ServerError;
                responseError.ErrorCode = ErrorCode.ServerError;
                return StatusCode(500, responseError);
            }
            
        }
    }
}
