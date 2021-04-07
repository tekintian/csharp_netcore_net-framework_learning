using System.Windows.Forms;

namespace FormDemoNFApp1
{
    public partial class Form2 : Form, IChildFrm
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void MySetText(string txt)
        {
           textBox1.Text=txt;
        }
    }
}
