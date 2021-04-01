using System;
using System.Windows.Forms;

namespace ActionFuncDemo
{
    public partial class Form2 : Form
    {
        public string _str = "";
        public Form2()
        {
            InitializeComponent();
        }
        //定义一个委托事件 Action为系统定义的委托 string为委托参数类型
        public event Action<string> SetForm1Text;
        private void button1_Click(object sender, EventArgs e)
        {
            SetForm1Text(textBox1.Text.Trim());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = _str;
        }
    }
}
