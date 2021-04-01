//NPOI 程序包引用
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

//需要安装程序包 NPOI
//https://www.nuget.org/packages/NPOI/2.5.2

namespace ExcelHandlerApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //将数据导出到excel文件
        private void WriteExcel(string filename, List<Person> list)
        {
            //把List集合的内容导出到excel

            // 1.创建工作表对象
            IWorkbook workbook = new HSSFWorkbook();

            // 2.在工作表中创建工资表对象
            ISheet sheet = workbook.CreateSheet("List fro person");

            for (int i = 0; i < list.Count; i++)
            {
                //创建一行
                IRow row = sheet.CreateRow(i);
                //将值放入行中
                row.CreateCell(0).SetCellValue(list[i].Name);
                row.CreateCell(1).SetCellValue(list[i].Age);
                row.CreateCell(2).SetCellValue(list[i].Email);
            }

            // 3 把workbook对象写入到磁盘
            using (FileStream fs = File.OpenWrite(filename))
            {
                workbook.Write(fs);
            }
            MessageBox.Show("写入成功!");

        }

        //读取excel
        private void ReadExcel(string filename)
        {
            //创建一个读取对象
            using (FileStream fs = File.OpenRead(filename))
            {
                //把文件流中的数据读取到workbook对象中
                IWorkbook workbook = new HSSFWorkbook(fs);

                //遍历workbook中的每一个sheeet  NumberOfSheets 为表中sheet的个数
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    //获取每个工作表
                    ISheet sheet = workbook.GetSheetAt(i);

                    Console.WriteLine("--------{0}-----------", sheet.SheetName);

                    //遍历获取工作表中的每一行
                    for (int r = 0; r <= sheet.LastRowNum; r++)
                    {
                        //获取到工作表中的每一行
                        IRow row = sheet.GetRow(r);

                        /*
                        //注意这里获取单元格的值 需要根据实际的数据类型来获取 如
                        string c1 = row.GetCell(0).StringCellValue;//字符串单元格数据

                        double c2 = row.GetCell(1).NumericCellValue;//浮点型单元格数据

                        DateTime date = row.GetCell(2).DateCellValue;//日期型单元格数据
                        */

                        //遍历获取每行中的每个单元格 LastCellNum 获取的是单元格的数量+1
                        for (int c = 0; c < row.LastCellNum; c++)
                        {
                            //获取每个单元格
                            ICell cell = row.GetCell(c);
                            //这里演示把每个单元格都当做字符串来处理
                            string val = cell.ToString();
                            Console.Write("{0}  |  ", val);
                        }

                        Console.WriteLine();//输出一个换行

                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保存文件对话框
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xls";//默认后缀 xsl
            //支持的文件后缀  xls或者xlsx
            dlg.Filter = "Excel Worksheets|*.xls;*.xlsx";

            DialogResult result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == DialogResult.OK)
            {
                // Open document
                string filename = dlg.FileName;

                //创建并初始化集合
                List<Person> list = new List<Person>() {
                    new Person(){Name="张三",Age=19,Email="zs@qq.com" },
                    new Person(){ Name="李四",Age=20,Email="ls@qq.com"},
                    new Person(){ Name="王五",Age=15,Email="ww@qq.com"}
                };

                WriteExcel(filename, list);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //打开文件对话框
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xls";//默认后缀 xsl
            //打开对话框支持的文件后缀  xls或者xlsx
            dlg.Filter = "Excel Worksheets|*.xls;*.xlsx";

            DialogResult result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == DialogResult.OK)
            {
                // Open document
                string filename = dlg.FileName;
                ReadExcel(filename);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //方法与上面的类似, 不同的就是数据时从数据库中获取来的
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //...
        }
    }
}
