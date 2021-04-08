using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ThreadFrmDemo
{
    public partial class MainForm : Form
    {
        //用于控制线程的启动和停止的变量
        private bool isRunning=false;

        public MainForm()
        {
            InitializeComponent();

           // Control.CheckForIllegalCrossThreadCalls = false;//项目中不要使用这种方式

        }

        private void btn_loop_Click(object sender, EventArgs e)
        {
            isRunning = true; //用于控制进程的启动和停止的变量
            // 真正处理夸线程调用   btn_loop 为页面添加的按钮控件名称
            Thread thread = new Thread(() => {
                if (btn_loop.InvokeRequired)//如果是别的线程创建的此控件返回 true
                {
                    //Invoke的意思就是找到创建这个控件的线程,然后执行委托方法
                    btn_loop.Invoke(new Action<string>(ss => { this.btn_loop.Text = ss; }), DateTime.Now.ToString());
                }
                else
                {
                    this.btn_loop.Text = DateTime.Now.ToString();
                }


                while (isRunning)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(DateTime.Now.ToString());
                }
            });
            //设置线程为后台线程 ; 线程默认为前台线程
            thread.IsBackground = true;
            thread.Start();
            Console.WriteLine("当前线程ID:" + thread.ManagedThreadId);
        }

        private void btn_process_info_Click(object sender, EventArgs e)
        {
            //获取系统当前正在运行的所有进程
            var addProcess = System.Diagnostics.Process.GetProcesses();

            foreach (var item in addProcess)
            {
                Console.WriteLine($"name={item.ProcessName} id={item.Id}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            isRunning = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           

        }
    }
}
