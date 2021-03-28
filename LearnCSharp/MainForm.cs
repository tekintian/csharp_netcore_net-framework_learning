﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
           
        }
    }
}
