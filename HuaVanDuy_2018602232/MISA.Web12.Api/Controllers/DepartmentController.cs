using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web12.Core.Entities;
using MISA.Web12.Core.Interfaces.Infrastructures;
using MISA.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Web12.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController :MISABaseController<Department>
    {
     
        public DepartmentController(IBaseService<Department> baseService, IBaseRepository<Department> baseRepository):base(baseService,baseRepository)
        {
           
        }
    }
}
