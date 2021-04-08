using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadFrmDemo
{
    public partial class ThreadPoolDemo : Form
    {
        public ThreadPoolDemo()
        {
            InitializeComponent();
        }

        private void ThreadPoolDemo_Load(object sender, EventArgs e)
        {
            //线程池使用
            //QueueUserWorkItem的第一个参数为回调函数,第二个参数为给回调函数传递参数的对象
            ThreadPool.QueueUserWorkItem((s)=> {
                Console.WriteLine(s);
            },"ssss");


            //手动创建线程和使用线程池新能测试
            //PeformanceTest();

            //获取最大可设置线程  当前设置的最大线程
            int numMax = 0,runNumMax = 0;
            ThreadPool.GetMaxThreads(out numMax, out runNumMax);

            Console.WriteLine($"最大可设置线程数={numMax},当前设置最大数={ runNumMax}");
            label1.Text = $"最大可设置线程数={numMax},当前设置最大数={ runNumMax}";

        }

        //手动创建线程和使用线程池新能测试
        private void PeformanceTest()
        {
            #region 手动创建线程和线程池新能对比
            //计时器对象创建
            Stopwatch sw = new Stopwatch();

            sw.Start(); //开始计时
            //测试开启1000个线程
            for (int i = 0; i < 1000; i++)
            {
                new Thread(()=> {
                    int num = 0;
                   // Console.WriteLine(++num);
                }).Start();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds); //用时:5464毫秒

            sw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                ThreadPool.QueueUserWorkItem((s)=> {
                    int num = 0;
                   // Console.WriteLine(++num);
                });
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);//用时:1毫秒

            #endregion
        }
    }
}
