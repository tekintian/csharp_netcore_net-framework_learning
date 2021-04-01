using System;
using System.Windows.Forms;

namespace ActionFuncDemo
{
    public partial class FormB : Form
    {
        public string _tag = ""; //定义一个用于接收参数的属性
        public FormB()
        {
            InitializeComponent();
        }
        // @see https://docs.microsoft.com/zh-cn/dotnet/api/system.func-2?view=net-5.0
        //定义一个事件委托 Func表示的是有返回值的委托  Func<参数值的类型,out 返回值的类型>  
        public event Func<string, string> UpTxtEvent;

        private void button1_Click_1(object sender, EventArgs e)
        {
            //触发事件并接收返回值
            string retstr = UpTxtEvent(textBox1.Text.Trim());

            label2.Text = retstr;
        }

        private void FormB_Load(object sender, EventArgs e)
        {
            textBox1.Text = _tag;
        }
    }
}
