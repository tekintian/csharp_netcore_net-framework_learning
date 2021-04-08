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

namespace IISWebServerDemo
{
    public partial class MyServer : Form
    {
        public int onlineNum = 0; //当前在线人数
        private bool isOnline=false;//是否在线
        public MyServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MyConfigUtil.KeyExist("baseWebPath"))
            {
                //读取配置文件数据
                string baseWebPath = MyConfigUtil.Get("baseWebPath");
                textBox_basePath.Text = baseWebPath;
            }
           

        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_basePath.Text))
            {
                MessageBox.Show("请选择web服务器跟路径");
                return;
            }

            //socket服务创建的逻辑
            //1. 创建socket对象
            Socket serverSocket = new Socket(
                AddressFamily.InterNetwork, //设置网络寻址协议
                SocketType.Stream,// 设置数据传输方式
                ProtocolType.Tcp // 通信协议
                );

            textBox_log.Text = "\r\n服务启动成功\r\n" + textBox_log.Text;

            //2.绑定IP和端口
            IPAddress ip = IPAddress.Parse(textBox_ip.Text.Trim());
            IPEndPoint iPEndPoint = new IPEndPoint(ip, int.Parse(textBox_port.Text));
            serverSocket.Bind(iPEndPoint);

            //3.开启监听 
            serverSocket.Listen(10);

            //使用线程池执行监听客户端连接
            ThreadPool.QueueUserWorkItem(ProcessRequest, serverSocket);

            isOnline = true;
            server_status.Text = "web服务运行中";
            btn_start.Enabled = false;
        }
        private void ProcessRequest(object state)
        {
            Socket socket = state as Socket;
            while (true)
            {
                //接收用户请求
                var proxySocket = socket.Accept();
                onlineNum++;
                UpdateOnlineNum(onlineNum);

                //定义一个容器用于接收请求报文
                byte[] data = new byte[1024 * 1024 * 2];

                //获取请求的报文长度
                int len = proxySocket.Receive(data,0,data.Length,SocketFlags.None);

                string reqTxt = Encoding.Default.GetString(data);
                //解析 请求报文, 处理请求报文 返回相应的内容
                // MyHttpRequest request = new MyHttpRequest(reqTxt);

                MyHttpContext context = new MyHttpContext(reqTxt);
               
                MyHttpApplication application = new MyHttpApplication();
                application.ProcessRequest(context);

                proxySocket.Send(context.Response.GetResponseHeader());
                proxySocket.Send(context.Response.Body);

                proxySocket.Shutdown(SocketShutdown.Both);
                proxySocket.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FolderBrowserDialog path= new FolderBrowserDialog();
             DialogResult ret = path.ShowDialog();
            if (ret ==DialogResult.OK)
            {
                textBox_basePath.Text = path.SelectedPath;

                //保存配置文件
                MyConfigUtil.Save("baseWebPath", path.SelectedPath);
            }
           
        }

        //更新在线人数
        private void UpdateOnlineNum(int onlineNum)
        {
            if (textBox_log.InvokeRequired)
            {
                textBox_log.Invoke(new Action<int>(num => {
                    label_online.Text = $"当前在线{num}人";
                }), onlineNum);
            }
            else
            {
                label_online.Text = $"当前在线{onlineNum}人";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tekintian/");
        }
    }
}
