using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CL.Data;





namespace BlackHoleSupport
{
    public partial class BHSup : Form
    {
        string ssql = string.Empty;
        
        ODAL oDal = new ODAL(Properties.Settings.Default.DBConnectionString);


        public BHSup()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            return;

            try
            {
                Application.DoEvents();
                Uri lll = new Uri("http://megafunpro.com/plugin.php?id=thanksplugin:thanks&action=thanks&tid=" + lblNoR.Text);
                webBrowser1.Url = lll;
                Application.DoEvents();

                //ssql = " select value from LRTIAlertMail "
                //    + " where 1=1 "
                //    + " and type='BHSR' ";
                //oDal.CommandText = ssql;

                //String sNo = "";
                //object osql = oDal.Value();

                //if (osql != null)
                //{
                //    sNo = osql.ToString();

                //    lblNoR.Text = sNo;
                //    Application.DoEvents();

                   
                //}                
            }
            catch (Exception ex)
            {

            }    
        }

        private void BHSup_Load(object sender, EventArgs e)
        {
            try
            {
                ssql = " select value from LRTIAlertMail "
                     + " where 1=1 "
                     + " and type='BHSS' ";
                oDal.CommandText = ssql;

                lblNoS.Text = oDal.Value().ToString();

                ssql = " select value from LRTIAlertMail "
                     + " where 1=1 "
                     + " and type='BHSE' ";
                oDal.CommandText = ssql;

                lblNoE.Text = oDal.Value().ToString();

                ssql = " select value from LRTIAlertMail "
                     + " where 1=1 "
                     + " and type='BHSR' ";
                oDal.CommandText = ssql;

                lblNoR.Text = oDal.Value().ToString();
                
            }
            catch (Exception ex)
            {

            }    

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {   
            // 使用 WebBrowser.DocumentStream 取得網頁內容
            // 使用 StreamReader 讀入資料流，設定編碼為 Encoding.Default
            //System.IO.StreamReader getReader = new System.IO.StreamReader(this.webBrowser1.DocumentStream, System.Text.Encoding.Default);
            System.IO.StreamReader getReader = new System.IO.StreamReader(this.webBrowser1.DocumentStream, System.Text.Encoding.UTF8);

            string gethtml = getReader.ReadToEnd();
            txthtml.Text = gethtml;

            Application.DoEvents();
            btnTest_Click(sender, e);
            Application.DoEvents();
        }

        static async System.Threading.Tasks.Task Delay(int iSecond)
        {
            //WriteLine("Waiting Start.");
            await System.Threading.Tasks.Task.Delay(iSecond);
            //WriteLine("Waiting End.");
        }

        static async System.Threading.Tasks.Task<int> GetRemoteData(int iSecond)
        {
            int res = 0;
            //await System.Threading.Tasks.Task.Run(() =>
            //{
            //    System.Threading.Tasks.Task.Delay(iSecond);
            //    res = 32767;
            //}).ConfigureAwait(false); //加設ConfigureAwait
            //await System.Threading.Tasks.Task.Run(() =>
            //{
            //    System.Threading.Tasks.Task.Delay(iSecond);
            //    res = 32767;
            //}); //加設ConfigureAwait


            await System.Threading.Tasks.Task.Delay(iSecond);
            return res;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            HtmlElement buttonSubmit = this.webBrowser1.Document.GetElementById("thanksubmit");
            //HtmlElement buttonSubmit = this.webBrowser1.Document.GetElementById("btnExport");

            //System.Threading.Thread.Sleep(2000);

            //await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(30));
            
            //System.Threading.Tasks.Task.Delay(2000).Wait();

            //await System.Threading.Tasks.Task.Delay(2000);

            

            //System.Threading.Tasks.Task simpleTask = Delay(2000);

            //System.Threading.Tasks.Task simpleTask = GetRemoteData(2000);
            //var res = await GetRemoteData(2000);

            //var res =  await GetRemoteData(2000);
           
            
            if (buttonSubmit != null)
            {
                buttonSubmit.InvokeMember("click");

                

                int iNoR = Convert.ToInt32(lblNoR.Text);
                iNoR++;
                Application.DoEvents();
                lblNoR.Text = iNoR.ToString();
                Application.DoEvents();
                //點擊後記錄於資料庫
                ssql = " update LRTIAlertMail "
                     + " set value = '" + iNoR.ToString() +"' "
                     + " where 1=1 "
                     + " and type='BHSR' ";
                oDal.CommandText = ssql;
                oDal.ExecuteSql();

                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                btnStart_Click(sender, e);
            }
        }

        
    }
}
