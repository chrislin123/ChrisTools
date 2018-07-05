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
using M10.lib.modelChrisTools;
using M10.lib;

namespace ChrisTools
{
  public partial class Tool005Form : BaseForm
  {
    //const string constMkvToolPath = "MkvToolPath";
    //const string constTransPath = "TransPath";
    Tool005Helper oTool005Helper = new Tool005Helper();
    public Tool005Form()
    {
      InitializeComponent();
      base.InitForm();
    }

    private void Tool005Form_Load(object sender, EventArgs e)
    {


      

      txtMkvToolPath.Text = Comm.GetSetting(CTsConst.SettingList.Tool005_MkvToolPath);
      txtTransPath.Text = Comm.GetSetting(CTsConst.SettingList.Tool005_TransPath);

      //取得預設值
      //ssql = "select * from basedata where type = @type";
      //var q = dbDapper.GetNewDynamicParameters();
      //q.Add("type", constMkvToolPath);
      //BaseData bdMkvToolPath = dbDapper.QuerySingleOrDefault<BaseData>(ssql, q);
      //txtMkvToolPath.Text = bdMkvToolPath == null ? "" : bdMkvToolPath.data1;

      //var q1 = dbDapper.GetNewDynamicParameters();
      //q1.Add("type", constTransPath);
      //BaseData bdTransPath = dbDapper.QuerySingleOrDefault<BaseData>(ssql, q1);
      //txtTransPath.Text = bdTransPath == null ? "" : bdTransPath.data1;
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
      string sTransPath = txtTransPath.Text;

      //解壓
      ProcUnRAR(sTransPath);

      //移除rar
      ProcRemoveFile(sTransPath, "*.rar");
      //移除ini
      ProcRemoveFile(sTransPath, "*.ini");


      //擷取
      ProcGetSrt(sTransPath);


      ShowStatus("全部完成");
    }

    private void ShowStatus(string msg)
    {

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



    private void btnRemoveFile_Click(object sender, EventArgs e)
    {

      if (MessageBox.Show("確定刪除?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
      {
        return;
      }

      //移除rar
      ProcRemoveFile(txtTransPath.Text, "*.rar");
      //移除ini
      ProcRemoveFile(txtTransPath.Text, "*.ini");      

      ShowStatus("完成");
    }



    private void Tool005Form_FormClosing(object sender, FormClosingEventArgs e)
    {
      Comm.SetSetting(CTsConst.SettingList.Tool005_MkvToolPath, txtMkvToolPath.Text);
      Comm.SetSetting(CTsConst.SettingList.Tool005_TransPath, txtTransPath.Text);
    }

    private void btnGetSrt_Click(object sender, EventArgs e)
    {

      string sTemp = oTool005Helper.checkMkvToolExe(txtMkvToolPath.Text);
      if (sTemp != "") MessageBox.Show(sTemp);
      

      ProcGetSrt(txtTransPath.Text);

      ShowStatus("完成");

    }

    private void btnBatUnZip_Click(object sender, EventArgs e)
    {
      ProcUnRAR(txtTransPath.Text);
    }


    private void ProcUnRAR(string sPath)
    {
      DirectoryInfo di = new DirectoryInfo(sPath);
      clsWinrar rar = new clsWinrar();


      //取得所有資料夾
      List<string> AllDiList = Directory.GetDirectories(di.FullName, "*.*", SearchOption.AllDirectories).ToList<string>();



      foreach (string SubDiString in AllDiList)
      {
        DirectoryInfo SubDi = new DirectoryInfo(SubDiString);

        //判斷資料夾是否包含RAR檔案，不包含不處理
        if (SubDi.GetFiles("*.rar").Length == 0) continue;


        string smark = "!@#$";
        foreach (FileInfo SubFi in SubDi.GetFiles("*.rar"))
        {
          //判斷是否有切割擋
          if (SubFi.Name.Contains(".part"))
          {
            if (SubFi.Name.Contains(smark)) continue;

            //解壓縮
            rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");

            //紀錄擋名
            smark = SubFi.Name.Substring(0, SubFi.Name.IndexOf(".part"));

          }
          else
          {
            rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");
          }

        }


      }

    }


    private void ProcGetSrt(string sPath) {
      FileInfo[] fiList = new DirectoryInfo(sPath).GetFiles("*.mkv", SearchOption.AllDirectories);

      int idx = 1;
      foreach (FileInfo item in fiList)
      {
        lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
        ShowStatus(string.Format("轉檔：{0}", item.FullName));
        ProcMkvExtractSubt(item);

        idx++;
      }
    }

    private void ProcRemoveFile(string sPath,string searchPattern)
    {
      FileInfo[] fiList = new DirectoryInfo(sPath).GetFiles(searchPattern, SearchOption.AllDirectories);

      int idx = 1;
      foreach (FileInfo item in fiList)
      {
        lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
        ShowRichTextStatus(string.Format("刪除：{0}", item.FullName));

        item.Attributes = FileAttributes.Normal;
        item.Delete();

        idx++;
      }
    }



    private void btnFileNameTune_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("確定要批次更新檔案名稱?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
      {
        return;
      }

      DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);


      List<FileInfo> tttt = di.GetFiles("*.*", SearchOption.AllDirectories)
        .Where(s => s.Extension.ToLower() == ".mkv" || s.Extension.ToLower() == ".mp4").ToList<FileInfo>();


      foreach (FileInfo item in tttt)
      {
        string sNewFileName = item.Name.Replace(" ", "").Replace("(1)", "").Replace("(2)", "")
          .Replace("(ass)", "").Replace("(srt)", "");

        string sFullRename = Path.Combine(item.DirectoryName, sNewFileName);
        if (File.Exists(sFullRename) == false)
        {
          item.MoveTo(sFullRename);
        }
      }

      ShowStatus("批次更新檔案名稱 完成");
    }

    private void btnRemoveMKV_Click(object sender, EventArgs e)
    {
      //移除ini
      ProcRemoveFile(txtTransPath.Text, "*.mkv");
    }

    private void btnMergeMKV_Click(object sender, EventArgs e)
    {
      string sTemp = oTool005Helper.checkMkvToolExe(txtMkvToolPath.Text);
      if (sTemp != "") MessageBox.Show(sTemp);

      DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);
      
      string sVideoType = "";
      if (radMP4.Checked == true) sVideoType = "mp4";
      if (radMKV.Checked == true) sVideoType = "mkv";

      string sSubTitleType = "";
      if (radASS.Checked == true) sSubTitleType = "ass";
      if (radSRT.Checked == true) sSubTitleType = "srt";      

      //取得所有影像資料
      FileInfo[] VideoList = di.GetFiles("*." + sVideoType, SearchOption.AllDirectories);

      int idx = 1;
      //設定進度條
      progressBar2.Maximum = VideoList.Length;
      foreach (FileInfo VideoItem in VideoList)
      {
        progressBar2.Value = idx;
        lbltotal.Text = string.Format("{0} / {1}", idx, VideoList.Length);

        //搜尋符合的SubTilte
        DirectoryInfo diTemp = VideoItem.Directory;
        FileInfo[] fiSubTitleList = diTemp.GetFiles(
          string.Format("{0}*.{1}", VideoItem.Name.Replace(VideoItem.Extension, ""), sSubTitleType)
          , SearchOption.TopDirectoryOnly);

        if (fiSubTitleList.Length > 0)
        {
          //執行合併檔案
          ProcMergeMkvSrt(VideoItem, fiSubTitleList[0]);
        }

        idx++;
      }

      Button btnSender = sender as Button;
      ShowStatus(string.Format("[完成]{0}", btnSender.Text));

    }



    private void ProcMergeMkvSrt(FileInfo fiMKV,FileInfo fiSubTitle)
    {
      //建立轉檔資料夾
      string sMkvTrans = "MkvTrans";
      Directory.CreateDirectory(Path.Combine(fiMKV.DirectoryName, sMkvTrans));

      string sMkvToolPath = txtMkvToolPath.Text;
      string sMkvtoolnixPath = Path.Combine(sMkvToolPath, "mkvmerge.exe");
      //string sMkvextractPath = Path.Combine(sMkvToolPath, "mkvextract.exe");
      //string sFilePath = pFileInfo.FullName;
      //FileInfo fi = new FileInfo(sFilePath);

      string sSubTitleType = "";
      if (fiSubTitle.Extension.ToUpper() == ".ASS") sSubTitleType = "(ass)";
      if (fiSubTitle.Extension.ToUpper() == ".SRT") sSubTitleType = "(srt)";


      FileInfo fiTarget = new FileInfo(Path.Combine(
         fiMKV.DirectoryName, sMkvTrans, fiMKV.Name.Replace(fiMKV.Extension, "") + sSubTitleType + ".mkv"));

      //取得資訊
      //string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" ", sMkvtoolnixPath, fiMKV.FullName);
      //List<string> TempList = ExecuteCommandSync(sGetInfoCommand);



      string sGetInfoCommand = string.Format(@"{0} -o {1} -S {2} {3}", sMkvtoolnixPath, fiTarget.FullName, fiMKV.FullName,fiSubTitle.FullName);
      //sGetInfoCommand = string.Format(@"{0} -o {1} {2} {3}", sMkvtoolnixPath, fiTarget.FullName, fiMKV.FullName, fiSRT.FullName);
      List<string>  TempList = ExecuteCommandSync(sGetInfoCommand);

    }

  }


  public class Tool005Helper {


    public string checkMkvToolExe(string sMkvtoolPath)
    {
      string sResult = "";

      DirectoryInfo di = new DirectoryInfo(sMkvtoolPath);

      var r1 = di.GetFiles().ToList<FileInfo>().Where(a => a.Name.ToUpper() == "MKVEXTRACT.EXE");
      if (r1.Count() == 0) sResult = "MkvTool路經，未包含MKVEXTRACT.EXE";

      var r2 = di.GetFiles().ToList<FileInfo>().Where(a => a.Name.ToUpper() == "MKVMERGE.EXE");
      if (r2.Count() == 0) sResult = "MkvTool路經，未包含MKVMERGE.EXE";

      return sResult;
    }



  }
}
