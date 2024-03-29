﻿using M10.lib;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M10.lib.modelChrisTools;

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

            ddlFormatFile.SelectedIndex = 0;


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

            //取得Sqlite中記錄的資料
            txtMkvToolPath.Text = Comm.GetSetting(CTsConst.SettingList.Tool005_MkvToolPath);
            txtTransPath.Text = Comm.GetSetting(CTsConst.SettingList.Tool005_TransPath);




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
            return ExecuteCommandSync(command, null);
        }

        public List<string> ExecuteCommandSync(object command, BackgroundWorker bw)
        {
            List<string> ResultList = new List<string>();
            ReportInfo ri = new ReportInfo();

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

                    //轉換進度
                    //Progress: 19 %
                    if (line.Contains("Progress:") == true)
                    {
                        line = line.Replace("Progress:", "").Replace("%", "").Trim();

                        if (bw != null)
                        {
                            ri.Type = "sub";
                            ri.Total = 100;
                            ri.Idx = Convert.ToInt16(line);
                            ri.Msg = "";
                            bw.ReportProgress(1, ri);
                        }
                    }
                }

                // Get the output into a string
                //string result = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();

                // Display the command output.
                //Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                // Log the exception
            }

            return ResultList;
        }


        private void ProcMkvExtractSubt(FileInfo pFileInfo, BackgroundWorker bw)
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

                    //1070716 不擷取SUP
                    if (item.Contains("(HDMV PGS)") == true)
                    {
                        continue;
                    }


                    //取得軌道
                    string[] TrackSplit = item.Split(':');
                    string sTrackID = TrackSplit[0].Replace("Track ID ", "").Trim();
                    string sTrackType = TrackSplit[1].Replace("subtitles (", "").Replace(")", "").Trim();

                    //指定
                    if (TraceIDText.Text != "")
                    {
                        sTrackID = TraceIDText.Text;
                    }

                    string sCommandExt = string.Format(@"{0} tracks ""{1}"" {2}:""{3}.{4}"" "
                                                , sMkvextractPath
                                                , sFilePath
                                                , sTrackID
                                                , fi.FullName.Replace(fi.Extension, "")
                                                , TransExtension(sTrackType));

                    ExecuteCommandSync(sCommandExt, bw);

                    //只擷取一個字幕檔案
                    return;
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
                ProcMkvExtractSubt(item, null);

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


        private string FormatFileName(string FileName)
        {
            string sResult = FileName;

            sResult = sResult.Replace(" ", "").Replace("(1)", "").Replace("(2)", "")
                  .Replace("(ass)", "").Replace("(srt)", "").Replace("-1", "").Replace("(Encoded)", "")
                  .Replace("(dts)", "").Replace("(ac3)", "").Replace("(aac)", "");

            //1070909 預防RClone同步會出現判斷異常的問題。
            sResult = sResult.Replace("：", "-").Replace("？", "").Replace("「", "").Replace("」", "")
                .Replace("【", "").Replace("】", "");

            //全形轉半形
            sResult = Strings.StrConv(sResult, VbStrConv.Narrow);

            return sResult;
        }

        private void btnFileNameTune_Click(object sender, EventArgs e)
        {
            ClearForm();
            if (MessageBox.Show("確定要批次更新檔案名稱?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            //調整資料夾及檔案名稱
            ProcFileNameTune(txtTransPath.Text);

            ShowStatus("批次更新檔案名稱 完成");
        }


        /// <summary>
        /// 調整資料夾及檔案名稱
        /// </summary>
        /// <param name="sFilePath"></param>
        private void ProcFileNameTune(string sFilePath)
        {
            //DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);
            DirectoryInfo di = new DirectoryInfo(sFilePath);

            List<FileInfo> tttt = di.GetFiles("*.*", SearchOption.AllDirectories)
              .Where(s => s.Extension.ToLower() == ".mkv" || s.Extension.ToLower() == ".mp4").ToList<FileInfo>();


            int idx = 0;
            lbltotal.Text = string.Format("{0} / {1}", idx, tttt.Count);
            progressBar2.Maximum = tttt.Count;
            foreach (FileInfo item in tttt)
            {
                if (item.Name != Strings.StrConv(item.Name, VbStrConv.Narrow))
                {
                    ShowRichTextStatus1(string.Format("{0} => {1}", item.Name, Strings.StrConv(item.Name, VbStrConv.Narrow)));
                }

                string sNewFileName = FormatFileName(item.Name);

                string sFullRename = Path.Combine(item.DirectoryName, sNewFileName);
                if (File.Exists(sFullRename) == false)
                {
                    item.MoveTo(sFullRename);
                }

                idx++;
                progressBar2.Value = idx;
                lbltotal.Text = string.Format("{0} / {1}", idx, tttt.Count);
            }


            //取得所有資料夾
            DirectoryInfo[] DiList = di.GetDirectories("*", SearchOption.AllDirectories);
            for (int i = DiList.Length - 1; i >= 0; i--)
            {
                DirectoryInfo disub = DiList[i];

                if (disub.Name != Strings.StrConv(disub.Name, VbStrConv.Narrow))
                {
                    ShowRichTextStatus1(string.Format("{0} => {1}", disub.Name, Strings.StrConv(disub.Name, VbStrConv.Narrow)));
                }

                string sNewFullName = Path.Combine(disub.Parent.FullName, disub.Name.Replace("：", "-"));

                sNewFullName = sNewFullName.Replace("？", "").Replace("「", "").Replace("」", "")
                    .Replace("【", "").Replace("】", "");

                //全形轉半形
                sNewFullName = Strings.StrConv(sNewFullName, VbStrConv.Narrow);

                if (Directory.Exists(sNewFullName) == false)
                {
                    //資料夾名稱，名稱"："取代"-"
                    Directory.Move(disub.FullName, sNewFullName);
                }
            }

            //取得所有檔案
            FileInfo[] fiList = di.GetFiles("*", SearchOption.AllDirectories);
            for (int i = fiList.Length - 1; i >= 0; i--)
            {
                FileInfo fisub = fiList[i];

                string sNewFullName = Path.Combine(fisub.DirectoryName, fisub.Name.Replace("：", "-"));
                if (File.Exists(sNewFullName) == false)
                {
                    //檔案名稱，名稱"："取代"-"
                    File.Move(fisub.FullName, sNewFullName);
                }
            }

            //最後處理目前的資料夾名稱
            string sNewFullName1 = Path.Combine(di.Parent.FullName, di.Name.Replace("：", "-"));
            sNewFullName1 = sNewFullName1.Replace("？", "").Replace("「", "").Replace("」", "")
                    .Replace("【", "").Replace("】", ""); ;
            //全形轉半形
            sNewFullName1 = Strings.StrConv(sNewFullName1, VbStrConv.Narrow);


            if (Directory.Exists(sNewFullName1) == false)
            {
                //資料夾名稱，名稱"："取代"-"
                Directory.Move(di.FullName, sNewFullName1);
            }

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

            var p = new
            {
                path = txtTransPath.Text,
                chksrt = radSRT.Checked,
                chkass = radASS.Checked,
                chkmp4 = radMP4.Checked,
                chkmkv = radMKV.Checked
            };
            bw.RunWorkerAsync(p);



        }



        private void ProcMergeMkvSrt(FileInfo fiMKV, FileInfo fiSubTitle, string sPathSave, BackgroundWorker bw)
        {
            //建立轉檔資料夾
            //string sMkvTrans = "MkvTrans";
            //Directory.CreateDirectory(Path.Combine(fiMKV.DirectoryName, sMkvTrans));

            string sMkvToolPath = txtMkvToolPath.Text;
            string sMkvtoolnixPath = Path.Combine(sMkvToolPath, "mkvmerge.exe");

            string sSubTitleType = "";
            if (fiSubTitle.Extension.ToUpper() == ".ASS") sSubTitleType = "(ass)";
            if (fiSubTitle.Extension.ToUpper() == ".SRT") sSubTitleType = "(srt)";

            //1090811 改存到指定資料夾中
            //FileInfo fiTarget = new FileInfo(Path.Combine(
            //   fiMKV.DirectoryName, fiMKV.Name.Replace(fiMKV.Extension, "") + sSubTitleType + ".mkv"));
            FileInfo fiTarget = new FileInfo(Path.Combine(
               sPathSave, fiMKV.Name.Replace(fiMKV.Extension, "") + sSubTitleType + ".mkv"));

            //取得資訊
            //string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" ", sMkvtoolnixPath, fiMKV.FullName);
            //List<string> TempList = ExecuteCommandSync(sGetInfoCommand);

            string sGetInfoCommand = string.Format(@"{0} -o ""{1}"" -S ""{2}"" ""{3}""", sMkvtoolnixPath, fiTarget.FullName, fiMKV.FullName, fiSubTitle.FullName);
            //sGetInfoCommand = string.Format(@"{0} -o {1} {2} {3}", sMkvtoolnixPath, fiTarget.FullName, fiMKV.FullName, fiSRT.FullName);
            ExecuteCommandSync(sGetInfoCommand, bw);

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

                ProcMkvExtractSubt(item, bw);
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
            
            string sPathMkvASS = Path.Combine(sPath, "Mkv-Ass", di.Name);
            string sPathMkvSRT = Path.Combine(sPath, "Mkv-Srt", di.Name);


            string sVideoType = "";
            if (bchkmp4 == true) sVideoType = "mp4";
            if (bchkmkv == true)
            {
                sVideoType = "mkv";
                Directory.CreateDirectory(sPathMkvASS);
                Directory.CreateDirectory(sPathMkvSRT);
            }

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
                        ProcMergeMkvSrt(VideoItem, fiSubTitleList[0], sPathMkvASS, bw);
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
                        ProcMergeMkvSrt(VideoItem, fiSubTitleList[0], sPathMkvSRT, bw);
                    }

                }
            }

            //最後進行檔案名稱正規劃
            ProcFileNameTune(sPathMkvASS);
            ProcFileNameTune(sPathMkvSRT);


            //壓縮資料夾
            RarFolderAll(sPathMkvSRT);


            ri.Msg = "";
            bw.ReportProgress(1, ri);
            var oResult = new
            {
                path = p.path
            };

            e.Result = oResult;
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

        private void Proc_DoWorkRAR(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            dynamic p = e.Argument as dynamic;
            string sPath = p.path;
            //string sPath = e.Argument as string;
            ReportInfo ri = new ReportInfo();

            DirectoryInfo di = new DirectoryInfo(sPath);
            clsWinrar rar = new clsWinrar();


            //取得所有資料夾
            //List<string> AllDiList = Directory.GetDirectories(di.FullName, "*.*", SearchOption.AllDirectories).ToList<string>();
            //取得所有MKV檔案
            List<string> AllFiList = Directory.GetFiles(di.FullName, "*.mkv", SearchOption.AllDirectories).ToList<string>();

            int idx = 0;
            foreach (string SubFiString in AllFiList)
            {
                idx++;
                ri.Total = AllFiList.Count;
                ri.Idx = idx;
                ri.Msg = "";

                FileInfo SubFi = new FileInfo(SubFiString);

                ri.Msg = SubFi.Name;
                bw.ReportProgress(1, ri);
                //解壓縮
                //rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");

                rar.CompressRAR(SubFi.FullName.Replace(SubFi.Extension, ""), SubFi.FullName, "5g");


                //string smark = "!@#$";
                //foreach (FileInfo SubFi in SubDi.GetFiles("*.rar"))
                //{
                //  //判斷是否有切割擋
                //  if (SubFi.Name.Contains(".part"))
                //  {
                //    if (SubFi.Name.Contains(smark)) continue;

                //    ri.Msg = SubFi.Name;
                //    bw.ReportProgress(1, ri);
                //    //解壓縮
                //    rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");

                //    //紀錄擋名
                //    smark = SubFi.Name.Substring(0, SubFi.Name.IndexOf(".part"));

                //  }
                //  else
                //  {
                //    ri.Msg = SubFi.Name;
                //    bw.ReportProgress(1, ri);

                //    rar.unCompressRAR(SubFi, SubFi.Directory, "pass@word1");
                //  }

                //}


            }

            ri.Msg = "";
            bw.ReportProgress(1, ri);

            //參數傳遞到Completed中
            e.Result = e.Argument;

        }

        private void Proc_DoWorkRARAllFolder(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            dynamic p = e.Argument as dynamic;
            string sPath = p.path;
            //string sPath = e.Argument as string;
            ReportInfo ri = new ReportInfo();

            //壓縮資料夾內容
            RarFolderAll(sPath);

            ri.Msg = "";
            bw.ReportProgress(1, ri);

            //參數傳遞到Completed中
            e.Result = e.Argument;
        }

        private void Proc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            ReportInfo ri = e.UserState as ReportInfo;

            if (ri.Type == "sub")
            {
                progressBar1.Maximum = ri.Total;
                progressBar1.Value = ri.Idx;
            }
            else
            {
                progressBar2.Maximum = ri.Total;
                progressBar2.Value = ri.Idx;

                lbltotal.Text = string.Format("{0} / {1}", ri.Idx, ri.Total);

                if (ri.Msg != "")
                {
                    ShowRichTextStatus1(ri.Msg);
                }
            }


        }

        private void Proc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowRichTextStatus1(string.Format("[完成]{0}", ""));
        }

        private void Proc_RunWorkerRARCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dynamic p = e.Result as dynamic;
            string sPath = p.path;
            string scaller = p.caller;

            //特定呼叫程序處理方法
            if (scaller == "Finish256MKVSRT" || scaller == "RarFolderAll")
            {
                //完成壓縮檔移除非RAR檔案
                FileInfo[] FileList = new DirectoryInfo(sPath).GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (FileInfo item in FileList)
                {
                    if (item.Extension.ToLower() == ".rar" == false)
                    {
                        item.Delete();
                    }
                }
            }

            ShowRichTextStatus1(string.Format("[完成]壓縮檔案完成：{0}", sPath));
        }

        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,

                FileShare.None);

                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false沒有使用  
        }

        private void Proc_RunWorkerFinish256MKVSRTCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            dynamic p = e.Result as dynamic;
            string sPath = p.path;

            //整理預備壓縮資料夾的內容
            FileInfo[] FileList = new DirectoryInfo(sPath).GetFiles("*.*", SearchOption.TopDirectoryOnly);

            //移除非MKV檔案
            foreach (FileInfo item in FileList)
            {
                if (item.Extension.ToLower() != ".mkv")
                {
                    item.Delete();
                }
            }

            FileList = new DirectoryInfo(sPath).GetFiles("*.*", SearchOption.TopDirectoryOnly);
            //如果MKV不只有一個檔案，代表已經合併過，才進行篩選檔案
            if (FileList.Length > 1)
            {
                foreach (FileInfo item in FileList)
                {
                    if (item.Name.Contains("(srt)") == false)
                    {
                        item.Delete();
                    }
                }
            }

            //重新命名檔案
            FileList = new DirectoryInfo(sPath).GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo item in FileList)
            {
                string sFullRename = Path.Combine(item.DirectoryName, FormatFileName(item.Name));
                if (File.Exists(sFullRename) == false)
                {
                    item.MoveTo(sFullRename);
                }
            }

            ShowRichTextStatus1(string.Format("[完成]MKV與SRT合併：{0}", sPath));

            BackgroundWorker bw = new BackgroundWorker();
            //回報進程
            bw.WorkerReportsProgress = true;
            //加入DoWork
            bw.DoWork += new DoWorkEventHandler(Proc_DoWorkRAR);
            //加入ProgressChanged
            bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
            //加入RunWorkerCompleted
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerRARCompleted);
            //傳遞參數
            //object i = new object();
            var op = new
            {
                path = sPath,
                caller = "Finish256MKVSRT"
            };

            //執行程序
            bw.RunWorkerAsync(op);
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);
            DirectoryInfo[] DiList = di.GetDirectories("*", SearchOption.AllDirectories);

            int idx = 0;
            lbltotal.Text = string.Format("{0} / {1}", idx, DiList.Length);
            progressBar2.Maximum = DiList.Length;
            foreach (DirectoryInfo item in DiList)
            {
                string sPathOld = Path.Combine(item.FullName, "Old");
                string sPathNew = Path.Combine(item.FullName, "New");
                Directory.CreateDirectory(sPathOld);
                Directory.CreateDirectory(sPathNew);


                List<FileInfo> FileList = di.GetFiles("*.*", SearchOption.AllDirectories)
                  .Where(s => s.Extension.ToLower() == ".mkv" || s.Extension.ToLower() == ".mp4").ToList<FileInfo>();

                foreach (FileInfo fi in FileList)
                {
                    if (fi.Name.Contains("-1") == true)
                    {
                        fi.MoveTo(Path.Combine(sPathNew, fi.Name));
                    }
                    else
                    {
                        fi.MoveTo(Path.Combine(sPathOld, fi.Name));
                    }
                }


                idx++;
                progressBar2.Value = idx;
                lbltotal.Text = string.Format("{0} / {1}", idx, FileList.Count);
            }

            ShowStatus("分類檔案 完成");
        }

        private void btnFinish265_Click(object sender, EventArgs e)
        {
            ClearForm();

            DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);
            if (di.Exists == false)
            {
                ShowRichTextStatus("資料夾不存在");
                return;
            }

            string sPathMp4 = Path.Combine(di.Parent.FullName, "MP4");
            string sPathRar = Path.Combine(di.Parent.FullName, "RAR");
            //建立MP4資料夾
            Directory.CreateDirectory(sPathMp4);
            //建立RAR資料夾
            Directory.CreateDirectory(sPathRar);

            //取得所有資料夾
            DirectoryInfo[] diAll = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
            List<DirectoryInfo> liAll = diAll.ToList();
            //如果沒底下資料夾代表，本身資料夾進行程序
            if (liAll.Count == 0) liAll.Add(di);

            //處理MP4
            foreach (DirectoryInfo diSub in liAll)
            {
                //取得該資料夾中的檔案(副檔名mkv、mp4、ass、srt)
                List<FileInfo> fiAllFiles = diSub.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.Extension.ToLower() == ".mp4").ToList<FileInfo>();

                foreach (FileInfo item in fiAllFiles)
                {
                    DirectoryInfo ItemDi = new DirectoryInfo(item.DirectoryName);
                    string sMoveToPath = Path.Combine(sPathMp4, ItemDi.Name);
                    Directory.CreateDirectory(sMoveToPath);

                    string sFullRename = Path.Combine(sMoveToPath, FormatFileName(item.Name));
                    if (File.Exists(sFullRename) == false)
                    {
                        item.MoveTo(sFullRename);
                    }

                }
            }

            //處理MKV與SRT移動到RAR資料夾
            foreach (DirectoryInfo diSub in liAll)
            {
                //取得該資料夾中的檔案(副檔名mkv、mp4、ass、srt)
                List<FileInfo> fiAllFiles = diSub.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.Extension.ToLower() == ".mkv" || s.Extension.ToLower() == ".srt").ToList<FileInfo>();

                foreach (FileInfo item in fiAllFiles)
                {
                    DirectoryInfo ItemDi = new DirectoryInfo(item.DirectoryName);
                    string sMoveToPath = Path.Combine(sPathRar, ItemDi.Name);
                    Directory.CreateDirectory(sMoveToPath);

                    if (item.Extension.ToLower() == ".mkv")
                    {
                        if (item.Name.Contains("(ass)") == true)
                        {
                            continue;
                        }

                        string sFullRename = Path.Combine(sMoveToPath, FormatFileName(item.Name));
                        if (File.Exists(sFullRename) == false)
                        {
                            item.MoveTo(sFullRename);
                        }
                    }

                    if (item.Extension.ToLower() == ".srt")
                    {
                        string sFullRename = Path.Combine(sMoveToPath, FormatFileName(item.Name));
                        if (File.Exists(sFullRename) == false)
                        {
                            item.MoveTo(sFullRename);
                        }
                    }


                }
            }

            //處理MKV與SRT合併
            //取得所有資料夾
            DirectoryInfo[] diRAR = new DirectoryInfo(sPathRar).GetDirectories("*", SearchOption.TopDirectoryOnly);

            foreach (DirectoryInfo info in diRAR)
            {
                //資料夾如果存在RAR檔案，則不處理
                List<FileInfo> listFiRar = info.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(s => s.Extension.ToLower() == ".rar").ToList<FileInfo>();
                if (listFiRar.Count > 0) continue;

                BackgroundWorker bw = new BackgroundWorker();
                //回報進程
                bw.WorkerReportsProgress = true;
                //加入DoWork
                bw.DoWork += new DoWorkEventHandler(Proc_DoWorkMergeMkvSrt);
                //加入ProgressChanged
                bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
                //加入RunWorkerCompleted
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerFinish256MKVSRTCompleted);
                //傳遞參數
                //object i = new object();
                //執行程序

                var p = new
                {
                    path = info.FullName,
                    chksrt = true,
                    chkass = false,
                    chkmp4 = false,
                    chkmkv = true
                };
                bw.RunWorkerAsync(p);
            }
        }

        private void btnAddRAR_Click(object sender, EventArgs e)
        {
            ClearForm();

            //ShowStatus("啟動 解壓");

            BackgroundWorker bw = new BackgroundWorker();
            //回報進程
            bw.WorkerReportsProgress = true;
            //加入DoWork
            bw.DoWork += new DoWorkEventHandler(Proc_DoWorkRAR);
            //加入ProgressChanged
            bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
            //加入RunWorkerCompleted
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerRARCompleted);
            //傳遞參數
            //object i = new object();
            var op = new
            {
                path = txtTransPath.Text,
                caller = ""
            };
            //執行程序
            bw.RunWorkerAsync(op);

        }

        /// <summary>
        /// 多執行緒進行壓縮資料夾中的內容
        /// </summary>
        /// <param name="sFolderPath">目標資料夾路徑</param>
        private void RarFolderAllByThread(string sFolderPath) 
        {
            BackgroundWorker bw = new BackgroundWorker();
            //回報進程
            bw.WorkerReportsProgress = true;
            //加入DoWork
            bw.DoWork += new DoWorkEventHandler(Proc_DoWorkRARAllFolder);
            //加入ProgressChanged
            bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
            //加入RunWorkerCompleted
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerRARCompleted);
            //傳遞參數
            //object i = new object();
            var op = new
            {
                path = sFolderPath,
                caller = "RarFolderAll"
            };
            //執行程序
            bw.RunWorkerAsync(op);
        }

        /// <summary>
        /// 壓縮資料夾中的內容
        /// </summary>
        /// <param name="sFolderPath">目標資料夾路徑</param>
        private void RarFolderAll(string sFolderPath)
        {
            DirectoryInfo di = new DirectoryInfo(sFolderPath);
            clsWinrar rar = new clsWinrar();

            //目標資料夾
            string sPathTarget = Path.Combine(di.FullName, di.Name);

            //取得原本存在資料夾清單
            List<string> AllDirectoryList = Directory.GetDirectories(di.FullName, "*", SearchOption.TopDirectoryOnly).ToList<string>();

            //取得原本存在檔案清單
            List<string> AllFileList = Directory.GetFiles(di.FullName, "*.*", SearchOption.TopDirectoryOnly).ToList<string>();

            //建立相同名稱資料夾
            Directory.CreateDirectory(sPathTarget);

            //移動所有資料夾到目標資料夾中
            foreach (string SubString in AllDirectoryList)
            {
                DirectoryInfo diSub = new DirectoryInfo(SubString);
                Directory.Move(SubString, Path.Combine(sPathTarget, diSub.Name));
            }

            //移動所有檔案到目標資料夾中
            foreach (string SubString in AllFileList)
            {
                FileInfo fiSub = new FileInfo(SubString);
                File.Move(SubString, Path.Combine(sPathTarget, fiSub.Name));
            }

            //壓縮資料夾
            rar.CompressRAR(Path.Combine(di.FullName, di.Name), sPathTarget, "5g");

            //刪除資料夾
            Utils.DeleteDirectory(sPathTarget);
        }


        private void btnSaveAsSrt_Click(object sender, EventArgs e)
        {
            string sDirectoryPath = @"c:\temp\SaveAsSrt";
            Directory.CreateDirectory(sDirectoryPath);

            FileInfo[] fiList = new DirectoryInfo(txtTransPath.Text).GetFiles("*.srt", SearchOption.AllDirectories);

            int idx = 0;
            lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
            progressBar2.Maximum = fiList.Length;
            foreach (FileInfo item in fiList)
            {
                ShowRichTextStatus(string.Format("複製：{0}", item.FullName));



                item.CopyTo(Path.Combine(sDirectoryPath, item.Name), true);

                //item.Attributes = FileAttributes.Normal;
                //item.Delete();

                idx++;
                progressBar2.Value = idx;
                lbltotal.Text = string.Format("{0} / {1}", idx, fiList.Length);
            }
        }

        /// <summary>
        /// 檔名與資料夾正規化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReguName_Click(object sender, EventArgs e)
        {

            DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);

            ShowStatus("檔案及資料夾名稱，修正完成");
        }

        private void BtnFormatFile_Click(object sender, EventArgs e)
        {
            ClearForm();
            //if (MessageBox.Show("確定要批次更新檔案名稱?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    return;
            //}

            DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);
            if (di.Exists == false)
            {
                ShowRichTextStatus("資料夾不存在");
                return;
            }

            //取得所有資料夾
            DirectoryInfo[] diAll = di.GetDirectories("*", SearchOption.AllDirectories);
            List<DirectoryInfo> liAll = diAll.ToList();
            liAll.Add(di);


            foreach (DirectoryInfo diSub in liAll)
            {
                //取得該資料夾中的檔案(副檔名mkv、mp4、ass、srt)
                List<FileInfo> fiAllFiles = diSub.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.Extension.ToLower() == ".mkv" || s.Extension.ToLower() == ".mp4"
                         || s.Extension.ToLower() == ".ass" || s.Extension.ToLower() == ".srt").ToList<FileInfo>();

                //判斷資料夾是否已經格式化，如果不符合則不執行修改程序
                if (diSub.Name.Contains("[") == false || diSub.Name.Contains("]") == false)
                {
                    continue;
                }

                //解析資料夾轉成檔案名稱
                string sYear = diSub.Name.Substring(1, 4);
                string sMovieNameMain = diSub.Name.Substring(6, diSub.Name.Length - 6);
                string sMovieNameSub = "";

                if (sMovieNameMain.Contains("-") == true)
                {
                    sMovieNameSub = sMovieNameMain.Split('-')[1];
                    sMovieNameMain = sMovieNameMain.Split('-')[0];
                }

                //[歐美]巧克力冒險工廠(2005)[英語][官譯]
                string sFileNameFull = string.Format("{0}{1}({2}){3}{4}"
                    , ddlFormatFile.SelectedItem.ToString().Split('-')[0]
                    , sMovieNameMain
                    , sYear
                    , sMovieNameSub == "" ? "" : "-" + sMovieNameSub
                    , ddlFormatFile.SelectedItem.ToString().Split('-')[1]);

                //重新命名所有檔案
                foreach (FileInfo item in fiAllFiles)
                {
                    string sFullRename = Path.Combine(item.DirectoryName, sFileNameFull + item.Extension);
                    if (File.Exists(sFullRename) == false)
                    {
                        item.MoveTo(sFullRename);
                    }
                }
            }


            ShowRichTextStatus1("檔案及資料夾名稱，修正完成");

        }

        private void test_Click(object sender, EventArgs e)
        {
            //最後處理目前的資料夾名稱
            //string sNewFullName1 = Path.Combine(di.Parent.FullName, di.Name.Replace("：", "-"));
            //sNewFullName1 = sNewFullName1.Replace("？", "").Replace("「", "").Replace("」", "")
            //        .Replace("【", "").Replace("】", ""); ;

            string sNewFullName1 = "：？「」【】";
            //全形轉半形
            sNewFullName1 = Strings.StrConv(sNewFullName1, VbStrConv.Narrow, 1028);

            sNewFullName1 = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {

            DirectoryInfo di = new DirectoryInfo(txtTransPath.Text);
            clsWinrar rar = new clsWinrar();

            //目標資料夾
            string sPathTarget = Path.Combine(di.FullName, di.Name);

            //取得原本存在資料夾清單
            List<string> AllDirectoryList = Directory.GetDirectories(di.FullName, "*", SearchOption.TopDirectoryOnly).ToList<string>();

            //取得原本存在檔案清單
            List<string> AllFileList = Directory.GetFiles(di.FullName, "*.*", SearchOption.TopDirectoryOnly).ToList<string>();

            //建立相同名稱資料夾
            Directory.CreateDirectory(sPathTarget);

            //移動所有資料夾到目標資料夾中
            foreach (string SubString in AllDirectoryList)
            {
                DirectoryInfo diSub = new DirectoryInfo(SubString);
                Directory.Move(SubString, Path.Combine(sPathTarget, diSub.Name));
            }

            //移動所有檔案到目標資料夾中
            foreach (string SubString in AllFileList)
            {
                FileInfo fiSub = new FileInfo(SubString);
                File.Move(SubString, Path.Combine(sPathTarget, fiSub.Name));
            }


            rar.CompressRAR(Path.Combine(di.FullName, di.Name), sPathTarget, "5g");


            Utils.DeleteDirectory(sPathTarget);
            

            return;
            string path = @"d:\tblRainError_log.sql";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(path, appendText, Encoding.UTF8);

            // Open the file to read from.
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);

            return;
        }

        private async void btnProcSRTASS_Click(object sender, EventArgs e)
        {
            //產生SrtAss，網路檢體轉繁體
            ProcSRTASS(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //產生SrtAss
            ProcSRTASS(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsTransToTC">是否簡體轉繁體</param>
        private async void ProcSRTASS(bool IsTransToTC)         
        {

            List<string> FileList = new List<string>();
            List<SubTitleInfo> AllSubTitleFileList = new List<SubTitleInfo>();
            //Dictionary<string, List<SrtInfo>> AllSrtCollection = new Dictionary<string, List<SrtInfo>>();

            //判斷資料夾中的字幕檔格式(SRT)
            FileInfo[] fiListSrt = new DirectoryInfo(txtTransPath.Text).GetFiles("*.srt", SearchOption.TopDirectoryOnly);

            //解析SRT
            foreach (FileInfo fi in fiListSrt)
            {
                //檔案名稱存在就不進行轉檔
                if (AllSubTitleFileList.Find(r => r.SubTitleFileName == fi.Name.Replace(fi.Extension, "")) != null)
                {
                    continue;
                }

                SubTitleInfo oSubTitleInfo = new SubTitleInfo();
                oSubTitleInfo.SubTitleFileName = fi.Name.Replace(fi.Extension, "");
                
                string text = File.ReadAllText(fi.FullName, Encoding.UTF8);
                List<string> StringList = text.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList<string>();

                //字幕清單
                List<SrtInfo> siList = new List<SrtInfo>();
                SrtInfo si = new SrtInfo();
                Boolean bIsStart = false;
                foreach (string LoopItem in StringList)
                {
                    //空白代表一個字幕的內容，加入清單中
                    if (LoopItem == "")
                    {
                        //有資料才新增到字幕清單中
                        if (si.Start != "") siList.Add(si);

                        si = new SrtInfo();
                        bIsStart = false;
                        continue;
                    }

                    //代表取得時間區間資料
                    if (LoopItem.Contains(" --> ") == true)
                    {
                        //註記下一個為字幕起始
                        bIsStart = true;

                        string[] times = LoopItem.Split(new string[1] { " --> " }, StringSplitOptions.RemoveEmptyEntries);

                        si.Start = times[0];
                        si.End = times[1];
                        continue;
                    }
                    //存入字幕序列中
                    if (bIsStart == true)
                    {
                        string sTemp = LoopItem;
                        //排除文字內容異常格式，導致轉檔異常
                        sTemp = sTemp.Replace("&lrm;", "");

                        si.ContentList.Add(sTemp);
                    }
                }

                oSubTitleInfo.SrtInfoList = siList;
                AllSubTitleFileList.Add(oSubTitleInfo);
                
            }

            //判斷資料夾中的字幕檔格式(ASS)
            FileInfo[] fiListass = new DirectoryInfo(txtTransPath.Text).GetFiles("*.ass", SearchOption.TopDirectoryOnly);
            //解析ASS
            foreach (FileInfo fi in fiListass)
            {
                //檔案名稱存在就不進行轉檔
                if (AllSubTitleFileList.Find(r => r.SubTitleFileName == fi.Name.Replace(fi.Extension, "")) != null)
                {
                    continue;
                }

                SubTitleInfo oSubTitleInfo = new SubTitleInfo();
                oSubTitleInfo.SubTitleFileName = fi.Name.Replace(fi.Extension, "");

                string text = File.ReadAllText(fi.FullName, Encoding.UTF8);
                List<string> StringList = text.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList<string>();

                //字幕清單
                List<SrtInfo> siList = new List<SrtInfo>();
                SrtInfo si = new SrtInfo();
                Boolean bIsStart = false;
                foreach (string LoopItem in StringList)
                {
                    if (LoopItem == "") continue;

                    //代表取得時間區間資料
                    if (LoopItem.Contains("[Events]") == true)
                    {
                        //註記下一個為字幕起始
                        bIsStart = true;
                        continue;
                    }

                    //存入字幕序列中
                    if (bIsStart == true)
                    {
                        si = new SrtInfo();

                        string[] Formats = LoopItem.Split(',');

                        //排除格式行
                        if (Formats[0] == "Format: Layer") continue;

                        //轉換為SRT時間格式(0:08:45.73 => 00:27:14,750)
                        si.Start = ConvertToSrtTime(Formats[1]);
                        si.End = ConvertToSrtTime(Formats[2]);

                        string[] Contents = Formats[9].Split(new string[] { "\\N" }, StringSplitOptions.None);
                        foreach (string item in Contents)
                        {
                            string sTemp = item;
                            //排除文字內容異常格式，導致轉檔異常
                            sTemp = sTemp.Replace("&lrm;", "");

                            si.ContentList.Add(sTemp);
                        }

                        //新增到清單中
                        siList.Add(si);

                    }
                }

                oSubTitleInfo.SrtInfoList = siList;
                AllSubTitleFileList.Add(oSubTitleInfo);                
            }


            //原始檔案移動到Old資料夾
            string sPathTempOld = Path.Combine(txtTransPath.Text, "Old");
            Directory.CreateDirectory(sPathTempOld);
            foreach (FileInfo item in fiListSrt)
            {
                if (File.Exists(Path.Combine(sPathTempOld, item.Name)) == true)
                {
                    File.Delete(Path.Combine(sPathTempOld, item.Name));
                }
                item.MoveTo(Path.Combine(sPathTempOld, item.Name));
            }
            foreach (FileInfo item in fiListass)
            {
                if (File.Exists(Path.Combine(sPathTempOld, item.Name)) == true)
                {
                    File.Delete(Path.Combine(sPathTempOld, item.Name));
                }
                item.MoveTo(Path.Combine(sPathTempOld, item.Name));
            }

            //建立暫存資料夾
            string sTempSrtPath = txtTransPath.Text;
            string sTempASSPath = txtTransPath.Text;

            //簡體轉繁體+產生SrtAss
            if (IsTransToTC == true)
            {
                int iIdxFile = 1;
                foreach (SubTitleInfo item in AllSubTitleFileList)
                {
                    try
                    {
                        //簡體轉繁體
                        int iIdx = 1;
                        foreach (SrtInfo si in item.SrtInfoList)
                        {
                            BaseShowStatus(string.Format("[檔案{3}/{4}][數量{0}/{1}]簡體轉繁體-{2}",
                            iIdx.ToString(), item.SrtInfoList.Count(), item.SubTitleFileName
                            , iIdxFile.ToString(), AllSubTitleFileList.Count()));
                            List<string> TempList = new List<string>();

                            foreach (string Content in si.ContentList)
                            {
                                TempList.Add(await ConvertToTC(Content));
                            }

                            si.ContentList = TempList;

                            iIdx++;
                        }
                    }
                    catch (Exception ex)
                    {
                        iIdxFile++;
                        continue;
                    }

                    //產生SrtAss
                    //建立Srt檔案
                    string sFullFileName = Path.Combine(sTempSrtPath, item.SubTitleFileName + ".srt");
                    SrtHelper.DoSrtDataToSrtFile(sFullFileName, item.SrtInfoList);
                    //建立Ass檔案
                    sFullFileName = Path.Combine(sTempASSPath, item.SubTitleFileName + ".ass");
                    SrtHelper.DoAssDataToAssFile(sFullFileName, item.SrtInfoList);

                    iIdxFile++;
                }
            }

            //產生SrtAss
            if (IsTransToTC == false)
            {
                //字幕資料轉SRT格式
                foreach (SubTitleInfo item in AllSubTitleFileList)
                {
                    //建立檔案
                    string sFullFileName = Path.Combine(sTempSrtPath, item.SubTitleFileName + ".srt");
                    SrtHelper.DoSrtDataToSrtFile(sFullFileName, item.SrtInfoList);
                }


                //字幕資料轉ASS格式
                foreach (SubTitleInfo item in AllSubTitleFileList)
                {
                    //建立檔案
                    string sFullFileName = Path.Combine(sTempASSPath, item.SubTitleFileName + ".ass");
                    SrtHelper.DoAssDataToAssFile(sFullFileName, item.SrtInfoList);
                }
            }
        }



        /// <summary>
        /// ASS時間格式轉換SRT時間格式(0:08:45.73 => 00:27:14,750)
        /// </summary>
        /// <param name="sAssTime"></param>
        /// <returns></returns>
        private string ConvertToSrtTime(string sAssTime)
        {
            string result = string.Empty;

            string[] ass = sAssTime.Split(new char[] { ':', '.' });

            result = string.Format("{0}:{1}:{2},{3}", ass[0].PadLeft(2, '0'), ass[1], ass[2], ass[3].PadRight(3, '0'));

            return result;
        }

        


        /// <summary>
        /// 簡體轉繁體 Call API From 繁化姬 
        /// </summary>
        /// <param name="sSource"></param>
        /// <returns></returns>
        private async Task<string> ConvertToTC(string sSource)
        {
            string sResult = "";

            try
            {
                using (var client = new HttpClient())
                {
                    //client.Timeout = TimeSpan.FromSeconds(3);
                    string ss = "http://api.zhconvert.org/convert?converter=Traditional&text=" + sSource;
                    HttpResponseMessage response = await client.GetAsync(ss);

                    //如果失敗會錯誤
                    response.EnsureSuccessStatusCode();
                        
                    //回傳轉為JSON文字
                    var customerJsonString = response.Content.ReadAsStringAsync();

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    //var deserialized = JsonConvert.DeserializeObject(customerJsonString);

                    JObject jobj = JObject.Parse(customerJsonString.Result);
                    sResult = jobj["data"]["text"].ToString();
                }
            }
            catch (Exception ex)
            {   
                sResult = sSource;
                throw new Exception("[呼叫繁化姬轉檔異常]無法連線至，請確認連線狀態");
            }
            

            return sResult;
        }

        private void TraceIDText_MouseClick(object sender, MouseEventArgs e)
        {
            TraceIDText.SelectAll();
        }
    }



    public class ReportInfo
    {
        int _Total = 0;
        int _Idx = 0;
        string _Msg = string.Empty;
        string _Type = string.Empty;

        //public int Total { get; set; }
        //public int Idx { get; set; }
        //public string Msg { get; set; }

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

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

    //public class SrtInfo
    //{
    //    public string Start = string.Empty;
    //    public string End = string.Empty;
    //    public string Style = string.Empty;
    //    public List<string> ContentList = new List<string>();
    //}


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
