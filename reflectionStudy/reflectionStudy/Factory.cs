using DBInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reflectionStudy
{
    public class Factory
    {
        /// <summary>
        /// 获取config连接字符串
        /// </summary>
        private static readonly string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelper"];

        /// <summary>
        /// 封装数据操作类反射调用
        /// </summary>
        /// <returns></returns>
        public static IDBHelper CreateInstance()
        {
            var connStr = IDBHelperConfig.Split(',');
            var assembly = Assembly.Load(connStr[0]);
            //获取指定类库下的类路径   
            var type = assembly.GetType(connStr[1]);
            //通过Activator.CreateInstance实例化指定路径下的类
            var dbhelper = Activator.CreateInstance(type);
            IDBHelper db = (IDBHelper)dbhelper;
            return db;
        }
    }
}
