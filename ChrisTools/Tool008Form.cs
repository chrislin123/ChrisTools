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
    public partial class Tool008Form : BaseForm
    {
        string sTargetRemote = "";
        string sSourceRemote = "";
        string sTargetFolder = "";
        string sSourceFolder = "";

        public Tool008Form()
        {
            InitializeComponent();
            base.InitForm();
        }

        private void Tool008Form_Load(object sender, EventArgs e)
        {
            //GClone程式路徑
            txtFFMpegPath.Text = Comm.GetSetting(CTsConst.SettingList.Tool008_PathGClone);
            //GClone指令樣板
            richTextBox1.Text = Comm.GetSetting(CTsConst.SettingList.Tool008_GCloneCommString);
        }


        /// <summary>
        /// 計算所有設定轉換成執行的指令碼
        /// </summary>
        private void CalAllSettingToCommString() 
        {
            //取得來源主機
            string sSourceRemote = "";
            var SourceCheckButton = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (SourceCheckButton != null)
            {
                sSourceRemote = SourceCheckButton.Text;
            }

            //取得目標主機
            string sTargetRemote = "";
            var TargetCheckButton = panel2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (TargetCheckButton != null)
            {
                sTargetRemote = TargetCheckButton.Text;
            }

            //取得來源資料夾
            //取得目標資料夾

            //依照樣本轉換成要執行的指令碼
            richTextBox2.Text = string.Format(richTextBox1.Text
                , sSourceRemote
                , SourceFoldIDText
                , sTargetRemote
                , TargetFoldIDText
                );
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            txtFFMpegPath.Text = path.SelectedPath;

            //防呆，判斷程式是否存在

        }

        

        private void ShowStatus(string msg)
        {

            lblStatus.Text = msg;
            Application.DoEvents();

        }
        //private void ShowRichTextStatus(string pMsg)
        //{
        //    if (pMsg.Contains("Progress:") == true)
        //    {
        //        progressBar1.Value = Convert.ToInt32(pMsg.Replace("Progress:", "").Replace("%", "").Trim());
        //        if (pMsg == "Progress: 100%")
        //        {
        //            richTextBox1.AppendText("\r\n" + pMsg + " 完成。");
        //        }
        //    }
        //    else
        //    {
        //        //取消不顯示細部內容
        //        //richTextBox1.AppendText("\r\n" + pMsg);
        //    }

        //    this.Update();
        //    Application.DoEvents();
        //}

        private void ShowRichTextStatus1(string pMsg)
        {
            //取消不顯示細部內容
            richTextBox1.AppendText("\r\n" + pMsg);

            //this.Update();
            //Application.DoEvents();
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
                procStartInfo.CreateNoWindow = false;
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

        private void txtMkvToolPath_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void All_TextChanged(object sender, EventArgs e)
        {   
            string sSourceFoldID = SourceFoldIDText.Text;
            string sTargetFoldID = TargetFoldIDText.Text;
            string sRadSource = "";
            string sRadTarget = "";

            //網址轉換資料夾ID           
            string[] aSourceFoldID = sSourceFoldID.Split('/');
            string[] aTargetFoldID = sTargetFoldID.Split('/');            
            sSourceFoldID = aSourceFoldID[aSourceFoldID.Length - 1];
            sTargetFoldID = aTargetFoldID[aTargetFoldID.Length - 1];

            SourceFoldIDText.Text = sSourceFoldID;
            TargetFoldIDText.Text = sTargetFoldID;

            if (radSource1.Checked == true) sRadSource = radSource1.Text;
            if (radSource2.Checked == true) sRadSource = radSource2.Text;
            if (radSource3.Checked == true) sRadSource = radSource3.Text;

            if (radTarget1.Checked == true) sRadTarget = radTarget1.Text;
            if (radTarget2.Checked == true) sRadTarget = radTarget2.Text;
            if (radTarget3.Checked == true) sRadTarget = radTarget3.Text;


            richTextBox2.Text = string.Format(@richTextBox1.Text
                , sRadSource
                , sSourceFoldID
                , sRadTarget
                , sTargetFoldID
                );
        }

        private void txtMkvToolPath_MouseClick(object sender, MouseEventArgs e)
        {
            txtFFMpegPath.SelectAll();
        }

        //private void txtTransPath_MouseClick(object sender, MouseEventArgs e)
        //{
        //    txtTransPath.SelectAll();
        //}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;

            if (rtb.Lines.Length > 500)
            {
                rtb.Text = rtb.Text.Remove(0, rtb.Lines[0].Length + 1);
            }

            rtb.ScrollToCaret();
        }

        private void Tool008Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Comm.SetSetting(CTsConst.SettingList.Tool008_PathGClone, txtFFMpegPath.Text);
            Comm.SetSetting(CTsConst.SettingList.Tool008_GCloneCommString, richTextBox1.Text);
        }

        private void ProcMergeMkvSrt(FileInfo fiMKV, string sAudioType, BackgroundWorker bw)
        {   
            string sMkvtoolnixPath = Path.Combine(txtFFMpegPath.Text, "ffmpeg.exe");

            string sOutputmark = "";
            if (sAudioType == "dts")
            {
                sOutputmark = "(dts)";
                sAudioType = "dts -strict -2";
            } 
            if (sAudioType == "ac3") sOutputmark = "(ac3)";
            if (sAudioType == "aac") sOutputmark = "(aac)";

            FileInfo fiOutput = new FileInfo(Path.Combine(
               fiMKV.DirectoryName, fiMKV.Name.Replace(fiMKV.Extension, "") + sOutputmark + ".mkv"));

            //取得資訊
            //string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" ", sMkvtoolnixPath, fiMKV.FullName);
            //List<string> TempList = ExecuteCommandSync(sGetInfoCommand);


            //ffmpeg -i "[歐美](2018)[英語][官譯].mkv" -map 0 -c:v copy -c:a dts -strict -2 -c:s copy "output.mkv"
            string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" -map 0 -c:v copy -c:a {2} -c:s copy ""{3}""", sMkvtoolnixPath, fiMKV.FullName, sAudioType, fiOutput.FullName);
          
            ExecuteCommandSync(sGetInfoCommand, bw);

        }

        private void ClearForm()
        {
            //progressBar1.Value = 0;
            //progressBar2.Value = 0;

            //richTextBox1.Text = "";
            //lblStatus.Text = "狀態";
            //lbltotal.Text = "數量";

        }

        private void Proc_DoWorkFFMpegAudioTrans(object sender, DoWorkEventArgs e)
        {
            ReportInfo ri = new ReportInfo();
            BackgroundWorker bw = sender as BackgroundWorker;

            dynamic p = e.Argument as dynamic;
            string sPath = p.path;
            Boolean bchkDTS = p.chkDTS;
            Boolean bchkAC3 = p.chkAC3;
            Boolean bchkAAC = p.chkAAC;

            DirectoryInfo di = new DirectoryInfo(sPath);

            string sAudioType = "";
            if (bchkDTS == true) sAudioType = "dts";
            if (bchkAC3 == true) sAudioType = "ac3";
            if (bchkAAC == true) sAudioType = "aac";

            //取得所有影像資料
            FileInfo[] VideoList = di.GetFiles("*.mkv", SearchOption.AllDirectories);

            int idx = 0;
            foreach (FileInfo VideoItem in VideoList)
            {
                idx++;
                ri.Total = VideoList.Length;
                ri.Idx = idx;
                ri.Msg = "";

                ri.Msg = VideoItem.Name;
                bw.ReportProgress(1, ri);
                //執行合併檔案
                ProcMergeMkvSrt(VideoItem, sAudioType, bw);
            }

            ri.Msg = "";
            bw.ReportProgress(1, ri);
        }

        private void Proc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void Proc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowRichTextStatus1(string.Format("[完成]{0}", ""));
        }

        private void btnFFMpegAudio_Click(object sender, EventArgs e)
        {
            ClearForm();

            BackgroundWorker bw = new BackgroundWorker();
            //回報進程
            bw.WorkerReportsProgress = true;
            //加入DoWork
            bw.DoWork += new DoWorkEventHandler(Proc_DoWorkFFMpegAudioTrans);
            //加入ProgressChanged
            bw.ProgressChanged += new ProgressChangedEventHandler(Proc_ProgressChanged);
            //加入RunWorkerCompleted
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Proc_RunWorkerCompleted);

            //傳遞參數
            var p = new
            {
                //path = txtTransPath.Text,
                //chkAC3 = radAC3.Checked,
                //chkDTS = radDTS.Checked,
                //chkAAC = radAAC.Checked
            };

            //執行程序
            bw.RunWorkerAsync(p);
        }

        private void SourceFoldIDText_MouseClick(object sender, MouseEventArgs e)
        {
            SourceFoldIDText.SelectAll();
        }

        private void TargetFoldIDText_MouseClick(object sender, MouseEventArgs e)
        {
            TargetFoldIDText.SelectAll();
        }
    }


    
}
