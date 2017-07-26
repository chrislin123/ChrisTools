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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ssmytest = string.Empty;


        }

    private void btnTool001_Click(object sender, EventArgs e)
    {
      Tool001Form fTool001Form = new Tool001Form();
      
      fTool001Form.ShowDialog();
    }
  }
}
