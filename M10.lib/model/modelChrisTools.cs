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


    [Table("SrtInfo")]
    public class SrtInfo
    {
        public string Start = string.Empty;
        public string End = string.Empty;
        public string Style = string.Empty;
        public List<string> ContentList = new List<string>();
    }


    
    [Table("SubTitleInfo")]
    public class SubTitleInfo
    {
        //字幕檔案名稱
        public string SubTitleFileName = string.Empty;
        //轉檔狀態，預設為N
        public string SubTitleTransYN = "N";
        //字幕內容序列
        public List<SrtInfo> SrtInfoList = new List<SrtInfo>();
    }








}
