using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
  }
}
