using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNFApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> strList = new List<string>() { "2","5","88","7"};

            //匿名函数
            // var tmp =strList.Where(delegate(string aa) { return aa.CompareTo("7") < 0; });
            //var tmp = strList.MyWhere(delegate (string aa) { return aa.CompareTo("7") <= 0; });

            //lambda表达式
            //var tmp = strList.MyWhere( (string aa)=> { return aa.CompareTo("7") <= 0; });
            //单个参数和一行代码 可用省略花括号
            var tmp = strList.MyWhere( aa => aa.CompareTo("7")<=0 );

            foreach (var item in tmp)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
