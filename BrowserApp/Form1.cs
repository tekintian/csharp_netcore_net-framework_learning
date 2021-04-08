using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

private void button1_Click(object sender, EventArgs e)
{
    this.webBrowser1.Navigate(this.textBox_url.Text);
}

private void button2_Click(object sender, EventArgs e)
{
    var dom = webBrowser1.Document.GetElementsByTagName("button")[0];
    dom.SetAttribute("value","自动的Click");
    dom.InvokeMember("click");
}
//重写系统的ProcessCmdKey 方法实现窗体级别 捕获系统按键        //
protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) //激活回车键
        {
    int WM_KEYDOWN = 256;
    int WM_SYSKEYDOWN = 260;

    if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
    {
        switch (keyData)
        {
            //case Keys.Escape:
            //    this.Close();//关闭窗体
                    //    break;
            case Keys.Enter:
                button1_Click(null, null);
                break;
        }
    }
    return false;
}

    }
}
