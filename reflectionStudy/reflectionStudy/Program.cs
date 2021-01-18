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
        /// 优点：动态、配置，可扩展。
        /// 缺点：编写麻烦、避开了编译器检查、性能问题。
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

            #region 封装反射调用,配置不同参数调用不同对象。
            //Console.WriteLine("********封装反射调用**********");
            //var db = Factory.CreateInstance();
            //db.Query();
            #endregion

            #region 反射性能优化
            Console.WriteLine("********反射性能优化**********");
            ///反射性能优化：
            /// 1.缓存重用（例如：MVC ORM都是启动时完成缓存）。
            /// 2.dynamic 直接使用方法或熟悉。
            /// 3.委托
            /// 4.emit
            Monitor.Show();

            #endregion

            #region 反射调用有参函数
            //Console.WriteLine("********反射调用有参函数**********");
            //var assembly = Assembly.Load("SqlserverDB");
            ////获取指定类库下的类路径   
            //var type = assembly.GetType("SqlServerDB.ReflectionDemo");

            ////获取所有公开的构造函数
            //foreach (var ctor in type.GetConstructors())
            //{
            //    Console.WriteLine("构造函数名称：{0}", ctor.GetType().Name);

            //    foreach (var para in ctor.GetParameters())
            //    {
            //        Console.WriteLine("构造函数参数名称：{0},参数类型：{1}", para.Name, para.ParameterType);
            //    }
            //}
            ////基于反射可以找到对象的全部构造函数，包括函数的参数列表及类型，
            ////能够调用不同的构造函数，可以传递参数。
            //var model = Activator.CreateInstance(type);
            //var model1 = Activator.CreateInstance(type, new object[] { 1 });
            //var model2 = Activator.CreateInstance(type, new object[] { "字符串传参测试" });

            ////利用MethodInfo且传new Type[]调用方法
            ////如果没有new Type[]会出错。
            ////调用无参方法
            //MethodInfo mt = type.GetMethod("Show", new Type[] { });
            //mt.Invoke(model, null);

            ////调用有参int方法
            //MethodInfo mt1 = type.GetMethod("Show", new Type[] { typeof(int) });
            //mt1.Invoke(model, new object[] { 1 });

            ////调用有参string方法
            //MethodInfo mt2 = type.GetMethod("Show", new Type[] { typeof(string) });
            //mt2.Invoke(model, new object[] { "测试字符串有参" });
            #endregion

            #region IOC DI 核心原理
            ////IOC(控制反转) 为了让项目去除依赖，可以让上端只依赖抽象（接口），
            ////容器负责对象化实例，但是实例化对象经常会出现对象依赖，
            ////所以就需要能自动去构造其他对象且传入（DI依赖倒置）
            //Console.WriteLine("********IOC DI**********");
            //var assembly = Assembly.Load("SqlserverDB");
            ////获取指定类库下的类路径   
            //var type = assembly.GetType("SqlServerDB.ReflectionDemo");


            ////在构造A对象时，能够把A依赖的其他对象给自动创建并传入。
            ////递归一下该方法能够把所有依赖都能自动创建。
            ////IOC最核心的DI(依赖注入或者叫构造函数注入)就是这样实现的。
            ////类似的属性注入，字段注入、方法注入都是这种方式。

            ////获取公共构造函数参数最多的一个
            //var constructor = type.GetConstructors().OrderByDescending(p => p.GetParameters().Length).FirstOrDefault();
            //var olist = new List<object>();
            ////遍历参数
            //foreach (var param in constructor.GetParameters())
            //{
            //    //获取参数类型
            //    var paramType = param.ParameterType;
            //    //参数实例化
            //    var paramModel = Activator.CreateInstance(paramType);
            //    olist.Add(paramModel);
            //}

            ////实例化对象并传参
            //var model = Activator.CreateInstance(type, olist.ToArray());

            #endregion

            #region 反射MVC应用案例

            //MVC显然也是靠反射--反射创建控制器实例--反射找到方法--再从参数列表url、form和路由参数去找对应的方法。
            //重载int string / string int 如何识别？必须要用httpMethod(httpGet HttpPost之类的标识)。
            Console.WriteLine("*******MVC原理解析***********");
            var assembly = Assembly.Load("SqlserverDB");
            //获取指定类库下的类路径   
            var type = assembly.GetType("SqlServerDB.ReflectionDemo");
            //通过Activator.CreateInstance实例化指定路径下的类
            var db = Activator.CreateInstance(type);
            //利用MethodInfo且传new Type[]调用方法
            //如果没有new Type[]会出错。
            //调用无参方法
            MethodInfo mt = type.GetMethod("Show", new Type[] { });
            mt.Invoke(db, null);

            //调用有参int方法
            MethodInfo mt1 = type.GetMethod("Show", new Type[] { typeof(int) });
            mt1.Invoke(db, new object[] { 1 });

            //调用有参string方法
            MethodInfo mt2 = type.GetMethod("Show", new Type[] { typeof(string) });
            mt2.Invoke(db, new object[] { "测试字符串有参" });

            //调用有参int string方法
            MethodInfo mt3 = type.GetMethod("Show", new Type[] { typeof(int), typeof(string) });
            mt3.Invoke(db, new object[] { 1, "测试字符串有参" });

            MethodInfo mt4 = type.GetMethod("Show1");

            Console.WriteLine("*************特性内部原理********");
            //mvc框架通过反射调用方法，Filter是特性，
            //实际上就是通过反射调用方法前后，加入特性检测，
            //执行对应的逻辑，就实现了AOP。
            //判断是否有特性标识
            if (mt4.IsDefined(typeof(AuthorisizeFilterAttribute), true))
            {
                //找到该特性
                AuthorisizeFilterAttribute authorisize = mt4.GetCustomAttribute<AuthorisizeFilterAttribute>();
                //判断是否登录
                if (authorisize.IsLogin())
                {
                    //执行完操作后
                    mt4.Invoke(db, null);
                    //再判断是不是有标记AuthorisizeFilterAttribute
                    if (mt4.IsDefined(typeof(ActionFilterAttribute), true))
                    {
                        //有的话就执行一下内部的方法
                        ActionFilterAttribute action = mt4.GetCustomAttribute<ActionFilterAttribute>();
                        action.OnActionExecuted();
                    }

                }
                else
                {
                    Console.WriteLine("用户没有登录！");

                }
            }
            else
            {
                mt4.Invoke(db, null);
            }


            mt4.Invoke(null, null);


            #endregion

            Console.ReadKey();
        }
    }
}
