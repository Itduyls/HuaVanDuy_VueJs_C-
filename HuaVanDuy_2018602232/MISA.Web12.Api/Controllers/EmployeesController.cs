using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web12.Core.Entities;
using MISA.Web12.Core.Exceptions;
using MISA.Web12.Core.Interfaces.Infrastructures;
using MISA.Web12.Core.Interfaces.Services;
using MISA.Web12.Core.Services;
using MISA.Web12.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Web12.Api.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : MISABaseController<Employee>
    {


        IEmployeeRepository _employeerepository;
        IEmployeeService _employeeservice;

        public EmployeesController(IEmployeeRepository employeeRepository, IEmployeeService employeeservice) : base(employeeservice, employeeRepository)
        {

            _employeerepository = employeeRepository;
            _employeeservice = employeeservice;
        }
        /// <summary>
        /// Lấy bản ghi theo tìm kiếm và phân trang trang
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by DuyHV (12/02/2022)
        [HttpGet("filter")]
        public IActionResult GetPaging(string? searchText, int pageIndex, int pageSize)
        {
            try
            {

                var res = _employeerepository.GetPaging(searchText, pageIndex, pageSize);

                return StatusCode(200, res);
            }
            catch (MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }



        }
        /// <summary>
        /// Lấy mã nhân viên cho thêm mới
        /// </summary>
        [HttpGet("EmployeeCode")]
        public IActionResult GetEmpCode()
        {
            try
            {

                var res = _employeerepository.GetEmployeeCode();

                return StatusCode(200, res);
            }
            catch (MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }



        }
    }
}
