using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatDemo
{
    public partial class MainForm : Form
    {
        List<Socket> ClientProxySocketList = new List<Socket>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

           

        }

        private void btn_start_Click(object sender, EventArgs e)
        {

            //1. 创建socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            //2. 绑定端口和IP
            socket.Bind(new IPEndPoint(IPAddress.Parse(textBox_ip.Text),int.Parse(textBox_port.Text)));

            //3.开启监听 
            socket.Listen(10); //连接等待队列大小, 即同时来了100个连接请求,系统只能处理1个,队列中放10个连接,其他的返回错误消息

            //4.开始接受客户端连接.  
            ThreadPool.QueueUserWorkItem(new WaitCallback(AcceptClientConnect),socket);
        }
        //接收客户端连接
        private void AcceptClientConnect(object state)
        {
            Socket socket = (Socket)state;
            AppendTxtToTxtLog("服务器端开始接受客户端消息:\r\n");
            while (true)
            {
                Socket proxySocket = socket.Accept();
                ClientProxySocketList.Add(proxySocket);
                AppendTxtToTxtLog($"客户端{proxySocket.RemoteEndPoint.ToString()}连接上了\r\n");
                
                //不停的接受当前连接的客户端发送来的消息 
                // proxySocket.Receive()会阻塞线程 所以需要放到线程池中去执行
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReceiveData), proxySocket);

            }

        }
        //接收客户端的数据
        private void ReceiveData(object obj)
        {
            var proxySocket = (Socket)obj;

            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                string client = proxySocket.RemoteEndPoint.ToString();

                int len=0;
                try
                {
                    //接收客户端发来的数据 实际接收的长度len
                    len = proxySocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    //异常退出
                    AppendTxtToTxtLog($"客户端{client} 异常退出!\r\n");
                    ClientProxySocketList.Remove(proxySocket);
                    StopConnect(proxySocket);
                    return;
                }

                if (len<=0)
                {
                    //客户端正常退出
                    AppendTxtToTxtLog($"客户端{client}正常退出\r\n");

                    ClientProxySocketList.Remove(proxySocket);
                    StopConnect(proxySocket);
                    return;//结束
                }

                //二进制字节数组转字符串
                string str =Encoding.Default.GetString(data,0,len);

                //将字符串显示到日志中
                AppendTxtToTxtLog($"接收到{client}的数据:{str}\r\n");
                
            }

        }

        private void StopConnect(Socket proxySocket)
        {
            try
            {
                if (proxySocket.Connected)
                {
                    proxySocket.Shutdown(SocketShutdown.Both);
                    proxySocket.Close(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("关闭连接异常"+ex.Message);
            }
        }

        //将字符写入到text控件中
        private void AppendTxtToTxtLog(string txt)
        {
            if (textBox_log.InvokeRequired)
            {
                textBox_log.Invoke(new Action<string>(s=> {
                    textBox_log.Text = textBox_log.Text + "\n\r"+ s;
                }),txt);
            }
            else
            {
                textBox_log.Text = textBox_log.Text + "\n\r" + txt;
            }
        }
        //群发
        private void btn_send_Click(object sender, EventArgs e)
        {
            foreach (var item in ClientProxySocketList)
            {
                if (item.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(textBox_msg.Text);
                    item.Send(data,0,data.Length,SocketFlags.None);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientSocket cs = new ClientSocket();
            cs.Show();
        }
    }
}
