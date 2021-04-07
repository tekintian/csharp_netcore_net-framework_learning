using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FormDemoNFApp1
{
    public partial class FileDemoForm3 : Form
    {
        public FileDemoForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() !=DialogResult.OK)
                {
                    return;
                }
                //读取文件 ofd.FileName 
                /* //小文件的处理方式
                 string str = File.ReadAllText(ofd.FileName,Encoding.UTF8);
                textBox1.Text = str;*/

                //对于大文件最好的方式是使用FileStream  StreamReader一行一行的读取
                using (FileStream fs = new FileStream(ofd.FileName,FileMode.Open,FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            string lineStr = reader.ReadLine();
                            textBox1.Text += lineStr; //将读取到的文本附加到textBox1中
                        }
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            using (SaveFileDialog sfd= new SaveFileDialog())
            {
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                //最简单的方式
                //File.WriteAllText(sfd.FileName, txt,Encoding.UTF8);

                //使用StreamWriter 缓冲器大小为 1024*1024 字节
                /* using (StreamWriter sw= new StreamWriter(sfd.FileName,false,Encoding.UTF8,1024*1024))
                 {
                     sw.Write(txt); //将txt文本写入到流中
                     sw.Flush();//清空流
                 }*/

                using (FileStream fs= new FileStream(sfd.FileName,FileMode.OpenOrCreate,FileAccess.ReadWrite))
                {
                    //将文本转换为字节数组
                    byte[] data = Encoding.Default.GetBytes(txt);
                    fs.Write(data,0,data.Length);
                }
            }
        }
    }
}
