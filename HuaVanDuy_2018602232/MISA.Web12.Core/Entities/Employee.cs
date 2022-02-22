using MISA.Web12.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// Created by DuyHV (13/1/2022)
    /// </summary>
    public class Employee
    {

        #region Constructor
        public Employee()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [NotEmpty]
        [PropertyName("Mã nhân viên")]
        public string? EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        [NotEmpty]
        [PropertyName("Tên nhân viên")]
        public string? FullName { get; set; }
        /// <summary>
        ///Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [Date]
        [PropertyName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [NotEmpty]
        [PropertyName("Id phòng ban")]
        [ForeignKey]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Số CMTND
        /// </summary>

        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
         [Date]
        [PropertyName("Ngày cấp")]
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        ///Nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }
        /// <summary>
        /// Vị trí làm việc
        /// </summary>
        public string? EmployeePosition { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Điện thoại cố định
        /// </summary>
        public string? TelephoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string? BankAccountNumber { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }
        /// <summary>
        /// Chi nhánh
        /// </summary>
        public string? BankProvinceName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [NotQuerry]
        public string? GenderName { get {
                switch (Gender)
                {
                    case (int?)Enum.Gender.Male:
                        return Core.Resources.ResourceVN.Gender_Male;
                    case (int?)Enum.Gender.Female:
                        return Core.Resources.ResourceVN.Gender_Female;
                    case (int?)Enum.Gender.Other:
                        return Core.Resources.ResourceVN.Gender_Other;
                    default:
                        return null;
                }
            }  }
        /// <summary>
        /// Mã đơn vị
        /// </summary>
        [NotQuerry]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên đơn vị
        /// </summary>
        [NotQuerry]
        public string DepartmentName { get; set; }


        #endregion

    }
}
