using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using MISA.AmisTCDN.Web12.Model;
using System.Data.SqlClient;

namespace MISA.AmisTCDN.Web12.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //1.Khai báo thông tin CSDL
            string conectionString = "Data Source=DuyHV;Initial Catalog=MISA_AMISFresher;Integrated Security=True";
            //2.Khởi tạo kết nối
            var sqlConection = new SqlConnection(conectionString);
            //3.Thực hiện truy vấn dữ liệu 
            var employees = sqlConection.Query<Employee>("SELECT * FROM Employee");
            //4.Trả dữ liệu về cho client

            return employees;
        }
     
    }
}
