using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CG.Web.MegaApiClient;

namespace ChrisTools
{
  public partial class Tool004Form : BaseForm
  {
    public Tool004Form()
    {
      InitializeComponent();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < 40; i++)
      {
        try
        {
          MegaApiClient client = new MegaApiClient();

          int idx = i + 1;
          string sEmail = string.Format("chris.lin.tw1234+{0}@gmail.com", idx.ToString().PadLeft(3, '0'));
          
          showMsg(string.Format("{0}==登入中", sEmail));
          client.Login(sEmail, "fm719531");          
          showMsg(string.Format("{0}==登入成功", sEmail));
                    
          showMsg(string.Format("{0}==讀取中", sEmail));
          var nodes = client.GetNodes();
          showMsg(string.Format("{0}==讀取成功", sEmail));
          
          showMsg(string.Format("{0}==登出中", sEmail));
          client.Logout();          
          showMsg(string.Format("{0}==登出成功", sEmail));
        }
        catch (Exception ex)
        {
          showMsg(ex.ToString());
          continue;
        }
      }

      BaseShowStatus("批次登入完成");
    }


    private void showMsg(string pMsg)
    {
      richTextBox1.AppendText(string.Format("{0}={1}{2}", DateTime.Now.ToString("s"), pMsg, Environment.NewLine));      
      richTextBox1.Refresh();
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
      RichTextBox rtb = sender as RichTextBox;

      if (rtb.Lines.Length > 16)
      {
        rtb.Text = rtb.Text.Remove(0, rtb.Lines[0].Length + 1);
      }

      rtb.ScrollToCaret();
    }
  }
}
