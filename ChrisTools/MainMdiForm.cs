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
  public partial class MainMdiForm : Form
  {
    //private int childFormNumber = 0;

    public MainMdiForm()
    {
      InitializeComponent();
    }

    private void ShowNewForm(object sender, EventArgs e)
    {




      //Form childForm = new Form();
      //childForm.MdiParent = this;
      //childForm.Text = "視窗 " + childFormNumber++;
      //childForm.Show();
    }

    private void OpenFile(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      openFileDialog.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
      if (openFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        string FileName = openFileDialog.FileName;
      }
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      saveFileDialog.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
      if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        string FileName = saveFileDialog.FileName;
      }
    }

    private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void CutToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
    }

    private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
    }

    private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.Cascade);
    }

    private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.TileVertical);
    }

    private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.ArrangeIcons);
    }

    private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (Form childForm in MdiChildren)
      {
        childForm.Close();
      }
    }


    public void ShowStatusBar(string sMessage) {


      this.statusStrip.Items[1].Text = sMessage;
      this.Update();
      Application.DoEvents();


    }

    private void MenuItemTool002_Click(object sender, EventArgs e)
    {
      Tool002Form tf = new Tool002Form();
      tf.MdiParent = this;
      tf.Show();
      tf.WindowState = FormWindowState.Maximized;
    }

    private void MenuItemTool001_Click(object sender, EventArgs e)
    {
      Tool001Form tf = new Tool001Form();
      tf.MdiParent = this;
      tf.Show();
      tf.WindowState = FormWindowState.Maximized;
    }

    /// <summary>
    /// 批次更新檔案名稱
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuItemTool003_Click(object sender, EventArgs e)
    {
      Tool003Form tf = new Tool003Form();
      tf.MdiParent = this;
      tf.WindowState = FormWindowState.Maximized;
      tf.Show();
      
    }

    private void MenuItemTool004_Click(object sender, EventArgs e)
    {

      Tool004Form tf = new Tool004Form();
      tf.MdiParent = this;
      tf.WindowState = FormWindowState.Maximized;
      tf.Show();
    }

    private void MenuItemTool005_Click(object sender, EventArgs e)
    {
      Tool005Form tf = new Tool005Form();
      tf.MdiParent = this;
      tf.WindowState = FormWindowState.Maximized;
      tf.Show();
    }
  }

  
}

