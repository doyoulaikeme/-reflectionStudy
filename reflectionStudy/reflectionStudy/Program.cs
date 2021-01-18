using DBInterface;
using SqlServerDB;
using OracleDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace reflectionStudy
{
    class Program
    {
        /// <summary>
        /// 反射是,NetFramework提供的一个类库
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            #region 反射基本使用
            //Console.WriteLine("********Reflection**********");
            //IDBHelper db = new SqlServerHelper();
            //db.Query();

            //var assembly = Assembly.Load("SqlServerDB");
            //foreach (var type in assembly.GetTypes())
            //{
            //    Console.WriteLine(type.Name);
            //    foreach (var method in type.GetMethods())
            //    {
            //        Console.WriteLine(method.Name);
            //    }
            //}
            #endregion

            #region 反射+实例化
            //Console.WriteLine("********Reflection+实例化**********");
            //var assembly = Assembly.Load("SqlserverDB");
            ////获取指定类库下的类路径   
            //var type = assembly.GetType("SqlServerDB.SqlServerHelper");
            ////通过Activator.CreateInstance实例化指定路径下的类
            //dynamic db = Activator.CreateInstance(type);
            ////db只能用dynamic动态获取，用object之类的强类型编译器无法识别。
            //db.Query();
            #endregion

            #region MyRegion
            Console.WriteLine("********封装反射调用**********");
            var db = Factory.CreateInstance();
            db.Query();
            #endregion
            Console.ReadKey();
        }
    }
}
