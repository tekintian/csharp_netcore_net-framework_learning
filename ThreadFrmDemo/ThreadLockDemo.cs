using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadFrmDemo
{
    public partial class ThreadLockDemo : Form
    {
        public ThreadLockDemo()
        {
            InitializeComponent();
        }

        private void ThreadLockDemo_Load(object sender, EventArgs e)
        {
            MyMake();
          
        }

        private void MyMake()
        {
            #region 多线程锁
            //消费品对象
            List<MyProduct> products = new List<MyProduct>();
            int num = 0; //需要生产的产品数量

            bool isRunning = true;//控制线程退出的条件

            for (int i = 0; i < 5; i++)
            {
                //创建线程t
                Thread t = new Thread(() =>
                {
                    while (isRunning)
                    {
                       
                        //生产一个产品
                        if (num < 99)
                        {
                            //在生产时添加锁
                            lock (products)
                            {
                                products.Add(new MyProduct() { Id = num, Name = $"第{i}线程生产了第{num}个产品 线程ID:{Thread.CurrentThread.ManagedThreadId}" });
                                num++;
                                Console.WriteLine(products[num - 1].Name);
                            }
                        }
                        else
                        {
                            isRunning = false;//退出线程
                        }

                        //暂停500毫秒
                        Thread.Sleep(500);
                    }
                })
                {
                    IsBackground = true//设置线程为后台线程
                };
                t.Start();//启动线程
            }
            #endregion
        }
    }
}
