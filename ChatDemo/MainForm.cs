using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        private void AcceptClientConnect(object state)
        {
            Socket socket = (Socket)state;
            while (true)
            {
                Socket proxySocket = socket.Accept();
                ClientProxySocketList.Add(proxySocket);
            }
           
        }

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
    }
}
