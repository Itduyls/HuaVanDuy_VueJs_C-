using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AmisTCDN.Web12.Model
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
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Số CMTND
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Vị trí làm việc
        /// </summary>
        public string EmployeePosition { get; set; }
        #endregion
    }
}
