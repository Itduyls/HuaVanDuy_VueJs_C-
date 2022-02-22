using Dapper;
using MISA.Web12.Core.Attributes;
using MISA.Web12.Core.Exceptions;
using MISA.Web12.Core.Interfaces.Infrastructures;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        protected readonly string ConnectionString = "Server = 13.229.200.157; Port = 3306;Database = MISA.WEB12.DUYHV;User Id = dev;Password = 12345678";
        protected MySqlConnection SqlConnection;

        public IEnumerable<MISAEntity> GetAll()
        {
            var name = typeof(MISAEntity).Name;
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var entites = SqlConnection.Query<MISAEntity>($"SELECT * FROM View_{name}");
                return entites;
            }
        }


        public int Delete(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            var check = CheckKey(className, entityId);
            if (check == true)
            {
                throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.CheckDeleteKey));
            }
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                //Khai báo truy vấn dữ liệu vào Database
                var sqlCommand = $"DELETE FROM {className} WHERE {className}Id=@EntityId";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EntityId", entityId);
                //Thực hiện thêm mới
                var res = SqlConnection.Execute(sqlCommand, param: dynamicParameters);
                return res;
            }
        }


        public MISAEntity GetById(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            var check = CheckKey(className, entityId);
            if (check == true)
            {
                throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.CheckDeleteKey));
            }
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id=@EntityId";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EntityId", entityId);
                //3. Thực hiện truy vấn dữ liệu trong Database
                var entity = SqlConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: dynamicParameters);
                return entity;
            }
        }

        public int Insert(MISAEntity entity)
        {

            //Build chuỗi câu sql thực hiện thêm mới dữ liệu
            var className = typeof(MISAEntity).Name;
            var sqlColumsNames = new StringBuilder();
            var sqlColumsValue = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();
            // Duyệt tất cả các property của đối tượng
            var props = typeof(MISAEntity).GetProperties();
            string delimiter = "";
            foreach (var prop in props)
            {
                // Lấy tên và value của prop
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                //Kiểm tra property có phải khóa chính không
                var primaryKey = Attribute.IsDefined(prop, typeof(PrimaryKey));
                if (primaryKey == true || propName == $"{className}Id")
                {
                    if (prop.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                    }
                }
                var notQuerry = Attribute.IsDefined(prop, typeof(NotQuerry));
                if (notQuerry == true)
                {
                    continue;
                }
                var paramName = $"@{propName}";
                sqlColumsNames.Append($"{delimiter}{propName}");
                sqlColumsValue.Append($"{delimiter}{paramName}");
                delimiter = ",";
                parameters.Add(paramName, propValue);

            }
            //Lấy giá trị của property
            //Thực hiện câu lệnh build SQL
            var sqlCommand = $"INSERT INTO {className}({sqlColumsNames.ToString()})" +
                $" VALUES({sqlColumsValue.ToString()})";
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var res = SqlConnection.Execute(sql: sqlCommand, param: parameters);
                return res;
            }


        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            //Build chuỗi câu sql thực hiện thêm mới dữ liệu
            var className = typeof(MISAEntity).Name;
            var sqlNamesAndValues = new StringBuilder();

            DynamicParameters parameters = new DynamicParameters();
            // Duyệt tất cả các property của đối tượng
            var props = typeof(MISAEntity).GetProperties();
            string delimiter = "";
            foreach (var prop in props)
            {
                // Lấy tên và value của prop
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                //Kiểm tra property có phải khóa chính không
                var primaryKey = Attribute.IsDefined(prop, typeof(PrimaryKey));
                if (primaryKey == true || propName == $"{className}Id")
                {
                    continue;
                }
                var notQuerry = Attribute.IsDefined(prop, typeof(NotQuerry));
                if (notQuerry == true)
                {
                    continue;
                }
                var paramName = $"@{propName}";
                sqlNamesAndValues.Append($"{delimiter}{propName}={paramName}");

                delimiter = ",";
                parameters.Add(paramName, propValue);

            }

            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                //Khai báo truy vấn dữ liệu vào Database
                var sqlCommand = $"UPDATE {className} SET {sqlNamesAndValues} WHERE {className}Id='{entityId}'";

                //Thực hiện sửa
                var res = SqlConnection.Execute(sqlCommand, param: parameters);
                return res;
            }
        }
        
        public void CheckDuplicateCode(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                ///1. Mã nhân viên không được trùng
                var sqlCheck = $"SELECT {className}Code FROM {className} WHERE {className}Code=@EntityCode";

                DynamicParameters dynamicParameters = new DynamicParameters();
                // Duyệt tất cả các property của đối tượng
                var props = typeof(MISAEntity).GetProperties();
                var nameDisplay = string.Empty;


                foreach (var prop in props)
                {
                    var propName = prop.Name;

                    var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                    if (propertyNames.Length > 0)
                    {
                        nameDisplay = (propertyNames[0] as PropertyName).Name;

                    }

                    if (propName == $"{className}Code")
                    {
                      
                        dynamicParameters.Add("@EntityCode", prop.GetValue(entity));
                        break;

                    }
                }
                   
                var res = SqlConnection.QueryFirstOrDefault<string>(sqlCheck, param: dynamicParameters);
                if (res != null)
                {
                    throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.EmployeeCode_NotDuplicate, nameDisplay));

                }
               
            }

        }

        public bool CheckKey(string tbForeign, Guid id)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sqlCommand = $"SELECT * FROM {tbForeign} WHERE {tbForeign}Id='{id}'";
              
                //3. Thực hiện truy vấn dữ liệu trong Database
                var entity = SqlConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand);
                if (entity == null)
                {
                    return true;
                }
                return false;
            }
        }
      



    }
}
