using MISA.Web12.Core.Entities;
using MISA.Web12.Core.Interfaces.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;


namespace MISA.Web12.Infrastructure.Repository
{
    public class EmployeeRepository :BaseRepository<Employee>,IEmployeeRepository
    {



        /// <summary>
        /// Lấy bản ghi theo phân trang
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>danh sách bản ghi</returns>
        /// Created by DuyHV (12/02/2022)
        public object GetPaging(string searchText, int pageIndex, int pageSize)
        {

            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
               
                var sql = $"Proc_GetEmployeePaging";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@m_SearchText", searchText??"");
                parameters.Add("@m_PageIndex", pageIndex);
                parameters.Add("@m_PageSize", pageSize);
                parameters.Add("@m_TotalRecord", direction: System.Data.ParameterDirection.Output);

                var entites = SqlConnection.Query<Employee>(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                var totalRecord = parameters.Get<int>("@m_TotalRecord");

                return new
                {
                    Data = entites,
                    TotalRecord = totalRecord
                };
            }
        }

      
     
        public string GetEmployeeCode()
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sql = $"Proc_SetEmployeeCode";
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@m_EmployeeCode", direction: System.Data.ParameterDirection.Output);
                var entites = SqlConnection.Query<Employee>(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                var employeeCode = parameters.Get<string>("@m_EmployeeCode");

                return
                     employeeCode;
     
            }
          
        }
    }
}
