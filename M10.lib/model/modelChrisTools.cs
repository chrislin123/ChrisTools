using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using M10.lib;

namespace M10.lib.modelChrisTools
{





  //ssql = @"
  //    CREATE TABLE BaseData(
  //      no INTEGER PRIMARY KEY AUTOINCREMENT,
  //      code           VARCHAR(20)      ,
  //       type           VARCHAR(20)      ,
  //       seq           VARCHAR(20)      ,
  //       data1           VARCHAR(20)    ,  
  //       data2           VARCHAR(20)     , 
  //       updatetime           VARCHAR(19)      
  //   )";


  [Table("BaseData")]
  public class BaseData
  {
    //設定key
    [Key]
    public int no { get; set; }

    public string code { get; set; }

    public string type { get; set; }

    public string seq { get; set; }

    public string data1 { get; set; }

    public string data2 { get; set; }    

    public string updatetime { get; set; }

  }

  [Table("FileTransLog")]
  public class FileTransLog
  {
    //設定key
    [Key]
    public int FileTransNo { get; set; }

    
    public string FileTransName { get; set; }

    public DateTime? FileTransTime { get; set; }

  }


  [Table("StockTransRec")]
  public class StockTransRec
  {
    //設定key
    [Key]
    public int no { get; set; }

    public string stockdate { get; set; }

    public string stockcode { get; set; }

    public string type { get; set; }

    public string status { get; set; }

    public string finish { get; set; }

    public string finishtime { get; set; }

    public string updatetime { get; set; }

  }










}
