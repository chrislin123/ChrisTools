using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChrisTools
{
  public partial class BaseForm : Form
  {
    public BaseForm()
    {
      InitializeComponent();
    }


    public void InitForm()
    {
      //_ConnectionString = ConfigurationManager.ConnectionStrings[Properties.Settings.Default.DBDefault].ConnectionString;
      //_dbDapper = new DALDapper(_ConnectionString);
      ////oDal = new ODAL(Properties.Settings.Default.DBDefault);
      //logger = NLog.LogManager.GetCurrentClassLogger();
    }

    public void BaseShowStatus(string sMessage)
    {
      ((MainMdiForm)this.ParentForm).ShowStatusBar(sMessage);      
    }


  }
}
