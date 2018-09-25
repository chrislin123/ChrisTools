using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChrisTools
{
    public partial class Tool006Form : BaseForm
    {
        public Tool006Form()
        {
            InitializeComponent();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();


            string aaaa = richTextBox1.Text;

            string[] sSplit = aaaa.Split('\n');

            foreach (string item in sSplit)
            {
                string sResult = item;
                if (item.IndexOf('|') >= 0)
                {
                    sResult = item.Substring(0, item.IndexOf('|'));
                    
                }


                richTextBox2.AppendText(sResult + "\n");

            }






        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void richTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox2.SelectAll();
        }
    }
}
