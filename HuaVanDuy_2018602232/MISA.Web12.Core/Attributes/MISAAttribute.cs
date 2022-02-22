using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Attributes
{
    /// <summary>
    /// Attribute không để trống
    /// </summary>
    /// <returns></returns>
    /// Created by DuyHV (11/02/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty:Attribute
    {
    }
    /// <summary>
    /// Attribute Khóa chính
    /// </summary>
    /// <returns></returns>
    /// Created by DuyHV (11/02/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
    }
    /// <summary>
    /// Attribute tên thuộc tính
    /// </summary>
    /// <returns></returns>
    /// Created by DuyHV (11/02/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyName : Attribute
    {
        public string Name = string.Empty;
        public PropertyName(string name)
        {
            Name = name;
        }
    }
    /// <summary>
    /// Attribute không thêm vào querry
    /// </summary>
    /// <returns></returns>
    /// Created by DuyHV (11/02/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class NotQuerry : Attribute
    {
    }
    /// <summary>
    /// Attribute Ngày tháng năm
    /// </summary>
    /// <returns></returns>
    /// Created by DuyHV (11/02/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class Date : Attribute
    {
    }
    /// <summary>
    /// Attribute Khóa ngoại
    /// </summary>
    /// <returns></returns>
    /// Created by DuyHV (11/02/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKey : Attribute
    {
    }
}
