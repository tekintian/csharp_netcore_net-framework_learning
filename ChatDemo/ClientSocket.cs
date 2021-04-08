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
    public partial class ClientSocket : Form
    {
        //定义一个属性用于接收当前连接的socket的地址
        private Socket cSocket { get; set; }

        Thread thread=null;
        public ClientSocket()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //客户端连接服务端socket
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            cSocket = socket;

            //连接服务端
            try
            {
                socket.Connect(IPAddress.Parse(textBox_ip.Text), int.Parse(textBox_port.Text));
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败:"+ex.Message);
                return;
            }

            //发送消息, 接收消息
            thread = new Thread(new ParameterizedThreadStart(ReceiveData));
            thread.IsBackground = true;
            thread.Start(cSocket);

        }
        //发送消息
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (cSocket.Connected)
            {
                byte[] data = Encoding.Default.GetBytes(textBox_msg.Text);
                cSocket.Send(data,0,data.Length,SocketFlags.None);

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

                int len = 0;
                try
                {
                    //接收服务端发来的数据 实际接收的长度len
                    len = proxySocket.Receive(data, 0, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    //异常退出
                    AppendTxtToTxtLog($"\n\r服务端{client} 异常退出!");
                    StopConnectSocket();
                    return;
                }

                if (len <= 0)
                {
                    //服务端正常退出
                    AppendTxtToTxtLog($"\n\r服务端{client}正常退出");
                    StopConnectSocket(); //停止连接
                    return;//结束
                }

                //二进制字节数组转字符串
                string str = Encoding.Default.GetString(data, 0, len);

                //将字符串显示到日志中
                AppendTxtToTxtLog($"\n\r接收到{client}的数据:{str}");

            }
        }

        private void StopConnectSocket()
        {
            try
            {
                if (cSocket.Connected)
                {
                    cSocket.Shutdown(SocketShutdown.Both);
                    cSocket.Close(100);//超时时间关闭
                }
                //终止线程
                thread.Abort();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //将字符写入到text控件中
        private void AppendTxtToTxtLog(string txt)
        {
            if (textBox_log.InvokeRequired)
            {
                textBox_log.Invoke(new Action<string>(s => {
                    textBox_log.Text = textBox_log.Text + "\n\r" + s;
                }), txt);
            }
            else
            {
                textBox_log.Text = textBox_log.Text + "\n\r" + txt;
            }
        }
    }
}
