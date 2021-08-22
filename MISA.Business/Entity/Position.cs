using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    public class Position : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        public String PositionCode { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public String PositionName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        
    }
}
