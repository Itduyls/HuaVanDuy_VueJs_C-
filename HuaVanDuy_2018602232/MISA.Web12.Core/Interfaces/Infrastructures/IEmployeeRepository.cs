using MISA.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Interfaces.Infrastructures
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {



        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        ///  Created by DuyHV (18/01/2022)
        object GetPaging(string searchText, int pageIndex, int pageSize);

      
        /// <summary>
        /// Tự động tăng mã nhân viên
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// Created by DUYHV 13/02/2022
        public string GetEmployeeCode();
    }
}
