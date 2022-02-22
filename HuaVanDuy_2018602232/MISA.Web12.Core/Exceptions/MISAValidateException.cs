using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web12.Core.Exceptions
{
    public class MISAValidateException:Exception
    {

     
        /// <summary>
        /// Ghi đè Message của Exception
        /// </summary>
        /// <param name="msg"></param>
        ///Created by DUYHV 11/02/2022
        public MISAValidateException(string msg) : base(msg)
        {
            

        }
      
    }
}
