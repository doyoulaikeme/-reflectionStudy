using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDB
{
    public class ReflectionDemo
    {
        public ReflectionDemo()
        {
            Console.WriteLine("{0}被构造  ", this.GetType());
        }

        public ReflectionDemo(int index)
        {
            Console.WriteLine("{0}有参int构造函数  参数值为：{1}", this.GetType(), index);
        }

        public ReflectionDemo(string text)
        {
            Console.WriteLine("{0}有参string构造函数  参数值为：{1}", this.GetType(), text);
        }

        /// <summary>
        /// 希望在构造对象时,能把依赖的东西自动创建。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="test"></param>
        public ReflectionDemo(SqlServerHelper helper, Test test)
        {
            Console.WriteLine("{0}有参SqlServerHelper、test构造函数  参数值为：{1} and {2}", this.GetType(), helper, test);
        }

        public void Show()
        {
            Console.WriteLine("{0}的无参Show", this.GetType());

        }

        public void Show(int index)
        {
            Console.WriteLine("{0}的有参int Show 参数值为：{1}", this.GetType(), index);

        }

        public void Show(string text)
        {
            Console.WriteLine("{0}的有参string Show 参数值为：{1}", this.GetType(), text);

        }

        public void Show(int index, string text)
        {
            Console.WriteLine("{0}的有参int string Show 参数值为：{1}", this.GetType(), text);

        }
        /// <summary>
        /// 添加特性测试
        /// </summary>
        [AuthorisizeFilter]
        [ActionFilter]
        public static void Show1()
        {
            Console.WriteLine("静态方法调用。");
        }
    }
}
