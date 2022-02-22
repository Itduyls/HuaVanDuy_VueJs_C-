using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web12.Core.Exceptions;
using MISA.Web12.Core.Interfaces.Infrastructures;
using MISA.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Web12.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MISABaseController<MISAEntity> : ControllerBase
    {
        #region Fields
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion
        #region Constructor
        public MISABaseController(IBaseService<MISAEntity> baseService,
        IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// Created by DuyHV (11/02/2022)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Thực hiện lấy dữ liệu
                var entities = _baseRepository.GetAll();

                return StatusCode(200, entities);
            }

            catch (Exception ex)
            {

                if (typeof(MISAValidateException).Name == ex.GetType().Name)
                {
                    var res = new
                    {
                        devMsg = ex.Message,
                        userMsg = ex.Message,
                        data = ex.Data,
                    };
                    return BadRequest(res);
                }
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
        /// Lấy 1 bản ghi theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by DuyHV (11/02/2022)
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            try
            {
                //Thực hiện lấy dữ liệu
                var data = _baseRepository.GetById(entityId);

                return StatusCode(200, data);
            }

            catch (Exception ex)
            {

                if (typeof(MISAValidateException).Name == ex.GetType().Name)
                {
                    var res = new
                    {
                        devMsg = ex.Message,
                        userMsg = ex.Message,
                        data = ex.Data,
                    };
                    return BadRequest(res);
                }
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
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by DuyHV (11/02/2022)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            try
            {
              
                var res = _baseService.InsertService(entity);

                return StatusCode(201, res);
            }

            catch (Exception ex)
            {

                if (typeof(MISAValidateException).Name == ex.GetType().Name)
                {
                    var res = new
                    {
                        devMsg = ex.Message,
                        userMsg = ex.Message,
                        data = ex.Data,
                    };
                    return BadRequest(res);
                }
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
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by DuyHV (11/02/2022)
        [HttpPut]
        public IActionResult Put(MISAEntity entity, Guid entityId)
        {
            try
            {

                var res = _baseService.UpdateService(entity, entityId);

                return StatusCode(200, res);
            }

            catch (Exception ex)
            {

                if (typeof(MISAValidateException).Name == ex.GetType().Name)
                {
                    var res = new
                    {
                        devMsg = ex.Message,
                        userMsg = ex.Message,
                        data = ex.Data,
                    };
                    return BadRequest(res);
                }
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
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// Created by DuyHV (11/02/2022)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {


            try
            {

                var res = _baseService.DeleteService(entityId);

                return StatusCode(200, res);
            }

        
            catch (Exception ex)
            {
                
                if (typeof(MISAValidateException).Name == ex.GetType().Name)
                {
                     var res = new
                    {
                        devMsg = ex.Message,
                        userMsg = ex.Message,
                        data = ex.Data,
                    };
                    return BadRequest(res);
                }
               var  response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }

        }
       


        
        #endregion


    }
}
