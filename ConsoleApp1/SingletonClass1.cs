using System;

namespace ConsoleApp1
{
    public class SingletonClass1
    {
        //私有的构造函数 防止外部使用 new SingletonClass1()对其进行实例化
        private SingletonClass1()
        {
            Console.WriteLine("SingletonClass1 被构造了");
        }
        // 静态只读对象,只能创建一次
        private static readonly SingletonClass1 _instance = new SingletonClass1();
        //外部调用本实例的方法
        public static SingletonClass1 CreateInstance()
        {
            return _instance;
        }
    }
}
