using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy tất cả thông tin
        /// </summary>
        /// <returns>Tất cả thông tin trong bảng</returns>
        public IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Lấy thông tin theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>bản ghi có khóa chính đc cấp</returns>
        public TEntity GetById(Guid entityId);
        /// <summary>
        /// lấy thông tin theo code
        /// </summary>
        /// <param name="entityCode">code của bản ghi</param>
        /// <returns>thông tin bản ghi </returns>
        public TEntity GetByCode(string entityCode);

        /// <summary>
        /// thêm mới bản ghi vào bảng
        /// </summary>
        /// <param name="entity">bản ghi cần đc thêm mới</param>
        /// <returns>Số hàng bị ảnh hưởng trong db</returns>
        public int Add(TEntity entity);

        /// <summary>
        /// cập nhật thông tin bản ghi theo khóa chính
        /// </summary>
        /// <param name="entity">bản ghi cần update</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        public int Update(TEntity entity);

        /// <summary>
        /// xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi cần xóa</param>
        /// <returns>số hàng bị ảnh hưởng trong db</returns>
        public int Delete(Guid entityId);

        /// <summary>
        /// lấy bản ghi theo các property của bảng
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <param name="property">các property</param>
        /// <returns></returns>
        TEntity GetEntityByProperty(TEntity entity, PropertyInfo property);
    }
}
