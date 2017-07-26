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
using ExifLib;

namespace ChrisTools
{
  public partial class Tool001Form : Form
  {
    public Tool001Form()
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
      ResultTextbox.Clear();

      string sRootPath = txtFrom.Text;
      string sTempPath = Path.Combine(sRootPath, "Temp");
      
      //建立暫存資料夾
      if (Directory.Exists(sTempPath) == false)
      { 
        Directory.CreateDirectory(sTempPath);

        ResultTextbox.AppendText("建立歸檔資料夾：" + sTempPath +"\r\n");
        Application.DoEvents();
      }


      FileInfo[] FileInfoList = new DirectoryInfo(sRootPath).GetFiles();
      int iTotal = FileInfoList.Length;
      ResultTextbox.AppendText("總檔案數：" + iTotal.ToString() + "\r\n");
      Application.DoEvents();

      int iIndex = 1;
      //取得根目錄底下所有檔案
      foreach (FileInfo LoopFileInfo in FileInfoList)
      {

        string sPictureTaken = "";
        //取得拍攝日期
        try
        {
          using (ExifReader reader = new ExifReader(LoopFileInfo.FullName))
          {

            // Extract the tag data using the ExifTags enumeration
            DateTime datePictureTaken;
            if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized,
                                            out datePictureTaken))
            {
              // Do whatever is required with the extracted information
              //MessageBox.Show(this, string.Format("The picture was taken on {0}",
              //   datePictureTaken), "Image information", MessageBoxButtons.OK);

              sPictureTaken = datePictureTaken.ToString("yyyyMMdd");

            }
          }
        }
        catch (Exception)
        {
          //取得Exif異常，則使用最後修改日期
          sPictureTaken = LoopFileInfo.LastWriteTime.ToString("yyyyMMdd");
        }

        if (sPictureTaken == "")
        {
          sPictureTaken = LoopFileInfo.LastWriteTime.ToString("yyyyMMdd");
        }

        //依照最後修改時間，建立歸檔資料夾
        string sArchivingPath = Path.Combine(sTempPath, sPictureTaken);

        if (Directory.Exists(sArchivingPath) == false)
        {
          Directory.CreateDirectory(sArchivingPath);
        }

        //ExifReader er = new ExifReader(LoopFileInfo.FullName);

        


        if (!File.Exists(sArchivingPath + @"\" + LoopFileInfo.Name))
        {
          LoopFileInfo.MoveTo(sArchivingPath + @"\" + LoopFileInfo.Name);
        }

        ResultTextbox.AppendText(string.Format("[{0}/{1}]：檔案 {2} 移動至 {3}"
          ,iIndex.ToString(),iTotal.ToString()
          ,LoopFileInfo.Name
          , sArchivingPath + @"\" + LoopFileInfo.Name) + "\r\n");
        

        ResultTextbox.ScrollToCaret();
        Application.DoEvents();
        iIndex++;

        System.Threading.Thread.Sleep(30);
      }

      ResultTextbox.AppendText("完成。" + "\r\n");
      ResultTextbox.ScrollToCaret();
      Application.DoEvents();

    }

    private void btnGetout_Click(object sender, EventArgs e)
    {
      ResultTextbox.Clear();
      string sRootPath = txtFrom.Text;

      //搜尋所有子目錄的檔案
      FileInfo[] FileInfoList = new DirectoryInfo(sRootPath).GetFiles("*.*", SearchOption.AllDirectories);
      int iTotal = FileInfoList.Length;
      
      int iIndex = 1;
      foreach (FileInfo LoopFileInfo in FileInfoList)
      {
        //移動所有檔案到根目錄
        if (!File.Exists(sRootPath + @"\" + LoopFileInfo.Name))
        {
          LoopFileInfo.MoveTo(sRootPath + @"\" + LoopFileInfo.Name);

          ResultTextbox.AppendText(string.Format("進度[{0}/{1}]\r\n", iIndex.ToString(),iTotal.ToString()));
          ResultTextbox.ScrollToCaret();
          Application.DoEvents();
        }

        iIndex++;
      }


      ResultTextbox.AppendText("完成。" + "\r\n");
      ResultTextbox.ScrollToCaret();
      Application.DoEvents();
    }
  }
}
