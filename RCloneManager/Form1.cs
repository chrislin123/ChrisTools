using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCloneManager
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {



      //string sGetInfoCommand = string.Format(@"{0} -i ""{1}"" ", sMkvtoolnixPath, sFilePath);
      string sGetInfoCommand = "";
      sGetInfoCommand = @"C:\rclone-v1.42-windows-amd64\rclone.exe sync -vv --transfers 1 --checkers 1 --stats 1s --drive-chunk-size=256M  --tpslimit 1 --fast-list  area:/ActArea/001動畫 od5c00:/ActArea/001動畫";
      List<string> TempList = ExecuteCommandSync(sGetInfoCommand);


    }

    public List<string> ExecuteCommandSync(object command)
    {
      return ExecuteCommandSync(command, null);
    }

    public List<string> ExecuteCommandSync(object command, BackgroundWorker bw)
    {
      List<string> ResultList = new List<string>();
      //ReportInfo ri = new ReportInfo();

      try
      {
        // create the ProcessStartInfo using "cmd" as the program to be run,
        // and "/c " as the parameters.
        // Incidentally, /c tells cmd that we want it to execute the command that follows,
        // and then exit.
        //System.Diagnostics.ProcessStartInfo procStartInfo =
        //    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
        //System.Diagnostics.ProcessStartInfo procStartInfo =
        //  new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
        System.Diagnostics.ProcessStartInfo procStartInfo =
          new System.Diagnostics.ProcessStartInfo(@"C:\rclone-v1.42-windows-amd64\rclone.exe", @" sync -vv --transfers 1 --checkers 1 --stats 1s --drive-chunk-size=256M  --tpslimit 1 --fast-list  area:/ActArea/001動畫 od5c00:/ActArea/001動畫");

        // The following commands are needed to redirect the standard output.
        // This means that it will be redirected to the Process.StandardOutput StreamReader.
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.RedirectStandardInput = true;
        procStartInfo.UseShellExecute = false;
        // Do not create the black window.
        //procStartInfo.CreateNoWindow = true;
        procStartInfo.CreateNoWindow = false;
        //解決中文顯示問題
        procStartInfo.StandardOutputEncoding = Encoding.UTF8;
        // Now we create a process, assign its ProcessStartInfo and start it
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        //解決中文顯示問題
        proc.StartInfo.StandardOutputEncoding = Encoding.UTF8;
        proc.StartInfo = procStartInfo;

        //proc.StandardInput.AutoFlush = true;
        proc.Start();


        System.Diagnostics.Process ppp = new System.Diagnostics.Process();
           
        //string line1 = proc.StandardOutput.ReadLine();


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
              //ri.Type = "sub";
              //ri.Total = 100;
              //ri.Idx = Convert.ToInt16(line);
              //ri.Msg = "";
              //bw.ReportProgress(1, ri);
            }
          }
        }
        //str = p.StandardOutput.ReadToEnd();


        // Get the output into a string
        //string result = proc.StandardOutput.ReadToEnd();


        proc.WaitForExit();
        proc.Close();
        // Display the command output.
        //Console.WriteLine(result);
      }
      catch (Exception objException)
      {
        // Log the exception
      }

      return ResultList;
    }

  }
}
