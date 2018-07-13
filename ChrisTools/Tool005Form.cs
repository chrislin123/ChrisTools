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
      ClearForm();

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
          richTextBox1.AppendText("\r\n" + pMsg + " 完成。");
        }
      }
      else
      {
        //取消不顯示細部內容
        //richTextBox1.AppendText("\r\n" + pMsg);
      }

      this.Update();
      Application.DoEvents();
    }

    private void ShowRichTextStatus1(string pMsg)
    {
      //取消不顯示細部內容
      richTextBox1.AppendText("\r\n" + pMsg);

      //this.Update();
      //Application.DoEvents();
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

      //Console.WriteLine(command.ToString());
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
        //解決中文顯示問題
        procStartInfo.StandardOutputEncoding = Encoding.UTF8;
        // Now we create a process, assign its ProcessStartInfo and start it
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        //解決中文顯示問題
        proc.StartInfo.StandardOutputEncoding = Encoding.UTF8;
        proc.StartInfo = procStartInfo;
        proc.Start();


        while (!proc.StandardOutput.EndOfStream)
        {
          string line = proc.StandardOutput.ReadLine();
          // do something with line

          ResultList.Add(line);


          ShowRichTextStatus(line);

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

          string sCommandExt = string.Format(@"{0} tracks ""{1}"" {2}:""{3}.{4}"" "
                                      , sMkvextractPath
                                      , sFilePath
                                      , sTrackID
                                      , fi.FullName.Replace(fi.Extension, "")
                                      , TransExtension(sTrackType));

          ExecuteCommandSync(sCommandExt);
        }
      }

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
      ClearForm();

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
      ClearForm();

      string sTemp = oTool005Helper.checkMkvToolExe(txtMkvToolPath.Text);
      if (sTemp != "")
      {
        MessageBox.Show(sTemp);
        return;
      }

      BackgroundWorker bw = new BackgroundWorker();
      //回報進程
      bw.WorkerReportsProgress = true;
      //加入DoWork
      bw.DoWork += new DoWorkEventHandler(Proc_DoWorkGetSrt);
      //加入ProgressChanged
      bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
      //加入RunWorkerCompleted
      bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerCompleted);
      //傳遞參數
      //object i = new object();
      //執行程序    
      bw.RunWorkerAsync(txtTransPath.Text);
      
    }

    private void btnBatUnZip_Click(object sender, EventArgs e)
    {
      ClearForm();

      //ShowStatus("啟動 解壓");

      BackgroundWorker bw = new BackgroundWorker();
      //回報進程
      bw.WorkerReportsProgress = true;
      //加入DoWork
      bw.DoWork += new DoWorkEventHandler(Proc_DoWorkUnRAR);
      //加入ProgressChanged
      bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
      //加入RunWorkerCompleted
      bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerCompleted);
      //傳遞參數
      //object i = new object();
      //執行程序
      bw.RunWorkerAsync(txtTransPath.Text);

    }


    private void ProcUnRAR(string sPath)
    {
      DirectoryInfo di = new DirectoryInfo(sPath);
      clsWinrar rar = new clsWinrar();


      //取得所有資料夾
      List<string> AllDiList = Directory.GetDirectories(di.FullName, "*.*", SearchOption.AllDirectories).ToList<string>();


      int idx = 0;
      //設定進度條
      lbltotal.Text = string.Format("{0} / {1}", idx, AllDiList.Count);
      progressBar2.Maximum = AllDiList.Count;
      foreach (string SubDiString in AllDiList)
      {
        DirectoryInfo SubDi = new DirectoryInfo(SubDiString);

        //判斷資料夾是否包含RAR檔案，不包含不處理
        if (SubDi.GetFiles("*.rar").Length == 0)
        {
          idx++;
          continue;
        };


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

        idx++;
        progressBar2.Value = idx;
        lbltotal.Text = string.Format("{0} / {1}", idx, AllDiList.Count);

      }

    }


    private void ProcGetSrt(string sPath)
    {
      FileInfo[] fiList = new DirectoryInfo(sPath).GetFiles("*.mkv", SearchOption.AllDirectories);

      int idx = 0;
      lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
      progressBar2.Maximum = fiList.Length;
      foreach (FileInfo item in fiList)
      {
        ShowStatus(string.Format("轉檔：{0}", item.FullName));
        ProcMkvExtractSubt(item);

        idx++;
        progressBar2.Value = idx;
        lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
      }
    }

    private void ProcRemoveFile(string sPath, string searchPattern)
    {
      FileInfo[] fiList = new DirectoryInfo(sPath).GetFiles(searchPattern, SearchOption.AllDirectories);

      int idx = 0;
      lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
      progressBar2.Maximum = fiList.Length;
      foreach (FileInfo item in fiList)
      {
        ShowRichTextStatus(string.Format("刪除：{0}", item.FullName));

        item.Attributes = FileAttributes.Normal;
        item.Delete();

        idx++;
        progressBar2.Value = idx;
        lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
      }
    }



    private void btnFileNameTune_Click(object sender, EventArgs e)
    {
      ClearForm();
      if (MessageBox.Show("確定要批次更新檔案名稱?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
      {
        return;
      }

      DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);

      List<FileInfo> tttt = di.GetFiles("*.*", SearchOption.AllDirectories)
        .Where(s => s.Extension.ToLower() == ".mkv" || s.Extension.ToLower() == ".mp4").ToList<FileInfo>();


      int idx = 0;
      lbltotal.Text = string.Format("{0} / {1}", idx, tttt.Count);
      progressBar2.Maximum = tttt.Count;
      foreach (FileInfo item in tttt)
      {
        string sNewFileName = item.Name.Replace(" ", "").Replace("(1)", "").Replace("(2)", "")
          .Replace("(ass)", "").Replace("(srt)", "");

        string sFullRename = Path.Combine(item.DirectoryName, sNewFileName);
        if (File.Exists(sFullRename) == false)
        {
          item.MoveTo(sFullRename);
        }

        idx++;
        progressBar2.Value = idx;
        lbltotal.Text = string.Format("{0} / {1}", idx, tttt.Count);
      }

      ShowStatus("批次更新檔案名稱 完成");
    }

    private void btnRemoveMKV_Click(object sender, EventArgs e)
    {
      ClearForm();
      //移除ini
      ProcRemoveFile(txtTransPath.Text, "*.mkv");
    }

    private void btnMergeMKV_Click(object sender, EventArgs e)
    {
      ClearForm();

      string sTemp = oTool005Helper.checkMkvToolExe(txtMkvToolPath.Text);
      if (sTemp != "")
      {
        MessageBox.Show(sTemp);
        return;
      }


      BackgroundWorker bw = new BackgroundWorker();
      //回報進程
      bw.WorkerReportsProgress = true;
      //加入DoWork
      bw.DoWork += new DoWorkEventHandler(Proc_DoWorkMergeMkvSrt);
      //加入ProgressChanged
      bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
      //加入RunWorkerCompleted
      bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerCompleted);
      //傳遞參數
      //object i = new object();
      //執行程序

      var p = new { path = txtTransPath.Text,
                    chksrt = radSRT.Checked,
                    chkass = radASS.Checked,
                    chkmp4 = radMP4.Checked,
                    chkmkv = radMKV.Checked
                  };
      bw.RunWorkerAsync(p);



    }



    private void ProcMergeMkvSrt(FileInfo fiMKV, FileInfo fiSubTitle)
    {
      //建立轉檔資料夾
      //string sMkvTrans = "MkvTrans";
      //Directory.CreateDirectory(Path.Combine(fiMKV.DirectoryName, sMkvTrans));

      string sMkvToolPath = txtMkvToolPath.Text;
      string sMkvtoolnixPath = Path.Combine(sMkvToolPath, "mkvmerge.exe");
      //string sMkvextractPath = Path.Combine(sMkvToolPath, "mkvextract.exe");
      //string sFilePath = pFileInfo.FullName;
      //FileInfo fi = new FileInfo(sFilePath);

      string sSubTitleType = "";
      if (fiSubTitle.Extension.ToUpper() == ".ASS") sSubTitleType = "(ass)";
      if (fiSubTitle.Extension.ToUpper() == ".SRT") sSubTitleType = "(srt)";


      //FileInfo fiTarget = new FileInfo(Path.Combine(
      //   fiMKV.DirectoryName, sMkvTrans, fiMKV.Name.Replace(fiMKV.Extension, "") + sSubTitleType + ".mkv"));
      FileInfo fiTarget = new FileInfo(Path.Combine(
         fiMKV.DirectoryName, fiMKV.Name.Replace(fiMKV.Extension, "") + sSubTitleType + ".mkv"));

      //取得資訊
      //string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" ", sMkvtoolnixPath, fiMKV.FullName);
      //List<string> TempList = ExecuteCommandSync(sGetInfoCommand);



      string sGetInfoCommand = string.Format(@"{0} -o ""{1}"" -S ""{2}"" ""{3}""", sMkvtoolnixPath, fiTarget.FullName, fiMKV.FullName, fiSubTitle.FullName);
      //sGetInfoCommand = string.Format(@"{0} -o {1} {2} {3}", sMkvtoolnixPath, fiTarget.FullName, fiMKV.FullName, fiSRT.FullName);
      ExecuteCommandSync(sGetInfoCommand);

    }

    private void ClearForm()
    {
      progressBar1.Value = 0;
      progressBar2.Value = 0;

      richTextBox1.Text = "";
      lblStatus.Text = "狀態";
      lbltotal.Text = "數量";

    }

    private void Proc_DoWorkGetSrt(object sender, DoWorkEventArgs e)
    {
      ReportInfo ri = new ReportInfo();
      BackgroundWorker bw = sender as BackgroundWorker;
      string sPath = e.Argument as string;

      FileInfo[] fiList = new DirectoryInfo(sPath).GetFiles("*.mkv", SearchOption.AllDirectories);

      int idx = 0;
      foreach (FileInfo item in fiList)
      {
        idx++;
        ri.Total = fiList.Length;
        ri.Idx = idx;
        ri.Msg = item.Name;
        bw.ReportProgress(1, ri);

        ProcMkvExtractSubt(item);
      }
      
      ri.Msg = "";
      bw.ReportProgress(1, ri);

    }

    private void Proc_DoWorkMergeMkvSrt(object sender, DoWorkEventArgs e)
    {
      ReportInfo ri = new ReportInfo();
      BackgroundWorker bw = sender as BackgroundWorker;

      dynamic p = e.Argument as dynamic;
      string sPath = p.path;
      Boolean bchksrt = p.chksrt;
      Boolean bchkass = p.chkass;
      Boolean bchkmkv = p.chkmkv;
      Boolean bchkmp4 = p.chkmp4;

      DirectoryInfo di = new DirectoryInfo(sPath);

      string sVideoType = "";
      if (bchkmp4 == true) sVideoType = "mp4";
      if (bchkmkv == true) sVideoType = "mkv";

      //取得所有影像資料
      FileInfo[] VideoList = di.GetFiles("*." + sVideoType, SearchOption.AllDirectories);

      int idx = 0;      
      foreach (FileInfo VideoItem in VideoList)
      {
        idx++;
        ri.Total = VideoList.Length;
        ri.Idx = idx;
        ri.Msg = "";

        string sSubTitleType = "";
        if (bchkass == true)
        {
          sSubTitleType = "ass";
          //搜尋符合的SubTilte
          DirectoryInfo diTemp = VideoItem.Directory;
          FileInfo[] fiSubTitleList = diTemp.GetFiles(
            string.Format("{0}*.{1}", VideoItem.Name.Replace(VideoItem.Extension, ""), sSubTitleType)
            , SearchOption.TopDirectoryOnly);

          if (fiSubTitleList.Length > 0)
          {
            ri.Msg = VideoItem.Name;
            bw.ReportProgress(1, ri);
            //執行合併檔案
            ProcMergeMkvSrt(VideoItem, fiSubTitleList[0]);
          }

        }

        if (bchksrt == true)
        {
          sSubTitleType = "srt";
          //搜尋符合的SubTilte
          DirectoryInfo diTemp = VideoItem.Directory;
          FileInfo[] fiSubTitleList = diTemp.GetFiles(
            string.Format("{0}*.{1}", VideoItem.Name.Replace(VideoItem.Extension, ""), sSubTitleType)
            , SearchOption.TopDirectoryOnly);

          if (fiSubTitleList.Length > 0)
          {
            ri.Msg = VideoItem.Name;
            bw.ReportProgress(1, ri);
            //執行合併檔案
            ProcMergeMkvSrt(VideoItem, fiSubTitleList[0]);
          }

        }
      }

      

      ri.Msg = "";
      bw.ReportProgress(1, ri);

    }

    private void Proc_DoWorkUnRAR(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker bw = sender as BackgroundWorker;
      string sPath = e.Argument as string;
      ReportInfo ri = new ReportInfo();

      DirectoryInfo di = new DirectoryInfo(sPath);
      clsWinrar rar = new clsWinrar();


      //取得所有資料夾
      List<string> AllDiList = Directory.GetDirectories(di.FullName, "*.*", SearchOption.AllDirectories).ToList<string>();


      int idx = 0;
      foreach (string SubDiString in AllDiList)
      {
        idx++;
        ri.Total = AllDiList.Count;
        ri.Idx = idx;
        ri.Msg = "";

        DirectoryInfo SubDi = new DirectoryInfo(SubDiString);

        string smark = "!@#$";
        foreach (FileInfo SubFi in SubDi.GetFiles("*.rar"))
        {
          //判斷是否有切割擋
          if (SubFi.Name.Contains(".part"))
          {
            if (SubFi.Name.Contains(smark)) continue;

            ri.Msg = SubFi.Name;
            bw.ReportProgress(1, ri);
            //解壓縮
            rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");

            //紀錄擋名
            smark = SubFi.Name.Substring(0, SubFi.Name.IndexOf(".part"));

          }
          else
          {
            ri.Msg = SubFi.Name;
            bw.ReportProgress(1, ri);

            rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");
          }

        }


      }

      ri.Msg = "";
      bw.ReportProgress(1, ri);

    }

    private void Proc_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {

      ReportInfo ri = e.UserState as ReportInfo;
      progressBar2.Maximum = ri.Total;
      progressBar2.Value = ri.Idx;

      lbltotal.Text = string.Format("{0} / {1}", ri.Idx, ri.Total);

      if (ri.Msg != "")
      {
        ShowRichTextStatus1(ri.Msg);
      }

    }
    private void Proc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      ShowRichTextStatus1(string.Format("[完成]{0}", ""));
    }

  }

  public class ReportInfo
  {
    int _Total = 0;
    int _Idx = 0;
    string _Msg = string.Empty;

    //public int Total { get; set; }
    //public int Idx { get; set; }
    //public string Msg { get; set; }

    public int Total
    {
      get
      {
        return _Total;
      }

      set
      {
        _Total = value;
      }
    }

    public int Idx
    {
      get
      {
        return _Idx;
      }

      set
      {
        _Idx = value;
      }
    }

    public string Msg
    {
      get
      {
        return _Msg;
      }

      set
      {
        _Msg = value;
      }
    }


    public void Clear()
    {
      _Total = 0;
      _Idx = 0;
      _Msg = string.Empty;
    }
  }

  public class Tool005Helper
  {


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
