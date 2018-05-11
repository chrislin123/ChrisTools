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
      path.ShowDialog();
      txtMkvToolPath.Text = path.SelectedPath;

      //防呆，判斷程式是否存在

    }

    private void button4_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog path = new FolderBrowserDialog();
      path.ShowDialog();
      txtTransPath.Text = path.SelectedPath;
    }

    private void btnStart_Click(object sender, EventArgs e)
    {


      DirectoryInfo di = new DirectoryInfo(txtMkvToolPath.Text);


      var r1 = di.GetFiles().ToList<FileInfo>().Where(a => a.Name.ToUpper() == "MKVEXTRACT.EXE");

      if (r1.Count() == 0)
      {
        MessageBox.Show("MkvTool路經，未包含MKVEXTRACT.EXE");
      }

      var r2 = di.GetFiles().ToList<FileInfo>().Where(a => a.Name.ToUpper() == "MKVMERGE.EXE");

      if (r2.Count() == 0)
      {
        MessageBox.Show("MkvTool路經，未包含MKVMERGE.EXE");
      }

      FileInfo[] fiList = new DirectoryInfo(txtTransPath.Text).GetFiles("*.mkv", SearchOption.AllDirectories);

      
      int idx = 1;
      foreach (FileInfo item in fiList)
      {
        lbltotal.Text = string.Format("{0} / {1}", idx,fiList.Length);
        ShowStatus(string.Format("轉檔：{0}",item.FullName));
        ProcMkvExtractSubt(item);

        idx++;
      }

      ShowStatus("完成");




      //if (MessageBox.Show("確定修改?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
      //{
      //  return;
      //}




      //string sfileFullName = string.Empty;
      //FileInfo[] fiList = new DirectoryInfo(txtMkvToolPath.Text).GetFiles("*.*", SearchOption.TopDirectoryOnly);
      //int idx = 0;
      //foreach (FileInfo fi in fiList)
      //{
      //  idx++;

      //  string sIDent = fi.Name.Substring(iStartIndex, iLength);
      //  string NewFileName = string.Format(sFileNameTemp, sIDent);
      //  //最後一筆加上End字樣
      //  if (idx == fiList.Length)
      //  {
      //    NewFileName += ".END";
      //  }

      //  fi.MoveTo(Path.Combine(fi.DirectoryName, NewFileName + fi.Extension));
      //}

      //BaseShowStatus("執行完畢！");



    }

    private void ShowStatus(string msg) {

      lblStatus.Text = msg;
      Application.DoEvents();

    }
    private void ShowRichTextStatus(string pMsg)
    {
      if (pMsg.Contains("Progress:") == true)
      {
        progressBar1.Value = Convert.ToInt32(pMsg.Replace("Progress:", "").Replace("%", "").Trim());
        if (pMsg == "Progress: 100%")
        {
          richTextBox1.AppendText("\r\n" + "完成。");
        }
      }
      else
      {
        richTextBox1.AppendText("\r\n" + pMsg);
      }

      this.Update();
      Application.DoEvents();
    }


    private void txtFrom_MouseClick(object sender, MouseEventArgs e)
    {
      txtMkvToolPath.SelectAll();
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

      Console.WriteLine(command.ToString());
      try
      {
        // create the ProcessStartInfo using "cmd" as the program to be run,
        // and "/c " as the parameters.
        // Incidentally, /c tells cmd that we want it to execute the command that follows,
        // and then exit.
        //System.Diagnostics.ProcessStartInfo procStartInfo =
        //    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
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


        while (!proc.StandardOutput.EndOfStream)
        {
          string line = proc.StandardOutput.ReadLine();
          // do something with line

          ResultList.Add(line);


          ShowRichTextStatus(line);

          Console.WriteLine(line);
        }


        // Get the output into a string
        //string result = proc.StandardOutput.ReadToEnd();

        proc.WaitForExit();

        //ResultList = result.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList<string>();


        // Display the command output.
        //Console.WriteLine(result);
      }
      catch (Exception objException)
      {
        // Log the exception
      }

      return ResultList;
    }


    private void ProcMkvExtractSubt(FileInfo pFileInfo)
    {
      string sMkvToolPath = txtMkvToolPath.Text;
      string sMkvtoolnixPath = Path.Combine(sMkvToolPath, "mkvmerge.exe");
      string sMkvextractPath = Path.Combine(sMkvToolPath, "mkvextract.exe");
      string sFilePath = pFileInfo.FullName;
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

          string sCommandExt = string.Format(@"{0} tracks ""{1}"" {2}:{3}.{4} "
                                      , sMkvextractPath
                                      , sFilePath
                                      , sTrackID
                                      , fi.FullName.Replace(fi.Extension, "")
                                      , TransExtension(sTrackType));

          ExecuteCommandSync(sCommandExt);
        }
      }

    }



    private void button2_Click(object sender, EventArgs e)
    {
      ProcMkvExtractSubt(new FileInfo(@"F:\temp\1.mkv"));
    }

    private string TransExtension(string sTrans)
    {
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

   
    private void txtMkvToolPath_TextChanged(object sender, EventArgs e)
    {
      try
      {
        string sFileExist = "";
        //新增擋案名稱智能判斷
        //1.資料夾名稱分析，預測檔名

        //di.GetFiles().ToList<FileInfo>().Where(a => a.Name.ToUpper() == "mkvextract.exe");



        //if (di.Name.Contains("]") == true)
        //{
        //  //取得"]"後的名稱
        //  string TempString = di.Name.Substring(di.Name.IndexOf("]") + 1, di.Name.Length - di.Name.IndexOf("]") - 1);

        //  txtTransPath.Text = TempString + ".E{0}";
        //}
        //else
        //{
        //  txtTransPath.Text = di.Name + ".E{0}";
        //}





      }
      catch (Exception)
      {
        //MessageBox.Show("Test");
        //解析錯誤，提供預設值
        //txtTransPath.Text = "預設.E{0}";
      }
    }

    private void txtMkvToolPath_MouseClick(object sender, MouseEventArgs e)
    {
      txtMkvToolPath.SelectAll();
    }

    private void txtTransPath_MouseClick(object sender, MouseEventArgs e)
    {
      txtTransPath.SelectAll();
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
      RichTextBox rtb = sender as RichTextBox;

      if (rtb.Lines.Length > 500)
      {
        rtb.Text = rtb.Text.Remove(0, rtb.Lines[0].Length + 1);
      }

      rtb.ScrollToCaret();
    }

    private void Tool005Form_Load(object sender, EventArgs e)
    {
      
    }

    private void btnRemoveFile_Click(object sender, EventArgs e)
    {

      if (MessageBox.Show("確定刪除?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
      {
        return;
      }

      FileInfo[] fiList = new DirectoryInfo(txtTransPath.Text).GetFiles("*.rar", SearchOption.AllDirectories);
      
      foreach (FileInfo item in fiList)
      {
        ShowRichTextStatus(string.Format("刪除：{0}", item.FullName));

        item.Delete();
      }

      
      fiList = new DirectoryInfo(txtTransPath.Text).GetFiles("*.ini", SearchOption.AllDirectories);

      foreach (FileInfo item in fiList)
      {
        ShowRichTextStatus(string.Format("刪除：{0}", item.FullName));

        item.Delete();
      }

      ShowStatus("完成");
    }
  }
}
