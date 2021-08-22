using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy tất cả thông tin
        /// </summary>
        /// <returns>Tất cả thông tin trong bảng</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Lấy thông tin theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>bản ghi có khóa chính đc cấp</returns>
        TEntity GetById(Guid entityId);
        /// <summary>
        /// lấy thông tin theo code
        /// </summary>
        /// <param name="entityCode">code của bản ghi</param>
        /// <returns>thông tin bản ghi </returns>
        TEntity GetByCode(string entityCode);
        /// <summary>
        /// thêm mới bản ghi vào bảng
        /// </summary>
        /// <param name="entity">bản ghi cần đc thêm mới</param>
        /// <returns>Số hàng bị ảnh hưởng trong db</returns>
        ServiceResult Add(TEntity entity);
        /// <summary>
        /// cập nhật thông tin bản ghi theo khóa chính
        /// </summary>
        /// <param name="entity">bản ghi cần update</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        ServiceResult Update(TEntity entity);
        /// <summary>
        /// xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi cần xóa</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        ServiceResult Delete(Guid entityId);
        /// <summary>
        /// validate dữ liệu chung
        /// </summary>
        /// <param name="entity">bản ghi cần validate</param>
        /// <returns>true: có lỗi, false: ko lỗi</returns>
        bool Validate(TEntity entity);

        /// <summary>
        /// validate theo từng bảng
        /// </summary>
        /// <param name="entity">bản ghi cần validate</param>
        /// <returns>false: có lỗi, true: ko lỗi</returns>
        bool validateCustom(TEntity entity);
    }
}
