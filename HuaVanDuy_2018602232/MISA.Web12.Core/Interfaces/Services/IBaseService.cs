using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by DUHV (23/01/2022)
        int InsertService (MISAEntity entity);
        /// <summary>
        /// Sửa 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by DUHV (23/01/2022)
        int UpdateService(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by DUHV (23/01/2022)
        int DeleteService(Guid entityId);
    
    }
}
