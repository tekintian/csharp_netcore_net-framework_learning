using LearnCSharp.security;
using System;
using System.Windows.Forms;

namespace LearnCSharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //弹出窗体和判断窗体返回类型
        private void button1_Click(object sender, EventArgs e)
        {
            BaseForm1 baseForm1 = new BaseForm1();
           DialogResult ret =  baseForm1.ShowDialog(this);
           if (ret == DialogResult.OK)
            {
                MessageBox.Show("你点击了窗体中的Ok");
            }
           else if (ret == DialogResult.No)
            {
                MessageBox.Show("你点击了 No ");
            }
           else if (ret == DialogResult.Cancel)
           {
               MessageBox.Show("你点击了Cancel");
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConvertTools cts = new ConvertTools();
            cts.ShowDialog();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string name = "Tekin";
            Console.WriteLine($"你的名称是{name} 算术运算:{2*90/8}");
            textBox1.Text = $"你的名称是{name} 算术运算:{2 * 90 / 8}";

            comboBox1.SelectedIndex = 1;//默认SHA256加密

            // 递归演示
           other.RecursionDemo.demo();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            string salt = textBox_salt.Text.Trim().Length > 0 ? textBox_salt.Text.Trim() :"";
            int repeatNum = textBox_repeatNum.Text.Trim().Length > 0 ? Convert.ToInt32(textBox_repeatNum.Text.Trim()) : 1;
            string type = comboBox1.SelectedItem.ToString();

            string cipherTxt = MyHash.GetHash(txt, type, salt, repeatNum);
  
            textBox2.Text = cipherTxt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text.Trim();
            string pinyin =  TinyPinyin.PinyinHelper.GetPinyin(txt, "");
            textBox2.Text = pinyin.ToLower();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TreeViewForm1 tvf = new TreeViewForm1();
            tvf.Show();
        }
    }
}
