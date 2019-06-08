using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using M10.lib;

namespace ChrisTools
{
    public partial class BaseForm : Form
    {
        public string ssql = string.Empty;
        private string _ConnectionString;
        //public ODAL oDal;
        private DALDapper _dbDapper;
        private Comm _Comm;

        public BaseForm()
        {
            //InitializeComponent();
        }


        public void InitForm()
        {
            //_ConnectionString = ConfigurationManager.ConnectionStrings[Properties.Settings.Default.DBDefault].ConnectionString;
            //修改從App.config中取得預設連線字串
            _ConnectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DBDefault"]].ConnectionString;
            _dbDapper = new DALDapper(_ConnectionString);
            ////oDal = new ODAL(Properties.Settings.Default.DBDefault);
            //logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void BaseShowStatus(string sMessage)
        {
            ((MainMdiForm)this.ParentForm).ShowStatusBar(sMessage);
        }


        public DALDapper dbDapper
        {
            get
            {
                if (_dbDapper == null)
                {
                    _dbDapper = new DALDapper(ConnectionString);
                }

                return _dbDapper;
            }
        }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_ConnectionString))
                {
                    //_ConnectionString = ConfigurationManager.ConnectionStrings[Properties.Settings.Default.DBDefault].ConnectionString;
                    //修改從App.config中取得預設連線字串
                    _ConnectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DBDefault"]].ConnectionString;
                }
                
                return _ConnectionString;
            }
        }

        public Comm Comm
        {
            get
            {
                if (_Comm == null)
                {
                    _Comm = new Comm(dbDapper);
                }

                return _Comm;
            }
        }


    }
}
