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
using System.Text.RegularExpressions;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Spider
{
  public partial class SpC020Form : Form
  {
    static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    //應用程式的名字需要英文
    static string ApplicationName = "Get Google SheetData with Google Sheets API";
    static string sheetName = "Test123";



    public SpC020Form()
    {
      InitializeComponent();
    }


    private void SpC020Form_Load(object sender, EventArgs e)
    {
      try
      {
        UserCredential credential;

        using (var stream =
            new FileStream(@"c:\\client_id.json", FileMode.Open, FileAccess.Read))
        {
          string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
          credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
          credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
              GoogleClientSecrets.Load(stream).Secrets,
              Scopes,
              //"chris.lin.tw123@gmail.com",
              "user",
              CancellationToken.None,
              new FileDataStore(credPath, true)).Result;
          ShowMsg("Credential file saved to: " + credPath);
          //Console.WriteLine("Credential file saved to: " + credPath);
        }

        // Create Google Sheets API service.
        var service = new SheetsService(new BaseClientService.Initializer()
        {
          HttpClientInitializer = credential,
          ApplicationName = ApplicationName,
        });

        // Define request parameters.
        //String spreadsheetId = "1SyfODMfB1t7kpZ-CscOUIXdl6wHoHwYsxIjsbzMfzSk";
        String spreadsheetId = "1bMZnuVDOL8mNKw6wivVp-yg_4nupLLE5ACEGG2OtgE8";
        String range = "工作表1!A1:C4";
        SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);

        Spreadsheet ss = new Spreadsheet();
        
        //ss.Properties.Title = "我的建立測試";
        SpreadsheetsResource.CreateRequest cRequest = service.Spreadsheets.Create(ss);
        Spreadsheet RespSS = cRequest.Execute();
       
        

        //service.Spreadsheets.Create()


        // Prints the names and majors of students in a sample spreadsheet:
        // https://docs.google.com/spreadsheets/d/1SyfODMfB1t7kpZ-CscOUIXdl6wHoHwYsxIjsbzMfzSk/edit
        ValueRange response = request.Execute();
        IList<IList<Object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
          foreach (var row in values)
          {
            foreach (var col in row)
            {
              ShowMsg(string.Format("{0} ", col));
              //Console.Write("{0} ", col);
            }
            //Console.WriteLine();
            //或是以下寫法
            //Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
          }
        }
        else
        {
          //Console.WriteLine("No data found.");
        }
        //Console.Read();
      }
      catch (Exception ex)
      {
        ShowMsg(ex.ToString());
        //throw;
      }
      
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
          sGp = GpNode.InnerText.Replace("\n", "").Replace("第", "").Replace("世代", "");
        }
        //內容
        if (link.ChildNodes.Count == 8)
        {
          HtmlNode NumNode = link.SelectNodes(@"./td")[0];
          HtmlNode NameCNode = link.SelectNodes(@"./td")[1];
          HtmlNode NameNode = link.SelectNodes(@"./td")[3].SelectSingleNode(@"./a");
          
          DataRow NewRow = ListTable.NewRow();
          NewRow["no"] = NumNode.InnerText.Replace("\n", "").Replace("#", "").Trim();
          NewRow["name"] = NameNode.InnerText.Replace("\n", "").Trim();
          NewRow["namec"] = ConvTraditionalChinese(NameCNode.InnerText.Replace("\n", "").Trim());
          NewRow["group"] = TcNumToNum(sGp.Trim());

          ListTable.Rows.Add(NewRow);
        }
      }

      //todo 寫入Sheet




      ShowMsg("完成");

    }

    private string TcNumToNum(string sSource)
    {
      string sResult = "";

      if (sSource == "一")
        sResult = "1";
      if (sSource == "二")
        sResult = "2";
      if (sSource == "三")
        sResult = "3";
      if (sSource == "四")
        sResult = "4";
      if (sSource == "五")
        sResult = "5";
      if (sSource == "六")
        sResult = "6";
      if (sSource == "七")
        sResult = "7";
      if (sSource == "八")
        sResult = "8";
      if (sSource == "九")
        sResult = "9";

      return sResult;
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

      //sResult = Microsoft.VisualBasic.Strings.StrConv(sSource, Microsoft.VisualBasic.VbStrConv.Narrow, 1028);

      //var ncrString = toNCR(sSource);

      //var convString = Microsoft.VisualBasic.Strings.StrConv(
      //  sSource, Microsoft.VisualBasic.VbStrConv.Narrow, 2052);

      //sResult = fromNCR(convString);

      return sResult;
    }

    
    //private string ConvTraditionalChinese(string sSource)
    //{
    //  string sResult = sSource;


    //  var ncrString = toNCR(sSource);

    //  var convString = Microsoft.VisualBasic.Strings.StrConv(
    //    ncrString, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 2052);

    //  sResult = fromNCR(convString);

    //  return sResult;
    //}

    /// <summary>
    /// 繁體轉簡體
    /// </summary>
    /// <param name="sSource"></param>
    /// <returns></returns>
    //private string ConvSimplifiedChinese(string sSource)
    //{
    //  string sResult = sSource;


    //  var ncrString = toNCR(sSource);

    //  var convString = Microsoft.VisualBasic.Strings.StrConv(
    //    ncrString, Microsoft.VisualBasic.VbStrConv.Narrow, 1028);

    //  sResult = fromNCR(convString);

    //  return sResult;
    //}


    ////REF: http://blog.darkthread.net/blogs/darkthreadtw/archive/2007/04/21/733.aspx
    //static string toNCR(string input)
    //{
    //  StringBuilder sb = new StringBuilder();
    //  Encoding big5 = Encoding.GetEncoding("big5");
    //  foreach (char c in input)
    //  {
    //    //強迫轉碼成Big5，看會不會變成問號
    //    string cInBig5 = big5.GetString(big5.GetBytes(new char[] { c }));
    //    //原來不是問號，轉碼後變問號，判定為難字
    //    if (c != '?' && cInBig5 == "?")
    //      sb.AppendFormat("&#{0};", Convert.ToInt32(c));
    //    else
    //      sb.Append(c);
    //  }
    //  return sb.ToString();
    //}

    //static string fromNCR(string input)
    //{
    //  return Regex.Replace(input, "&#(?<ncr>\\d+?);", (m) =>
    //  {
    //    return Convert.ToChar(int.Parse(m.Groups["ncr"].Value)).ToString();
    //  });
    //}

    private void button1_Click(object sender, EventArgs e)
    {
      string ssss = "黑暗执行緒犇ＡＢＣ１２３";
      
      ssss = ConvTraditionalChinese(ssss);

    }

  }
}
