using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M10.lib;
using M10.lib.modelChrisTools;

namespace ChrisTools
{
    public class Comm
    {
        string ssql;
        DALDapper dbDapper = null;

        public Comm(DALDapper pDALDapper)
        {

            dbDapper = pDALDapper;
        }



        public string GetSetting(CTsConst.SettingList SettingItem)
        {
            string sResult = "";

            //取得預設值
            ssql = "select * from basedata where type = @type";
            var q = dbDapper.GetNewDynamicParameters();
            q.Add("type", SettingItem.ToString());
            BaseData bdMkvToolPath = dbDapper.QuerySingleOrDefault<BaseData>(ssql, q);
            sResult = bdMkvToolPath == null ? "" : bdMkvToolPath.data1;

            return sResult;
        }

        public string SetSetting(CTsConst.SettingList SettingItem, string sData)
        {
            string sResult = "";

            //取得預設值
            ssql = "select * from basedata where type = @type";
            var q = dbDapper.GetNewDynamicParameters();
            q.Add("type", SettingItem.ToString());
            BaseData bdMkvToolPath = dbDapper.QuerySingleOrDefault<BaseData>(ssql, q);
            if (bdMkvToolPath == null)
            {
                bdMkvToolPath = new BaseData();
                bdMkvToolPath.type = SettingItem.ToString();
                bdMkvToolPath.data1 = sData;
                dbDapper.Insert(bdMkvToolPath);
            }
            else
            {
                bdMkvToolPath.data1 = sData;
                dbDapper.Update(bdMkvToolPath);
            }

            return sResult;
        }

    }

    public static class CTsConst
    {
        public static string StockAfterTseUrl = "http://www.tse.com.tw/exchangeReport/MI_INDEX?response=csv&date={0}&type=ALLBUT0999";
        public static string StockAfterOtcUrl = "http://www.tpex.org.tw/web/stock/aftertrading/daily_close_quotes/stk_quote_download.php?l=zh-tw&d={0}&s=0,asc,0";



        //public static class SettingList
        //{

        //  public const string Tool005_MkvToolPath = "Tool005_MkvToolPath";
        //  public const string Tool005_TransPath = "Tool005_TransPath";

        //}


        public enum SettingList
        {
            Tool005_MkvToolPath,
            Tool005_TransPath,
            Tool007_FFMpegPath,
            Tool007_TransPath,
            /// <summary>
            /// gClone程式路徑
            /// </summary>
            Tool008_PathGClone,
            /// <summary>
            /// gClone指令碼樣板
            /// </summary>
            Tool008_GCloneCommString,

        }

    }


}
