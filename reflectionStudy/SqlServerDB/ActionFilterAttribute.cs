using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDB
{
    public class ActionFilterAttribute : Attribute
    {
        public void OnActionExecuted()
        {
            Console.WriteLine("执行OnActionExecuted！");
        }
    }
}
