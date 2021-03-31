using System;
using System.Runtime.Serialization;

namespace LearnNF
{
    //自定义异常类
    // @see https://docs.microsoft.com/zh-cn/dotnet/api/system.exception?view=net-5.0#Custom
    class MyException :Exception
    {
        //它使用默认值来初始化新异常对象的属性。
        public MyException() { }
        
        //它使用指定的错误消息初始化新的异常对象。
        public MyException(string message):base(message) { }

        //它使用指定的错误消息和内部异常初始化新的异常对象。
        public MyException(string message, Exception inner) : base(message, inner) { }
        
        //它是 protected 从序列化数据中初始化新异常对象的构造函数。 如果已选择使异常对象可序列化，则应实现此构造函数。
        protected extern MyException(SerializationInfo info, StreamingContext context);
    
    }
}
