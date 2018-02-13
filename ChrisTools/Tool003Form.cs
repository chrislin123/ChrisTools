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

namespace ChrisTools
{
  public partial class Tool003Form : BaseForm
  {
    public Tool003Form()
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

      int iStartIndex = Convert.ToInt16(startindexText.Text);
      int iLength = Convert.ToInt16(lengthText.Text);
      string sFileNameTemp = NewNameText.Text;

      string sfileFullName = string.Empty;
      foreach (FileInfo fi in new DirectoryInfo(txtFrom.Text).GetFiles("*.*", SearchOption.TopDirectoryOnly))
      {

        string sIDent = fi.Name.Substring(iStartIndex, iLength);
        string NewFileName = string.Format(sFileNameTemp, sIDent);

        fi.MoveTo(Path.Combine(fi.DirectoryName, NewFileName + fi.Extension));        
      }

      BaseShowStatus("執行完畢！");

    

    }

    private void TestButton_Click(object sender, EventArgs e)
    {
      int iStartIndex = Convert.ToInt16(startindexText.Text);
      int iLength = Convert.ToInt16(lengthText.Text);
      string sFileNameTemp = NewNameText.Text;

      string sfileFullName = string.Empty;
      foreach (FileInfo fi in new DirectoryInfo(txtFrom.Text).GetFiles("*.*", SearchOption.TopDirectoryOnly))
      {
        string sIDent = fi.Name.Substring(iStartIndex, iLength);        

        MessageBox.Show(sIDent);

        break;
      }

    }
  }
}
