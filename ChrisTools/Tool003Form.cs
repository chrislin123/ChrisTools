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
      if (MessageBox.Show("確定修改?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
      {
        return;
      }


      //防呆
      if (NewNameText.Text.Contains("{0}") == false)
      {
        //新檔案名稱格式
        MessageBox.Show("新檔案名稱格式，需要包含'{0}'字元。");
        return;
      }


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

    private void txtFrom_TextChanged(object sender, EventArgs e)
    {
      try
      {
        //新增擋案名稱智能判斷
        //1.資料夾名稱分析，預測檔名
        DirectoryInfo di = new DirectoryInfo(txtFrom.Text);
        if (di.Name.Contains("]") == true)
        {
          //取得"]"後的名稱
          string TempString = di.Name.Substring(di.Name.IndexOf("]") + 1, di.Name.Length - di.Name.IndexOf("]") - 1);

          NewNameText.Text = TempString + ".E{0}";
        }
        else
        {
          NewNameText.Text = di.Name + ".E{0}";
        }

        int idx = 0;
        int iTemp = 0;
        //判斷檔案名稱，預測起始位置
        FileInfo[] fiList = di.GetFiles();
        if (fiList.Length > 0)
        {
          FileInfo fi = fiList[0];
          
          string sAnlString = fi.Name.ToUpper();


          //分析"E01"
          for (int i = 0; i < sAnlString.Length; i++)
          {
            if (i == sAnlString.Length -1)
            {
              break;
            }

            if (sAnlString.Substring(i, 1) == "E" && int.TryParse(sAnlString.Substring(i+1, 1),out iTemp))
            {
              idx = i;
              break;
            }
          }

          //分析"EP01"
          for (int i = 0; i < sAnlString.Length; i++)
          {
            if (i == sAnlString.Length - 2)
            {
              break;
            }

            if (sAnlString.Substring(i, 2) == "EP" && int.TryParse(sAnlString.Substring(i + 2, 1), out iTemp))
            {
              idx = i + 1;
              break;
            }
          }
        }

        startindexText.Text = idx.ToString();



      }
      catch (Exception)
      {
        //解析錯誤，提供預設值
        NewNameText.Text = "預設.E{0}";
      }




    }
  }
}
