using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckOver4gFile
{
    public partial class CheckOver4g : Form
    {
        public CheckOver4g()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            //path.RootFolder = Environment.SpecialFolder.;
            path.ShowDialog();
            txtFrom.Text = path.SelectedPath;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string sfileFullName = string.Empty;
            foreach (FileInfo fi in new DirectoryInfo(txtFrom.Text).GetFiles("*.*", SearchOption.AllDirectories))
            {
                //decimal a = Math.Round((decimal)f.Length / 1024, 5);//K byte
                //decimal a = Math.Round((decimal)fi.Length / (1024 * 1024), 5);//M byte
                decimal a = Math.Round((decimal)fi.Length / (1024 * 1024 * 1024), 10);//G byte

                //大於500mb 就搬移檔案
                if (a > 4)
                {
                    //if (!File.Exists(txtFrom.Text + @"\" + fi.Name))
                    //{
                    //    fi.MoveTo(txtFrom.Text + @"\" + fi.Name);
                    //}
                    sfileFullName = fi.FullName;


                    lstFiles.Items.Add(fi.FullName);


                }
            }

            MessageBox.Show("執行完畢！");
        }

        private void btnRAR_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(txtFrom.Text);


            string sPath = txtFrom.Text.Trim();
            
            FileInfo[] afi = di.GetFiles();
            DirectoryInfo[] adi = di.GetDirectories();
            clsWinrar oRar = new clsWinrar();

            oRar.Wait = chkWait.Checked;
            if (rg3.Checked == true)
            {
                oRar.size = clsWinrar.MyEnum.g3;
            }

            if (rm900.Checked == true)
            {
                oRar.size = clsWinrar.MyEnum.m900;
            }

            
            foreach (FileInfo fi in afi)
            {
                //取得目錄
                //sPath = fi.DirectoryName;
                string sRarName = fi.Name.Replace(fi.Extension,"");

                oRar.CompressRAR(sPath + @"\" + sRarName.Trim(), fi.FullName);
            }

            foreach (DirectoryInfo odi in adi)
            {
                //取得目錄
                //sPath = di.FullName;
                string sRarName = odi.Name.Trim().Replace(" ", "");

                oRar.CompressRAR(sPath + @"\" + sRarName, odi.FullName);
            }

            


            MessageBox.Show("執行完畢！");
        }





    }
}
