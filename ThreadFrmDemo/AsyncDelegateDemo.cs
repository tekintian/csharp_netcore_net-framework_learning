using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

namespace ThreadFrmDemo
{
    public partial class AsyncDelegateDemo : Form
    {
        public AsyncDelegateDemo()
        {
            InitializeComponent();
        }

        private void AsyncDelegateDemo_Load(object sender, EventArgs e)
        {
    //异步委托demo
    Console.WriteLine("当前主线程ID:"+Thread.CurrentThread.ManagedThreadId);

    //有参数有返回值 string的委托
    Func<int, int, string> delFunc = (a, b) => {
        Console.WriteLine("Delegate Thread:"+Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(1000);
        return $"{a}+{b}={a+b}";
    };

    //string str = delFunc(8,19);
    //Console.WriteLine(str);//
    #region 简单的异步委托
    //调用异步委托 内部原理:使用了一个线程池的线程去执行了委托指向的方法
    // delFunc.BeginInvoke(8,9,null,null);

    //拿到异步委托返回值
    IAsyncResult result = delFunc.BeginInvoke(8, 9, null, null);
    //if (result.IsCompleted)
    //{

    //}

    //EndInvoke 会阻塞当前线程 直到异步委托执行完成才会继续往下执行
    string retStr = delFunc.EndInvoke(result);

    Console.WriteLine(retStr);

    #endregion

    #region 有回调函数的异步委托
    //传递了一个参数 "aaa"
    delFunc.BeginInvoke(8, 9, MyAsyncCallBack, "aaa");

    //直接将委托对象传递进去
    delFunc.BeginInvoke(99,109,MyAsyncCallBackFunc, delFunc);

    #endregion


            Console.WriteLine("========end=======");
        }

        private void MyAsyncCallBackFunc(IAsyncResult ar)
        {
            //获取传递给委托的参数对象delFunc
            var delFunc = (Func<int,int,string>)ar.AsyncState;
            //获取委托的执行返回结果
            string str = delFunc.EndInvoke(ar);
            Console.WriteLine("MyAsyncCallBackFunc: "+str);
        }

        private void MyAsyncCallBack(IAsyncResult ar)
        {
            //拿到异步返回的结果
            // 这里的IAsyncResult是用于传参的接口类型 拿到结果需要将接口类型转换为实现的子类
           // AsyncResult synRet = ar as AsyncResult; //as转换 如果不成功则会返回null
            AsyncResult synRet =(AsyncResult)ar; //强转 如果不成功 抛出异常

            // 获取在其上调用的异步委托对象 并强转为调用的委托对象类型 Func<int,int,string>
            var del = (Func<int,int,string>)synRet.AsyncDelegate;

            //使用委托对象的EndInvoke获取返回值
            string strR = del.EndInvoke(synRet);
            Console.WriteLine(strR);

            // 拿到给回调函数的参数
           var state = ar.AsyncState;

            Console.WriteLine($"回调函数的线程id={Thread.CurrentThread.ManagedThreadId}  ar.AsyncState={state}"); ;
        }
    }
}
