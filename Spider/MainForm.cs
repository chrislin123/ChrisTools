using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      SpC010Form newSpC010Form = new SpC010Form();
      newSpC010Form.ShowDialog(this);
      
    }

    private void button2_Click(object sender, EventArgs e)
    {
      SpC020Form newSpC020Form = new SpC020Form();
      newSpC020Form.ShowDialog(this);

    }

    private void button3_Click(object sender, EventArgs e)
    {
      SpC030Form newSpC030Form = new SpC030Form();
      newSpC030Form.ShowDialog(this);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      SpC040Form newSpC040Form = new SpC040Form();
      newSpC040Form.ShowDialog(this);
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      //这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。              
      Environment.Exit(Environment.ExitCode);
    }

    private void button5_Click(object sender, EventArgs e)
    {
      DataTable dtresult = new DataTable();
      dtresult.Columns.Add("country");
      dtresult.Columns.Add("week");
      dtresult.Columns.Add("car");
      dtresult.Columns.Add("time");

      string sFilepath = @"c:\test.csv";

      //DataTable dt = CSVtoDataTable(sFilepath);



      List<string> ll = new List<string>();
      
      using (StreamReader SR = new StreamReader(sFilepath))
      {
        string Line;
        while ((Line = SR.ReadLine()) != null)
        {
          if (Line == "") continue;
          if (Line == "\"             車次") continue;
          if (Line == ",,,,,,,,,,,,") continue;
          if (Line == "北上(Northbound),,,,,,,,,,,,") continue;
          if (Line == "台   灣   高   鐵   列   車   時   刻   表,,,,,,,,,,,,") continue;
          if (Line == ",=,=,=,=,=,=,=,=,=,=,,") continue;
          if (Line == "註 : 本時刻表所列各次列車，於起站與中間站均為開車時刻，於終點站為到達時刻。,,,,,,,,,,,,") continue;
          string[] ReadLine_Array = Line.Split(',');
          if (ReadLine_Array[0] == "" && ReadLine_Array[1] == "" && ReadLine_Array[2] == "" )
          {
            continue;
          }
          if (ReadLine_Array[0] == "站名\"")
          {
            continue;
          }
          if (Line == ",=,,,,,,,,,,,") continue;
          if (Line == ",,=,,,,,,,,,,") continue;



          ll.Add(Line);
          //MessageBox.Show(Line);

          //string[] ReadLine_Array = Line.Split(',');
          //這邊可以自行發揮
        }
      }


      DataTable dt = new DataTable();

      for (int i = 0; i < ll.Count; i++)
      {
        string[] ReadLine_Array = ll[i].Split(',');

        if (i==0)
        {
          foreach (string item in ReadLine_Array)
          {
            dt.Columns.Add();
          }
        }


        DataRow newRow = dt.NewRow();
        for (int j = 0; j < dt.Columns.Count; j++)
        {
          newRow[j] = ReadLine_Array[j];
        }
        dt.Rows.Add(newRow);
      }
      dt.Columns.RemoveAt(12);
      dt.Columns.RemoveAt(11);

      

      List<string> runday = new List<string>();
      List<string> car = new List<string>();

      foreach (DataRow LoopRow in dt.Rows)
      {
        if (LoopRow[0].ToString() == "行駛日")
        {
          for (int i = 0; i < dt.Columns.Count; i++)
          {
            runday.Add(LoopRow[i].ToString());
          }
        }
        if (LoopRow[0].ToString() == "")
        {
          for (int i = 0; i < dt.Columns.Count; i++)
          {
            car.Add(LoopRow[i].ToString());
          }
        }

        if (LoopRow[0].ToString() != "行駛日" && LoopRow[0].ToString() != "")
        {
          string sCountry = LoopRow[0].ToString();
          for (int i = 1; i < dt.Columns.Count; i++)
          {
            string scar = car[i];
            string srunday = runday[i];
            if (LoopRow[i].ToString() == "" || LoopRow[i].ToString() == "↓") continue;
            string stime = LoopRow[i].ToString();

            //解析星期
            List<string> lweek = analyweek(srunday);

            foreach (string Loopweek in lweek)
            {
              DataRow NewRow = dtresult.NewRow();
              NewRow["country"] = sCountry;
              NewRow["week"] = Loopweek;
              NewRow["car"] = scar;
              NewRow["time"] = stime;
              dtresult.Rows.Add(NewRow);
            }            
          }
        }
      }




      DataTable dtn = Transpose(dt);

      string sss = "";

      
      




    }


    private List<string> analyweek(string sweek)
    {
      List<string> lResult = new List<string>();

      if (sweek == "")
      {
        lResult.Add("1");
        lResult.Add("2");
        lResult.Add("3");
        lResult.Add("4");
        lResult.Add("5");
        lResult.Add("6");
        lResult.Add("7");
      }
      else
      {
        string[] aweek1 = sweek.Split('、');
        foreach (string item in aweek1)
        {
          if (item == "一") lResult.Add("1");
          if (item == "二") lResult.Add("2");
          if (item == "三") lResult.Add("3");
          if (item == "四") lResult.Add("4");
          if (item == "五") lResult.Add("5");
          if (item == "六") lResult.Add("6");
          if (item == "日") lResult.Add("7");

          if (item.Contains("~"))
          {
            string[] aweek2 = item.Split('~');

            int iStart = parseweek(aweek2[0]);
            int iEnd = parseweek(aweek2[1]);

            for (int i = iStart; i <= iEnd; i++)
            {
              lResult.Add(i.ToString());
            }
          }
        }
      }




      return lResult;
    }

    private int parseweek(string sw)
    {
      int ir = 0;

      if (sw == "一") ir = 1;
      if (sw == "二") ir = 2;
      if (sw == "三") ir = 3;
      if (sw == "四") ir = 4;
      if (sw == "五") ir = 5;
      if (sw == "六") ir = 6;
      if (sw == "日") ir = 7;      

      return ir;
    }





    private DataTable Transpose(DataTable dt)
    {
      DataTable dtNew = new DataTable();

      //adding columns    
      for (int i = 0; i <= dt.Rows.Count; i++)
      {
        dtNew.Columns.Add(i.ToString());
      }



      //Changing Column Captions: 
      dtNew.Columns[0].ColumnName = " ";

      for (int i = 0; i < dt.Rows.Count; i++)
      {
        //For dateTime columns use like below
        //dtNew.Columns[i + 1].ColumnName = Convert.ToDateTime(dt.Rows[i].ItemArray[0].ToString()).ToString("MM/dd/yyyy");
        //Else just assign the ItermArry[0] to the columnName prooperty
      }

      //Adding Row Data
      for (int k = 1; k < dt.Columns.Count; k++)
      {
        DataRow r = dtNew.NewRow();
        r[0] = dt.Columns[k].ToString();
        for (int j = 1; j <= dt.Rows.Count; j++)
          r[j] = dt.Rows[j - 1][k];
        dtNew.Rows.Add(r);
      }

      return dtNew;
    }


    private DataTable CSVtoDataTable(string filepath)
    {
      int count = 1;
      char fieldSeparator = ',';
      DataTable csvData = new DataTable();

      using (TextFieldParser csvReader = new TextFieldParser(filepath))
      {
        csvReader.HasFieldsEnclosedInQuotes = true;
        while (!csvReader.EndOfData)
        {
          csvReader.SetDelimiters(new string[] { "," });
          string[] fieldData = csvReader.ReadFields();
          if (count == 0)
          {
            foreach (string column in fieldData)
            {
              DataColumn datecolumn = new DataColumn(column);
              datecolumn.AllowDBNull = true;
              csvData.Columns.Add(datecolumn);
            }
          }
          else
          {
            csvData.Rows.Add(fieldData);
          }

        }
      }

      return csvData;

    }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = @"d:\Log_V2.txt";
            string SavePath = @"d:\Log_V3.txt";

            StringBuilder sb = new StringBuilder();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))


            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    
                    using (StreamWriter sw = new StreamWriter(SavePath,true))   //小寫TXT     
                    {
                        sw.WriteLine(line.Replace(", N'", "").Replace("');", ""));
                    }
                }
            }



            //// This text is added only once to the file.
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    string createText = "Hello and Welcome" + Environment.NewLine;
            //    File.WriteAllText(path, createText, Encoding.UTF8);
            //}

            //// This text is always added, making the file longer over time
            //// if it is not deleted.
            //string appendText = "This is extra text" + Environment.NewLine;
            //File.AppendAllText(path, appendText, Encoding.UTF8);

            //// Open the file to read from.
            //string readText = File.ReadAllText(path);
            //Console.WriteLine(readText);
        }
    }
}
