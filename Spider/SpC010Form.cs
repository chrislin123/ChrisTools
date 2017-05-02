using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

namespace Spider
{
  public partial class SpC010Form : Form
  {
    public SpC010Form()
    {
      InitializeComponent();
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
      ProcStart();
    }

    public void ProcStart()
    {
      string surl = "https://wiki.52poke.com/wiki/%E5%AE%9D%E5%8F%AF%E6%A2%A6%E5%88%97%E8%A1%A8%EF%BC%88%E6%8C%89%E5%85%A8%E5%9B%BD%E5%9B%BE%E9%89%B4%E7%BC%96%E5%8F%B7%EF%BC%89/%E7%AE%80%E5%8D%95%E7%89%88";
      
      HtmlWeb webClient = new HtmlWeb();
      HtmlAgilityPack.HtmlWeb.PreRequestHandler handler = delegate (HttpWebRequest request)
      {
        request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
        request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        request.CookieContainer = new System.Net.CookieContainer();
        return true;
      };

      webClient.PreRequest += handler;

      ShowMsg("載入資料");      

      // 載入網頁資料 
      HtmlAgilityPack.HtmlDocument doc = webClient.Load(surl);
     
      // 裝載查詢結果 
      HtmlAgilityPack.HtmlDocument docStockContext = new HtmlAgilityPack.HtmlDocument();      
      docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
        @"//*[@id='mw-content-text']/table[1]").InnerHtml);

      ShowMsg("彙整連結");      

      //取得連結清單
      List<string> imgList = new List<string>();
      //foreach (HtmlNode link in docStockContext.DocumentNode.SelectNodes("//a[@href]"))
      foreach (HtmlNode link in docStockContext.DocumentNode.SelectNodes("./tr"))
      {
        if (link.ChildNodes.Count == 8)
        {
          HtmlNode imaHref = link.SelectNodes(@"./td")[3].SelectSingleNode(@"./a");

          imgList.Add(imaHref.GetAttributeValue("href", ""));
        }
      }

      int iIndex = 0;
      foreach (string item in imgList)
      {
        iIndex++;

        //if (iIndex < 500)
        //{ 
        //  continue;
        //}

        string surl1 = "https://wiki.52poke.com" + item;
        string[] sSplit = item.Split('/');

        string sFileName = sSplit[sSplit.Length - 1];

        ShowMsg("取得明細資料");

        HtmlWeb webClient1 = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc1 = webClient.Load(surl1);

        HtmlNode imaHref;
        imaHref = doc1.DocumentNode.SelectSingleNode(
          string.Format(@"//img[contains(@alt,'{0}') and contains(@alt,'.png')]", sFileName));
                
        if (imaHref == null)
        {
          continue;
        }

        string sSrc = imaHref.GetAttributeValue("data-url", "");

        if (sSrc == "")
        {
          continue;
        }

        string sImgUrl = "http:" + sSrc;

        string[] TempSplit = sImgUrl.Split('/');

        string sImgFileName = FormatFileName(TempSplit[TempSplit.Length - 1]);

        ShowMsg(sImgFileName);

        //依照圖片路徑下載
        DoSaveImage(sImgUrl, sImgFileName);
      }
    }

    private void DoSaveImage(string sImgUrl,string sFileName)
    {
      System.Net.WebClient WC = new System.Net.WebClient();
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream(WC.DownloadData(sImgUrl)))
      {
        Image img = Image.FromStream(ms);
        img.Save(string.Format(@"{0}\{1}", FileSavePathText.Text, sFileName));
      }
    }

    private void FileSavePathButton_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog path = new FolderBrowserDialog();      
      path.ShowDialog();
      FileSavePathText.Text = path.SelectedPath;
    }


    private string FormatFileName(string sFileName)
    {
      string sResult = "";

      string[] TempSplit = sFileName.Split('-');
      if (TempSplit.Length == 2)
      {
        sResult = TempSplit[1];
      }
      else
      {
        sResult = sFileName;
      }
      
      return sResult;
    }

    private void ShowMsg(string sMsg)
    {
      richTextBox1.AppendText(sMsg + Environment.NewLine);
      richTextBox1.ScrollToCaret();
      richTextBox1.Refresh();
    }
  }
}
