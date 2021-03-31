using System;
using System.Windows.Forms;

namespace ActionFuncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.SetForm1Text += UpdateTxt;
            f2._str = textBox1.Text.Trim();
            f2.Show();

        }
        //事件处理函数
        private void UpdateTxt(string txt)
        {
            textBox1.Text = txt;
        }
    }
}
