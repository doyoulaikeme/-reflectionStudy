using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDB
{
    /// <summary>
    /// 模拟特性
    /// </summary>
    public class AuthorisizeFilterAttribute : Attribute
    {
        public bool IsLogin()
        {
            return true;
        }
    }
}
