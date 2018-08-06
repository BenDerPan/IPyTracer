using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_example
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.Runtime.IO.RedirectToConsole();
            var paths = engine.GetSearchPaths();
            paths.Add(@"C:\Program Files\IronPython2\Lib");
            paths.Add(@"C:\Program Files\IronPython2\DLLs");
            //添加其他python库
            //...你的其他库路径
            engine.SetSearchPaths(paths);

            //直接执行py文件，并直接使用其中的类
            dynamic manPy = engine.ExecuteFile(@"man.py");
            //获取定义的类方法
            dynamic ping = manPy.Ping;
            var a = ping("1.2.3.1");

            Console.WriteLine(a);

            //构建类实例
            dynamic man = manPy.Man("BenDerPan", 27);
            //执行类方法
            var v = man.Add(777, 888);
            Console.WriteLine("777+888={0}", v);
            //执行类方法
            man.Say("Hello，World！");
            var o = man.obj;
            var members = o.get_members();
            var objValue = o.get_value();
            var t = objValue.GetType();
            var p = t.GetProperties();
            foreach (var mm in members)
            {
                Console.WriteLine("Name:{0}   Type:{1}    Value:{2}", mm.name, mm.type, mm.get_value());
            }
            Console.ReadLine();

            //======另外方式实现调用=============
            //构建上下文,用于初始化定义的变量，所有类型都可以看做变量，类也可以看做是Func<T,TResult>的方法变量
            ScriptScope scope = engine.CreateScope();
            var code = engine.CreateScriptSourceFromFile(@"man.py");
            //初始化scope
            code.Execute(scope);
            //查找类定义
            var manClass = scope.GetVariable<Func<object, object, object>>("Man");
            //初始化类对象
            dynamic m = manClass("Jack", 10);
            //调用类方法
            Console.WriteLine(m.Add(1, 3));
            m.Say("你好");

            Console.ReadLine();
        }
    }
}
