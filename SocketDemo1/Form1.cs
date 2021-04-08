using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketDemo1
{
    public partial class Form1 : Form
    {
        private List<Socket> ClientProxySocketList = new List<Socket>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            StartSocketServer();
        }

        private void StartSocketServer()
        {
            //socket服务创建的逻辑
            //1. 创建socket对象
            Socket serverSocket = new Socket(
                AddressFamily.InterNetwork, //设置网络寻址协议
                SocketType.Stream,// 设置数据传输方式
                ProtocolType.Tcp // 通信协议
                );

            textBox_log.Text = "\r\n创建服务端Socket对象\r\n" + textBox_log.Text;
            
            //2.绑定IP和端口
            IPAddress ip = IPAddress.Parse(textBox_ip.Text.Trim());
            IPEndPoint iPEndPoint = new IPEndPoint(ip,int.Parse(textBox_port.Text));
            serverSocket.Bind(iPEndPoint);

            //3.开启监听 
            serverSocket.Listen(10);

            //使用线程池执行监听客户端连接
            ThreadPool.QueueUserWorkItem(MyAcceptClient, serverSocket);

            //ThreadPool.QueueUserWorkItem(new WaitCallback(this.MyAcceptClient), serverSocket);


            /*textBox_msg.Text = "\r\n开始接受客户端连接:" + textBox_msg.Text;
            //4.开始接受客户端连接  会阻塞当前线程,一直等待客户端连接
            Socket proxySocket = serverSocket.Accept();
            textBox_msg.Text = $"\r\n有客户端{proxySocket.RemoteEndPoint.ToString()}已连接:" + textBox_msg.Text;

            string str = DateTime.Now.ToString();
            byte[] data = Encoding.UTF8.GetBytes(str);

            //给客户端发生消息
            proxySocket.Send(data,0,data.Length,SocketFlags.None);

            //给对方发送一个关闭的信号
            proxySocket.Shutdown(SocketShutdown.Both);
            textBox_msg.Text = "\r\n关闭连接:" + textBox_msg.Text;
            proxySocket.Close();

            //关闭socket
            serverSocket.Close();*/
        }

        private void MyAcceptClient(object state)
        {
            var serverSocket = (Socket)state;
            while (true)
            {
                //接受客户端连接
                Socket proxySocket = serverSocket.Accept();

                //夸线程访问调用处理  根据要访问的控件判断是否需要Invoke
                if (textBox_log.InvokeRequired)
                {
                    textBox_log.Invoke(new Action(()=> {
                        textBox_log.Text = $"\r\n客户端{proxySocket.RemoteEndPoint.ToString()}已连接:" + textBox_log.Text;
                    }));
                }
                else
                {
                    textBox_log.Text = $"\r\n客户端{proxySocket.RemoteEndPoint.ToString()}已连接:" + textBox_log.Text;
                }
                
                ClientProxySocketList.Add(proxySocket);//将连接添加到集合

                //接收客户端消息
                ThreadPool.QueueUserWorkItem(ReceiveData, proxySocket);


            }
        }
        private void ReceiveData(object state) 
        {
            Socket proxySocket=(Socket)state;

            byte[] data = new byte[1024 * 1024];
            while (true)
            {
                int realLen = proxySocket.Receive(data, 0, data.Length, SocketFlags.None);
                if (realLen==0)
                {
                    proxySocket.Shutdown(SocketShutdown.Both);
                    proxySocket.Close();
                    ClientProxySocketList.Remove(proxySocket);
                    textBox_log.Text = $"客户端{proxySocket.RemoteEndPoint.ToString()} 已下线 \r\n" + textBox_log.Text;
                    return;
                }
                string fromClientMsg = Encoding.UTF8.GetString(data, 0, realLen);

                if (textBox_log.InvokeRequired)
                {
                    textBox_log.Invoke(new Action(()=> {
                        textBox_log.Text = $"接收到客户端{proxySocket.RemoteEndPoint.ToString()}的消息{fromClientMsg}\r\n" + textBox_log.Text;
                    }));
                }
                else
                {
                    textBox_log.Text = $"接收到客户端{proxySocket.RemoteEndPoint.ToString()}的消息{fromClientMsg}\r\n" + textBox_log.Text;
                }
                
            
            
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            BatchSend();
        }

        //群发消息
        public void BatchSend()
        {
            //群发消息
            foreach (var socket in ClientProxySocketList)
            {
                if (socket.Connected)
                {
                    string txt = textBox_msg.Text;
                    byte[] data = Encoding.UTF8.GetBytes(txt);

                    socket.Send(data, SocketFlags.None);
                }
                else
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    ClientProxySocketList.Remove(socket);//将他从list中移除
                }

            }
        }
    }
}
