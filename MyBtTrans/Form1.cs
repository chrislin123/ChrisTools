using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyBtTrans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog path = new FolderBrowserDialog();
            //path.RootFolder = Environment.SpecialFolder.;
            path.ShowDialog();
            txtFrom.Text = path.SelectedPath;

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //瀏覽
            //string[] dirs = Directory.GetDirectories(txtFrom.Text, "*.*", SearchOption.AllDirectories);
            //string[] files = Directory.GetFiles(txtFrom.Text, "*.*", SearchOption.AllDirectories);

            //DirectoryInfo di = new DirectoryInfo(txtFrom.Text);
            //di.CreateSubdirectory("trans");

            //foreach (string  filename in files)
            //{
            //    FileInfo fi = new FileInfo(filename);
            //}

            string sfileFullName = string.Empty;
            foreach (FileInfo fi in new DirectoryInfo(txtFrom.Text).GetFiles("*.*",SearchOption.AllDirectories))
            {
                //decimal a = Math.Round((decimal)f.Length / 1024, 5);//K byte
                decimal a = Math.Round((decimal)fi.Length / (1024 * 1024), 5);//M byte
                //decimal a = Math.Round((decimal)f.Length / (1024 * 1024 * 1024), 10);//G byte
                
                //大於500mb 就搬移檔案
                if (a > 500)
                {
                    if (!File.Exists(txtFrom.Text + @"\" + fi.Name))
                    {
                        fi.MoveTo(txtFrom.Text + @"\" + fi.Name);
                    }
                    sfileFullName = fi.FullName;              
                }              
            }

            MessageBox.Show("執行完畢！");


            if (chkOpen.Checked)
            {
                //開啟檔案總管
                string file = @"C:\Windows\explorer.exe";
                string argument = @"/select, " + sfileFullName;
                System.Diagnostics.Process.Start(file, argument); 
            }
            
        }

    }
}
