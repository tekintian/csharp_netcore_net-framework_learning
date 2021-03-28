using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpNetCoreLearn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //页面初始化方法
        private void MainForm_Load(object sender, EventArgs e)
        {
            //特殊符号 $   @ 演示
            label2.Text = "$ - 字符串内插 C#6以后版本可用";
            string name = "Tekin";
            Console.WriteLine($"My name is {name}");// $ - 字符串内插 C#6以后版本可用
            label3.Text = $"My name is {name}";// $ -字符串内插 C#6以后版本可用

            label4.Text = "@ 逐字字符串标识符";
            label5.Text = @"\我直接输出 不转义字符串\ 如： c:\windows\system32\my.dll";
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
