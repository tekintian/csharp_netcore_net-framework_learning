using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LearnNF
{
    public partial class RegexDemo : Form
    {
        public RegexDemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string regexp = textBox3.Text;

            MatchCollection mcols = Regex.Matches(text, regexp);
            StringBuilder sb = new StringBuilder();
            foreach (Match m in mcols) {
                sb.Append(m.Value + "\n");
            }
            textBox2.Text = sb.ToString();

        }
    }
}
