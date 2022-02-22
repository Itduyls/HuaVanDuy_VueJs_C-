using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Interfaces.Infrastructures
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        /// Created by DuyHV (08/02/2022)
        IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Xóa 1 bản ghi theo Id
        /// </summary>
        /// <returns></returns>
        /// Created by DuyHV (08/02/2022)
        int Delete(Guid entityId);
        /// <summary>
        /// Lấy 1 bản ghi theo id
        /// </summary>
        /// <returns></returns>
        /// Created by DuyHV (08/02/2022)
        MISAEntity GetById(Guid EntityId);
        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by DuyHV (08/02/2022)
        int Insert(MISAEntity entity);
        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created by DuyHV (08/02/2022)
        int Update(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        /// <param name="entity"></param>
        /// Created by DuyHV (12/02/2022)
        public void CheckDuplicateCode(MISAEntity entity);
        /// <summary>
        /// Check Id nhập vào
        /// </summary>
        /// <param name="tbForeign"></param>
        /// <param name="id"></param>
        ///  Created by DuyHV (12/02/2022)
        public bool CheckKey(string tbForeign, Guid id);


    }
}
