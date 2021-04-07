using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormDemoNFApp1
{
    public partial class Form1 : Form
    {
        //定义一个用于存放子窗体的list集合, 所有需要订阅消息的子窗体都需要实现自定义的接口IChildFrm
        public List<IChildFrm> ChildFrmList = new List<IChildFrm>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //打开子窗体
            Form2 f2 = new Form2();
            f2.Show();
            ChildFrmList.Add(f2);


        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (ChildFrmList.Count==0)
            {
                return;
            }

            //循环给子窗体发布信息
            foreach (var item in ChildFrmList)
            {
                item.MySetText(textBox1.Text);
            }

        }
    }
}
