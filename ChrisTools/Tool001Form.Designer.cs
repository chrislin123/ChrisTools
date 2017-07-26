namespace ChrisTools
{
  partial class Tool001Form
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label2 = new System.Windows.Forms.Label();
      this.txtFrom = new System.Windows.Forms.TextBox();
      this.btnBrowser = new System.Windows.Forms.Button();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnGetout = new System.Windows.Forms.Button();
      this.ResultTextbox = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(-109, 119);
      this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 12);
      this.label2.TabIndex = 13;
      this.label2.Text = "解析路徑：";
      // 
      // txtFrom
      // 
      this.txtFrom.Location = new System.Drawing.Point(15, 15);
      this.txtFrom.Margin = new System.Windows.Forms.Padding(6);
      this.txtFrom.Name = "txtFrom";
      this.txtFrom.Size = new System.Drawing.Size(524, 22);
      this.txtFrom.TabIndex = 12;
      this.txtFrom.Text = "D:\\!testRAR";
      // 
      // btnBrowser
      // 
      this.btnBrowser.Location = new System.Drawing.Point(548, 13);
      this.btnBrowser.Name = "btnBrowser";
      this.btnBrowser.Size = new System.Drawing.Size(75, 23);
      this.btnBrowser.TabIndex = 15;
      this.btnBrowser.Text = "瀏覽";
      this.btnBrowser.UseVisualStyleBackColor = true;
      this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(629, 13);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 16;
      this.btnStart.Text = "啟動";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnGetout
      // 
      this.btnGetout.Location = new System.Drawing.Point(710, 14);
      this.btnGetout.Name = "btnGetout";
      this.btnGetout.Size = new System.Drawing.Size(75, 23);
      this.btnGetout.TabIndex = 17;
      this.btnGetout.Text = "取出";
      this.btnGetout.UseVisualStyleBackColor = true;
      this.btnGetout.Click += new System.EventHandler(this.btnGetout_Click);
      // 
      // ResultTextbox
      // 
      this.ResultTextbox.Location = new System.Drawing.Point(15, 46);
      this.ResultTextbox.Name = "ResultTextbox";
      this.ResultTextbox.Size = new System.Drawing.Size(770, 296);
      this.ResultTextbox.TabIndex = 18;
      this.ResultTextbox.Text = "";
      // 
      // Tool001Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(793, 354);
      this.Controls.Add(this.ResultTextbox);
      this.Controls.Add(this.btnGetout);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.btnBrowser);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtFrom);
      this.Name = "Tool001Form";
      this.Text = "照片整理歸檔功能";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFrom;
    private System.Windows.Forms.Button btnBrowser;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnGetout;
    private System.Windows.Forms.RichTextBox ResultTextbox;
  }
}