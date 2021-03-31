using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnNF
{
    public partial class ConvertTools : Form
    {
        public ConvertTools()
        {
            InitializeComponent();
        }

        private void btn_transform_Click(object sender, EventArgs e)
        {
            doTransform();
        }
        private void doTransform(){
            if (cbox_from.SelectedIndex != 3)//判断用户输入是否为十六进制数
            {
                long P_lint_value;//定义长整型变量
                if (long.TryParse(txt_value.Text, out P_lint_value))//判断输入数值是否正确并赋值
                {
                    if (cbox_from.SelectedIndex == 0)//判断用户输入的是否为十进制数
                    {
                        switch (cbox_to.SelectedIndex)
                        {
                            case 0:
                                txt_result.Text = txt_value.Text;//将十进制转为十进制
                                break;
                            case 1:
                                txt_result.Text = //将十进制转为二进制
                                    new MyConterter().TenToBinary(long.Parse(txt_value.Text));
                                break;
                            case 2:
                                txt_result.Text = //将十进制转为八进制
                                    new MyConterter().TenToEight(long.Parse(txt_value.Text));
                                break;
                            case 3:
                                txt_result.Text = //将十进制转为十六进制
                                    new MyConterter().TenToSixteen(long.Parse(txt_value.Text));
                                break;
                        }
                    }
                    else
                    {
                        if (cbox_from.SelectedIndex == 1)//判断用户输入的是否为二进制数
                        {
                            switch (cbox_to.SelectedIndex)
                            {
                                case 0:
                                    txt_result.Text = //将二进制转为十进制
                                        new MyConterter().BinaryToTen(long.Parse(txt_value.Text));
                                    break;
                                case 1:
                                    txt_result.Text = txt_value.Text;//将二进制转为二进制
                                    break;
                                case 2:
                                    txt_result.Text = //将二进制转为八进制
                                        new MyConterter().BinaryToEight(long.Parse(txt_value.Text));
                                    break;
                                case 3:
                                    txt_result.Text = //将二进制转为十六进制
                                        new MyConterter().BinaryToSixteen(long.Parse(txt_value.Text));
                                    break;
                            }
                        }
                        else
                        {
                            if (cbox_from.SelectedIndex == 2)//判断用户输入的是否为八进制数
                            {
                                switch (cbox_to.SelectedIndex)
                                {
                                    case 0:
                                        txt_result.Text = //将八进制转为十进制
                                            new MyConterter().EightToTen(long.Parse(txt_value.Text));
                                        break;
                                    case 1:
                                        txt_result.Text = //将八进制转为二进制
                                            new MyConterter().EightToBinary(long.Parse(txt_value.Text));
                                        break;
                                    case 2:
                                        txt_result.Text = txt_value.Text;//将八进制转为八进制
                                        break;
                                    case 3:
                                        txt_result.Text = //将八进制转为十六进制
                                            new MyConterter().EightToSixteen(long.Parse(txt_value.Text));
                                        break;
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("请输入正确数值！", "提示！");//提示错误信息
                }
            }
            else
            {
                switch (cbox_to.SelectedIndex)
                {
                    case 0:
                        txt_result.Text = //将十六进制转为十进制
                            new MyConterter().SixteenToTen(txt_value.Text);
                        break;
                    case 1:
                        txt_result.Text = //将十六进制转为二进制
                            new MyConterter().SixteenToBinary(txt_value.Text);
                        break;
                    case 2:
                        txt_result.Text = //将十六进制转为八进制
                            new MyConterter().SixteenToEight(txt_value.Text);
                        break;
                    case 3:
                        txt_result.Text = //将十六进制转为十六进制
                            txt_value.Text;
                        break;
                }
            }
        }

        private void ConvertTools_Load(object sender, EventArgs e)
        {
            cbox_from.SelectedIndex = 0;
            cbox_to.SelectedIndex = 1;
        }

    }
}
