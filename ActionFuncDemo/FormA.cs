using System;
using System.Windows.Forms;

namespace ActionFuncDemo
{
    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormB fb = new FormB();
            fb.UpTxtEvent += UpdateText; // 将处理函数绑定到对象的事件委托上面
            fb._tag = textBox1.Text.Trim();//将当前输入框的值传递给FormB
            fb.Show();

        }
        // 带返回的处理函数
        private string UpdateText(string txt)
        {
            textBox1.Text = txt;
            return "设置成功!"; // 这里的返回值将返回给调用事件的委托对象
        }
    }
}
