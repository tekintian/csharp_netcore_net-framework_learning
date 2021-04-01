using System;

namespace ConsoleApp1
{
    public class SingletonClass2
    {
        private SingletonClass2()
        {
            // 构造函数
            Console.WriteLine("SingletonClass2 被创建了");
        }
        private static SingletonClass2 _instance;
        private static readonly Object syn = new object();//定义一个对象用于加锁
        public static SingletonClass2 CreateInstance()
        {
            //注意这里的双重if判断 来确保只能创建一次 且性能最优化
            if (null == _instance)
            {
                lock (syn)
                {
                    //在锁住后再判断是否需要创建,这样就确保只能创建一次
                    if (_instance == null)
                    {
                        _instance = new SingletonClass2();
                    }
                }
            }
            return _instance;
        }
        private int num = 0;
        public void SayHi()
        {
            Console.WriteLine("SayHi {0}", num++);
        }
    }
}
