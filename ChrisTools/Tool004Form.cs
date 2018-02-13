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

namespace MegaRouting
{
  public partial class Tools001 : Form
  {
    public Tools001()
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

          showMsg("");
        }
        catch (Exception)
        {

          continue;
        }
        
        
      }


      return;


      //INode root = nodes.Single(n => n.Type == NodeType.Root);
      //INode myFolder = client.CreateFolder("Upload", root);

      //INode myFile = client.UploadFile("MyFile.ext", myFolder);

      //Uri downloadUrl = client.GetDownloadLink(myFile);
      //Console.WriteLine(downloadUrl);
      
    }


    private void showMsg(string pMsg)
    {
      richTextBox1.AppendText(pMsg + Environment.NewLine);
      richTextBox1.ScrollToCaret();
      richTextBox1.Refresh();

    }
  }
}
