using MISA.Web12.Core.Attributes;
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
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {

        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int InsertService(MISAEntity entity)
        {

            //validate dữ liệu:
            ValidateData(entity);
            CheckForeignKey(entity);
            var res = _baseRepository.Insert(entity);
            return res;
        }

        public int UpdateService(MISAEntity entity, Guid entityId)
        {
            //Check khóa ngoại của bảng
            CheckForeignKey(entity);
            var res = _baseRepository.Update(entity, entityId);
            return res;
        }
        public int DeleteService(Guid entityId)
        {

         
            var res = _baseRepository.Delete(entityId);
            return res;
        }
        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        /// <param name="entity"></param>
        /// Created by DUYHV 13/02/2022
        private void ValidateData(MISAEntity entity)
        {
            //Kiểm tra trùng mã 
            _baseRepository.CheckDuplicateCode(entity);


           
            var propsNotEmpties = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(NotEmpty)));
            //Kiểm tra dữ liệu trống
            foreach (var prop in propsNotEmpties)
            {
                
                var propValue = prop.GetValue(entity);
                var nameDisplay = string.Empty;
                var propName = prop.Name;
                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as PropertyName).Name;
           
                }

             
                if (propValue == null || string.IsNullOrEmpty(propValue.ToString()))
                {
                    nameDisplay = (nameDisplay == string.Empty ? propName : nameDisplay);

                    throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.InforNotEmpty,nameDisplay));
                }
            }

            var propsDateTimes = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(Date)));
            //Kiểm tra ngày nhập có lớn hơn ngày hiện tại
            foreach (var prop in propsDateTimes)
            {

                var propValue = prop.GetValue(entity);
                var nameDisplay = string.Empty;
                var propName = prop.Name;
                var dateNow = DateTime.Now;
                if (propValue == null)
                {
                    continue;
                }
                int result = DateTime.Compare((DateTime)propValue, dateNow);
                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as PropertyName).Name;

                }


                if (result > 0)
                {
                    nameDisplay = (nameDisplay == string.Empty ? propName : nameDisplay);
                    throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.checkDateTime, nameDisplay));
                }
            }
          


        }
        private void CheckForeignKey(MISAEntity entity)
        {
            //Kiểm tra id khóa ngoại nhập vào
            var propsForeignKeys = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(ForeignKey)));
            foreach (var prop in propsForeignKeys)
            {

                var propValue = prop.GetValue(entity);


                var nameDisplay = string.Empty;
                var propName = prop.Name.Remove(prop.Name.Length - 2);




                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as PropertyName).Name;

                }
                
                var check =_baseRepository.CheckKey(propName, (Guid)propValue);
                if (check==true)
                {
                    throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.CheckForeignKey, nameDisplay));
                }
            }
        }

    }
}
