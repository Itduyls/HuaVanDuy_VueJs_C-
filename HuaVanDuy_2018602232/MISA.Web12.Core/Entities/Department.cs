using MISA.Web12.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Entities
{
    public class Department
    {
        
        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// Created by DUYHV (12/02/2022)
        [PrimaryKey]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// Created by DUYHV (12/02/2022)
        [NotEmpty]
        [PropertyName("Id phòng ban")]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// Created by DUYHV (12/02/2022)
        public string DepartmentName { get; set; }

    }
}
