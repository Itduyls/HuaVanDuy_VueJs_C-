using MISA.Web12.Core.Entities;
using MISA.Web12.Core.Exceptions;
using MISA.Web12.Core.Interfaces.Infrastructures;
using MISA.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Services
{
    public class EmployeeService :BaseService<Employee>, IEmployeeService
    {

        IEmployeeRepository _employeerepository;
        public EmployeeService(IEmployeeRepository employeerepository):base(employeerepository)
        {
            _employeerepository = employeerepository;
        }

    
    }
}
