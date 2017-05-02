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
using Microsoft.VisualBasic;

namespace Spider
{
  public partial class SpC020Form : Form
  {
    public SpC020Form()
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
      
      DataTable ListTable = new DataTable();
      ListTable.Columns.Add("no");
      ListTable.Columns.Add("name");
      ListTable.Columns.Add("namec");
      ListTable.Columns.Add("group");

      //取得連結清單
      List<string> imgList = new List<string>();
      string sGp = "";
      foreach (HtmlNode link in docStockContext.DocumentNode.SelectNodes("./tr"))
      {
        //第幾代
        if (link.ChildNodes.Count == 2)
        {
          HtmlNode GpNode = link.SelectNodes(@"./td")[0];
          sGp = GpNode.InnerText.Replace("\n", ""); ;
        }
        //內容
        if (link.ChildNodes.Count == 8)
        {
          HtmlNode NumNode = link.SelectNodes(@"./td")[0];
          HtmlNode NameCNode = link.SelectNodes(@"./td")[1];
          HtmlNode NameNode = link.SelectNodes(@"./td")[3].SelectSingleNode(@"./a");
          
          DataRow NewRow = ListTable.NewRow();
          NewRow["no"] = NumNode.InnerText.Replace("\n", "").Replace("#", "");
          NewRow["name"] = NameNode.InnerText.Replace("\n", "");
          NewRow["namec"] = ConvTraditionalChinese(NameCNode.InnerText.Replace("\n", ""));
          NewRow["group"] = sGp;

          ListTable.Rows.Add(NewRow);
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

        //string sImgFileName = FormatFileName(TempSplit[TempSplit.Length - 1]);

        //ShowMsg(sImgFileName);

        //依照圖片路徑下載
        //DoSaveImage(sImgUrl, sImgFileName);
      }
    }

    private void ShowMsg(string sMsg)
    {
      richTextBox1.AppendText(sMsg + Environment.NewLine);
      richTextBox1.ScrollToCaret();
      richTextBox1.Refresh();
    }

    /// <summary>
    /// 簡體轉繁體
    /// </summary>
    /// <param name="sSource"></param>
    /// <returns></returns>
    private string ConvTraditionalChinese(string sSource)
    {
      string sResult = sSource;
      
      sResult = Microsoft.VisualBasic.Strings.StrConv(sSource, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 2052);

      return sResult;
    }
  }
}
