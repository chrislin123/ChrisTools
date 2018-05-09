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
using System.Diagnostics;

namespace ChrisTools
{
  public partial class Tool005Form : BaseForm
  {
    public Tool005Form()
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
      FileInfo[] fiList = new DirectoryInfo(txtFrom.Text).GetFiles("*.*", SearchOption.TopDirectoryOnly);
      int idx = 0;
      foreach (FileInfo fi in fiList)
      {
        idx++;

        string sIDent = fi.Name.Substring(iStartIndex, iLength);
        string NewFileName = string.Format(sFileNameTemp, sIDent);
        //最後一筆加上End字樣
        if (idx == fiList.Length)
        {
          NewFileName += ".END";
        }

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
              idx = i+1;
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
              idx = i + 2;
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

    private void txtFrom_MouseClick(object sender, MouseEventArgs e)
    {
      txtFrom.SelectAll();
    }

   
    /// <span class="code-SummaryComment"><summary></span>
    /// Executes a shell command synchronously.
    /// <span class="code-SummaryComment"></summary></span>
    /// <span class="code-SummaryComment"><param name="command">string command</param></span>
    /// <span class="code-SummaryComment"><returns>string, as output of the command.</returns></span>
    public List<string> ExecuteCommandSync(object command)
    {
      List<string> ResultList = new List<string>();
      //string sResult = "";
      try
      {
        // create the ProcessStartInfo using "cmd" as the program to be run,
        // and "/c " as the parameters.
        // Incidentally, /c tells cmd that we want it to execute the command that follows,
        // and then exit.
        System.Diagnostics.ProcessStartInfo procStartInfo =
            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

        // The following commands are needed to redirect the standard output.
        // This means that it will be redirected to the Process.StandardOutput StreamReader.
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        // Do not create the black window.
        procStartInfo.CreateNoWindow = true;
        // Now we create a process, assign its ProcessStartInfo and start it
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
      

        //while (!proc.StandardOutput.EndOfStream)
        //{
        //  string line = proc.StandardOutput.ReadLine();
        //  // do something with line
        //  Console.WriteLine(line);
        //}


        // Get the output into a string
        string result = proc.StandardOutput.ReadToEnd();

        ResultList = result.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList<string>();


        // Display the command output.
        Console.WriteLine(result);
      }
      catch (Exception objException)
      {
        // Log the exception
      }

      return ResultList;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      string sMkvtoolnixPath = @"F:\temp\mkvtoolnix\mkvmerge.exe";
      string sMkvextractPath = @"F:\temp\mkvtoolnix\mkvextract.exe";
      string sFilePath = @"F:\temp\1.mkv";
      FileInfo fi = new FileInfo(sFilePath);
      string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" ", sMkvtoolnixPath, sFilePath);
      List<string> TempList = ExecuteCommandSync(sGetInfoCommand);

      foreach (string item in TempList)
      {
        //判斷字幕
        if (item.Contains("subtitles") == true)
        {
          /*
            Track ID 2: subtitles (VobSub)
            Track ID 3: subtitles (SubRip/SRT)
            Track ID 4: subtitles (SubStationAlpha)
            Track ID 5: subtitles (SubStationAlpha)
            Track ID 6: subtitles (HDMV PGS)
          */
          
          //取得軌道
          string[] TrackSplit = item.Split(':');
          string sTrackID = TrackSplit[0].Replace("Track ID ", "").Trim();
          string sTrackType = TrackSplit[1].Replace("subtitles (", "").Replace(")", "").Trim();

          string sCommandExt = string.Format(@"""{0}"" tracks ""{1}"" {2}:{3}.{4} "
                                      , sMkvextractPath
                                      , sFilePath,sTrackID
                                      , fi.Name.Replace(fi.Extension,"")
                                      , TransExtension(sTrackType));


          //MessageBox.Show(sTrackID + " " + sTrackType);

          ExecuteCommandSync(sCommandExt);
        }
      }
    }

    private string TransExtension(string sTrans) {
      string sResult = "";

      if (sTrans == "VobSub") sResult = "sub";
      if (sTrans == "SubRip/SRT") sResult = "srt";
      if (sTrans == "SubStationAlpha") sResult = "ass";
      if (sTrans == "SubStationAlpha") sResult = "ass";
      if (sTrans == "HDMV PGS") sResult = "sup";

      return sResult;
    }


    private void button3_Click(object sender, EventArgs e)
    {  
      string sMkvtoolnixPath = @"F:\temp\mkvtoolnix\mkvextract.exe";
      string sGetInfoCommand = string.Format(@"""{0}"" tracks ""F:\temp\test.mp4"" 1:test.aac ", sMkvtoolnixPath);
      ExecuteCommandSync(sGetInfoCommand);
    }
  }
}
