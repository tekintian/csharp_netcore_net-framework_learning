using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "select name from tb_area";
            object obj = TekinMssqlHelperNF.SqlHelper.ExecuteScalar(sql);
            Console.WriteLine(obj);



            // 不能创建实例 应为默认的构造函数被私有化了
            // SingletonClass1 sgt1 = new SingletonClass1();

            //不管你调用几次,都只能创建一个对象
            /* SingletonClass1 sgt1 = SingletonClass1.CreateInstance();
             SingletonClass1 sgt2 = SingletonClass1.CreateInstance();
             SingletonClass1 sgt3 = SingletonClass1.CreateInstance();*/

            /*  //使用循环创建多个线程来测试
              for (int i = 0; i < 1000; i++)
              {
                  //创建一个线程
                  Thread t1 = new Thread(new ThreadStart(()=> {
                      SingletonClass1 sgt = SingletonClass1.CreateInstance();
                  }));
                  t1.Start();
              }*/

            for (int i = 0; i < 10; i++)
            {
                //创建线程
                Thread t2 = new Thread(new ThreadStart(() => { 
                    SingletonClass2 sgt2 = SingletonClass2.CreateInstance();
                    sgt2.SayHi();
                }));
                t2.Start();//启动线程
            }
            string txt = "123";
            //调用自定义的类库
            string cipher = TekinTianLibrary.security.MyHash.GetHash(txt);

            Console.WriteLine($" {txt}加密后的字符串为{cipher}");

            Console.WriteLine("OK");

            Console.ReadKey();
        }
    }
}
