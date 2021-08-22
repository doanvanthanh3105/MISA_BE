using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entity
{
    public class Employee : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// 
        [PrimaryKey]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// 
        [CheckDuplicate]
        [Required]
        [DisplayName("Mã nhân viên")]
        [Maxlength(20, "Mã nhân viên không vượt quá 20 ký tự")]
        public string EmployeeCode { get; set; }
        

        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        /// 
        [Required]
        [DisplayName("Họ và tên")]
        public string EmployeeName { get; set; }
        
        
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }


        /// <summary>
        /// Khóa ngoại đến bảng department
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }


        /// <summary>
        /// chứng minh nhân dân
        /// </summary>
        [DisplayName("CMND")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Nơi cấp cmnd
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Ngày cấp cmnd
        /// </summary>
        public DateTime? IdentityDate { get; set; }


        /// <summary>
        /// chức danh
        /// </summary>
        public String EmployeePosition { get; set; }


        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// số tài khoản ngân hàng
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>

        public string BankName { get; set; }



        /// <summary>
        /// tên hãng ngân hàng
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// tên chi nhánh
        /// </summary>
        public string BankProvinceName { get; set; }


        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// 
       
        [DisplayName("Số điện thoại")]

        public string PhoneNumber { get; set; }

        /// <summary>
        /// số điện thoại cố định
        /// </summary>
        public string TelephoneNumber { get; set; }



        /// <summary>
        /// Email
        /// </summary>
        /// 
        
        [DisplayName("Email")]
        public string Email { get; set; }


        

        

        public string DepartmentName { get; set; }

        

        


        

        #endregion


        #region method



        #endregion
    }
}
