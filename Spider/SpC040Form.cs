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
using Google.Apis.Drive.v3;
using Data = Google.Apis.Drive.v3.Data;


using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Spider
{
  public partial class SpC040Form : Form
  {
    static string[] Scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile, SheetsService.Scope.Spreadsheets, SheetsService.Scope.Drive };
    //應用程式的名字需要英文
    static string ApplicationName = "Get Google SheetData with Google Sheets API";
    static string UserCredentFilePath = @"c:\\client_id.json";

    public SpC040Form()
    {
      InitializeComponent();
    }


    private void SpC040Form_Load(object sender, EventArgs e)
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
        var service = OpenDrive();



        string sID = "0B8avjAsawlWoay1XV1MwOGxsQ2M";
        IList<Data.File> gFiles = getChildFolderByID(sID).Files;



        List<FileContent> gFileContents = new List<FileContent>();
        foreach (Data.File item in gFiles)
        {
          FileContent TempContent = new FileContent();


          TempContent.ParentFile = item;

          ShowMsg(string.Format("{0} ({1}) ({2}) ({3})", item.Name, item.Id, item.WebViewLink, item.WebContentLink));


          IList<Data.File> LoopFiles = getChildFolderByID(item.Id).Files;
          TempContent.ChildFiles = LoopFiles;

          foreach (Data.File LoopItem in LoopFiles)
          {
            ShowMsg(string.Format("== {0} ({1}) ({2}) ({3})", LoopItem.Name, LoopItem.Id, LoopItem.WebViewLink, LoopItem.WebContentLink));
          }

          gFileContents.Add(TempContent);

        }

        //ToDo 寫入Google SpreadSheet
        //WriteToSheet();



        return;

        FilesResource.ListRequest listRequest = service.Files.List();
        listRequest.PageSize = 10;
        listRequest.Fields = "nextPageToken, files(id, name, parents)";

        // List files.
        IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
            .Files;
        ShowMsg("Files:");
        //Console.WriteLine("Files:");
        if (files != null && files.Count > 0)
        {
          foreach (var file in files)
          {

            var absPath = AbsPath(file);
            ShowMsg(string.Format("{0} ({1})", absPath, file.Id));
            //Console.WriteLine("{0} ({1})", absPath, file.Id);
          }
        }
        else
        {
          //Console.WriteLine("No files found.");
        }
        //Console.Read();




        return;



        int iIndex = 1;

        //每10秒一次寫入時間到 Google Sheet
        while (true)
        {
          ShowMsg("寫入:" + iIndex.ToString());
          //UpdateRow(service);
          System.Threading.Thread.Sleep(10000);
          iIndex++;
        }
      }
      catch (Exception ex)
      {
        ShowMsg(ex.ToString());
      }
    }


    private Data.FileList getChildFolderByID(string ID) {

      Data.FileList gFiles = new Data.FileList();

      var service = OpenDrive();

      FilesResource.ListRequest Request = service.Files.List();

      //Ref.Url Search for Files
      //https://developers.google.com/drive/v3/web/search-parameters

      //加入搜尋條件
      //request.Q = "ABC";

      //取得資料夾(Another nice search is if you only want to return directories.)
      //Request.Q = "mimeType='application/vnd.google-apps.folder' and trashed=false and '0B4ZaSt-CrHaENDhXc2tjTk1PNGs' in parents";
      List<string> ParamList = new List<string>();
      ParamList.Add("mimeType='application/vnd.google-apps.folder'");
      ParamList.Add("trashed=false");
      ParamList.Add(string.Format("'{0}' in parents", ID));

      Request.Q = string.Join(" and ", ParamList);

      Request.OrderBy = "name";

      //Request.Fields = "parents";
      Request.Fields = "nextPageToken, files(id, name, parents, webViewLink, webContentLink)";


      gFiles = Request.Execute();


      return gFiles;
    }




    static Dictionary<string, Google.Apis.Drive.v3.Data.File> files = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();
    static DriveService GDservice;

    private static object AbsPath(Google.Apis.Drive.v3.Data.File file)
    {
      var name = file.Name;

      if (file.Parents.Count() == 0)
      {
        return name;
      }

      var path = new List<string>();

      while (true)
      {
        var parent = GetParent(file.Parents[0]);

        // Stop when we find the root dir
        if (parent.Parents == null || parent.Parents.Count() == 0)
        {
          break;
        }

        path.Insert(0, parent.Name);
        file = parent;
      }
      path.Add(name);
      return path.Aggregate((current, next) => Path.Combine(current, next));
    }

    private static Google.Apis.Drive.v3.Data.File GetParent(string id)
    {
      // Check cache
      if (files.ContainsKey(id))
      {
        return files[id];
      }

      // Fetch file from drive
      var request = GDservice.Files.Get(id);
      request.Fields = "name,parents";
      var parent = request.Execute();

      // Save in cache
      files[id] = parent;

      return parent;
    }

    private DriveService OpenDrive()
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
      var service = new DriveService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = ApplicationName,
      });

      return service;
    }

    //private void UpdateRow(SheetsService service)
    //{

    //    ValueRange rVR;
    //    String sRange;
    //    int rowNumber = 1;

    //    //設定讀取A欄最後一行位置
    //    sRange = String.Format("{0}!A:A", sheetName);
    //    SpreadsheetsResource.ValuesResource.GetRequest getRequest
    //        = service.Spreadsheets.Values.Get(spreadsheetId, sRange);
    //    rVR = getRequest.Execute(); //到Google sheet讀取內容
    //    IList<IList<Object>> values = rVR.Values; //最後一行位置

    //    //寫入新資料
    //    if (values != null && values.Count > 0) rowNumber = values.Count + 1; //添加一行
    //    sRange = String.Format("{0}!A{1}:B{1}", sheetName, rowNumber);  //指定寫入位置

    //    //設定寫入
    //    ValueRange valueRange = new ValueRange();
    //    valueRange.Range = sRange;
    //    valueRange.MajorDimension = "ROWS";//ROWS或COLUMNS

    //    //取得當前時間
    //    DateTime dt = new DateTime();
    //    dt = DateTime.Now;
    //    List<object> oblist = new List<object>() { String.Format("{0}", rowNumber), dt.ToString("HH:mm:ss") };
    //    //寫入時間
    //    valueRange.Values = new List<IList<object>> { oblist };
    //    Console.WriteLine("{0}, {1}", oblist[0], oblist[1]);

    //    //執行寫入動作
    //    SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest
    //        = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, sRange);
    //    updateRequest.ValueInputOption
    //        = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
    //    UpdateValuesResponse uUVR = updateRequest.Execute();

    //}

    private void ReadButton_Click(object sender, EventArgs e)
    {
      try
      {
        var service = OpenDrive();

        //// Define request parameters.
        ////String spreadsheetId = "1SyfODMfB1t7kpZ-CscOUIXdl6wHoHwYsxIjsbzMfzSk";
        ////String spreadsheetId = "1bMZnuVDOL8mNKw6wivVp-yg_4nupLLE5ACEGG2OtgE8";
        //String range = "工作表1!A1:C4";
        //SpreadsheetsResource.ValuesResource.GetRequest request =
        //        service.Spreadsheets.Values.Get(spreadsheetId, range);


        //// Prints the names and majors of students in a sample spreadsheet:
        //// https://docs.google.com/spreadsheets/d/1SyfODMfB1t7kpZ-CscOUIXdl6wHoHwYsxIjsbzMfzSk/edit
        //ValueRange response = request.Execute();
        //IList<IList<Object>> values = response.Values;
        //if (values != null && values.Count > 0)
        //{
        //  foreach (var row in values)
        //  {
        //    foreach (var col in row)
        //    {
        //      ShowMsg(string.Format("{0} ", col));        
        //    }
        //  }
        //}
        //else
        //{
        //  //Console.WriteLine("No data found.");
        //}

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
        var service = OpenDrive();

        //string sheetName = string.Format("{0} {1}", DateTime.Now.Month, DateTime.Now.Day);
        //var addSheetRequest = new AddSheetRequest();
        //addSheetRequest.Properties = new SheetProperties();
        //addSheetRequest.Properties.Title = sheetName;
        //BatchUpdateSpreadsheetRequest batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
        //batchUpdateSpreadsheetRequest.Requests = new List<Request>();
        //batchUpdateSpreadsheetRequest.Requests.Add(new Request
        //{
        //  AddSheet = addSheetRequest
        //});

        //var batchUpdateRequest =
        //    service.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, spreadsheetId);

        //batchUpdateRequest.Execute();

        //ShowMsg("新增完成");
      }
      catch (Exception ex)
      {
        ShowMsg(ex.ToString());

      }
    }
  }


  public class FileContent{
    public string ID = "";
    public string Name = "";
    public string WebViewLink = "";
    public string parent = "";
    public string WebContentLink = "";


    public Data.File ParentFile;

    public IList<Data.File> ChildFiles;
  }
}
