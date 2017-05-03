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
  public partial class SpC030Form : Form
  {
    static string[] Scopes = { SheetsService.Scope.Spreadsheets, SheetsService.Scope.Drive };
    //應用程式的名字需要英文
    static string ApplicationName = "Get Google SheetData with Google Sheets API";
    static String spreadsheetId = "1bMZnuVDOL8mNKw6wivVp-yg_4nupLLE5ACEGG2OtgE8";
    static string sheetName = "Test123";
    static string UserCredentFilePath = @"c:\\client_id.json";


    public SpC030Form()
    {
      InitializeComponent();
    }


    private void SpC030Form_Load(object sender, EventArgs e)
    {
       
    }

    
    private void ShowMsg(string sMsg)
    {
      richTextBox1.AppendText(sMsg + Environment.NewLine);
      richTextBox1.ScrollToCaret();
      richTextBox1.Refresh();
    }

    private void WriteButton_Click(object sender, EventArgs e)
    {
      try
      {
        var service = OpenSheet();

        int iIndex = 1;

        //每10秒一次寫入時間到 Google Sheet
        while (true)
        {
          ShowMsg("寫入:" + iIndex.ToString());
          UpdateRow(service);
          System.Threading.Thread.Sleep(10000);
          iIndex++;
        }
      }
      catch (Exception ex)
      {
        ShowMsg(ex.ToString());
      }
    }

    private SheetsService OpenSheet()
    {
      UserCredential credential;
      using (var stream = new FileStream(UserCredentFilePath, FileMode.Open, FileAccess.Read))
      {
        string credPath = Path.Combine
            (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
             ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

        //存儲憑證到credPath
        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;
        Console.WriteLine("Credential file saved to: " + credPath);
      }

      //建立一個API服務，設定請求參數
      var service = new SheetsService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = ApplicationName,
      });
      return service;
    }

    private void UpdateRow(SheetsService service)
    {
      
        ValueRange rVR;
        String sRange;
        int rowNumber = 1;

        //設定讀取A欄最後一行位置
        sRange = String.Format("{0}!A:A", sheetName);
        SpreadsheetsResource.ValuesResource.GetRequest getRequest
            = service.Spreadsheets.Values.Get(spreadsheetId, sRange);
        rVR = getRequest.Execute(); //到Google sheet讀取內容
        IList<IList<Object>> values = rVR.Values; //最後一行位置

        //寫入新資料
        if (values != null && values.Count > 0) rowNumber = values.Count + 1; //添加一行
        sRange = String.Format("{0}!A{1}:B{1}", sheetName, rowNumber);  //指定寫入位置

        //設定寫入
        ValueRange valueRange = new ValueRange();
        valueRange.Range = sRange;
        valueRange.MajorDimension = "ROWS";//ROWS或COLUMNS

        //取得當前時間
        DateTime dt = new DateTime();
        dt = DateTime.Now;
        List<object> oblist = new List<object>() { String.Format("{0}", rowNumber), dt.ToString("HH:mm:ss") };
        //寫入時間
        valueRange.Values = new List<IList<object>> { oblist };
        Console.WriteLine("{0}, {1}", oblist[0], oblist[1]);

        //執行寫入動作
        SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest
            = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, sRange);
        updateRequest.ValueInputOption
            = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        UpdateValuesResponse uUVR = updateRequest.Execute();
      
    }

    private void ReadButton_Click(object sender, EventArgs e)
    {
      try
      {
        var service = OpenSheet();

        // Define request parameters.
        //String spreadsheetId = "1SyfODMfB1t7kpZ-CscOUIXdl6wHoHwYsxIjsbzMfzSk";
        //String spreadsheetId = "1bMZnuVDOL8mNKw6wivVp-yg_4nupLLE5ACEGG2OtgE8";
        String range = "工作表1!A1:C4";
        SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);
        
        
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
            }
          }
        }
        else
        {
          //Console.WriteLine("No data found.");
        }
        
      }
      catch (Exception ex)
      {
        ShowMsg(ex.ToString());
        
      }
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      try
      {
        var service = OpenSheet();

        string sheetName = string.Format("{0} {1}", DateTime.Now.Month, DateTime.Now.Day);
        var addSheetRequest = new AddSheetRequest();
        addSheetRequest.Properties = new SheetProperties();
        addSheetRequest.Properties.Title = sheetName;
        BatchUpdateSpreadsheetRequest batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
        batchUpdateSpreadsheetRequest.Requests = new List<Request>();
        batchUpdateSpreadsheetRequest.Requests.Add(new Request
        {
          AddSheet = addSheetRequest
        });

        var batchUpdateRequest =
            service.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, spreadsheetId);

        batchUpdateRequest.Execute();

        ShowMsg("新增完成");
      }
      catch (Exception ex)
      {
        ShowMsg(ex.ToString());
        
      }
    }
  }
}
