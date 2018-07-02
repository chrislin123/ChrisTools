namespace ChrisTools
{
  partial class Tool005Form
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
      this.btnStart = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMkvToolPath = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.txtTransPath = new System.Windows.Forms.TextBox();
      this.btnRemoveFile = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.button4 = new System.Windows.Forms.Button();
      this.lblStatus = new System.Windows.Forms.Label();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.lbltotal = new System.Windows.Forms.Label();
      this.btnBatUnZip = new System.Windows.Forms.Button();
      this.btnGetSrt = new System.Windows.Forms.Button();
      this.btnFileNameTune = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(17, 70);
      this.btnStart.Margin = new System.Windows.Forms.Padding(6);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(138, 46);
      this.btnStart.TabIndex = 10;
      this.btnStart.Text = " 批次全啟動(解=>移=>取)";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 9);
      this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 12);
      this.label2.TabIndex = 9;
      this.label2.Text = "MkvTool路徑：";
      // 
      // txtMkvToolPath
      // 
      this.txtMkvToolPath.Location = new System.Drawing.Point(112, 4);
      this.txtMkvToolPath.Margin = new System.Windows.Forms.Padding(6);
      this.txtMkvToolPath.Name = "txtMkvToolPath";
      this.txtMkvToolPath.Size = new System.Drawing.Size(407, 22);
      this.txtMkvToolPath.TabIndex = 8;
      this.txtMkvToolPath.Text = "C:\\runtime\\mkvtoolnix-64-bit-20.0.0\\mkvtoolnix";
      this.txtMkvToolPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMkvToolPath_MouseClick);
      this.txtMkvToolPath.TextChanged += new System.EventHandler(this.txtMkvToolPath_TextChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(531, 4);
      this.button1.Margin = new System.Windows.Forms.Padding(6);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(84, 22);
      this.button1.TabIndex = 7;
      this.button1.Text = "瀏覽";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // txtTransPath
      // 
      this.txtTransPath.Location = new System.Drawing.Point(112, 36);
      this.txtTransPath.Margin = new System.Windows.Forms.Padding(6);
      this.txtTransPath.Name = "txtTransPath";
      this.txtTransPath.Size = new System.Drawing.Size(407, 22);
      this.txtTransPath.TabIndex = 14;
      this.txtTransPath.Text = "F:\\temp\\test";
      this.txtTransPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTransPath_MouseClick);
      // 
      // btnRemoveFile
      // 
      this.btnRemoveFile.Location = new System.Drawing.Point(467, 70);
      this.btnRemoveFile.Margin = new System.Windows.Forms.Padding(6);
      this.btnRemoveFile.Name = "btnRemoveFile";
      this.btnRemoveFile.Size = new System.Drawing.Size(138, 46);
      this.btnRemoveFile.TabIndex = 20;
      this.btnRemoveFile.Text = "移除不必要檔案(RAR,INI)";
      this.btnRemoveFile.UseVisualStyleBackColor = true;
      this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(15, 39);
      this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(65, 12);
      this.label5.TabIndex = 22;
      this.label5.Text = "轉檔路徑：";
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(531, 34);
      this.button4.Margin = new System.Windows.Forms.Padding(6);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(84, 22);
      this.button4.TabIndex = 23;
      this.button4.Text = "瀏覽";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // lblStatus
      // 
      this.lblStatus.AutoSize = true;
      this.lblStatus.Location = new System.Drawing.Point(15, 173);
      this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(29, 12);
      this.lblStatus.TabIndex = 24;
      this.lblStatus.Text = "狀態";
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(9, 192);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(606, 148);
      this.richTextBox1.TabIndex = 25;
      this.richTextBox1.Text = "";
      this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(210, 144);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(206, 23);
      this.progressBar1.TabIndex = 26;
      // 
      // lbltotal
      // 
      this.lbltotal.AutoSize = true;
      this.lbltotal.Location = new System.Drawing.Point(15, 149);
      this.lbltotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.lbltotal.Name = "lbltotal";
      this.lbltotal.Size = new System.Drawing.Size(29, 12);
      this.lbltotal.TabIndex = 27;
      this.lbltotal.Text = "數量";
      // 
      // btnBatUnZip
      // 
      this.btnBatUnZip.Location = new System.Drawing.Point(317, 70);
      this.btnBatUnZip.Margin = new System.Windows.Forms.Padding(6);
      this.btnBatUnZip.Name = "btnBatUnZip";
      this.btnBatUnZip.Size = new System.Drawing.Size(138, 46);
      this.btnBatUnZip.TabIndex = 28;
      this.btnBatUnZip.Text = "批次解壓縮";
      this.btnBatUnZip.UseVisualStyleBackColor = true;
      this.btnBatUnZip.Click += new System.EventHandler(this.btnBatUnZip_Click);
      // 
      // btnGetSrt
      // 
      this.btnGetSrt.Location = new System.Drawing.Point(167, 70);
      this.btnGetSrt.Margin = new System.Windows.Forms.Padding(6);
      this.btnGetSrt.Name = "btnGetSrt";
      this.btnGetSrt.Size = new System.Drawing.Size(138, 46);
      this.btnGetSrt.TabIndex = 29;
      this.btnGetSrt.Text = "批次擷取字幕";
      this.btnGetSrt.UseVisualStyleBackColor = true;
      this.btnGetSrt.Click += new System.EventHandler(this.btnGetSrt_Click);
      // 
      // btnFileNameTune
      // 
      this.btnFileNameTune.Location = new System.Drawing.Point(467, 128);
      this.btnFileNameTune.Margin = new System.Windows.Forms.Padding(6);
      this.btnFileNameTune.Name = "btnFileNameTune";
      this.btnFileNameTune.Size = new System.Drawing.Size(138, 46);
      this.btnFileNameTune.TabIndex = 30;
      this.btnFileNameTune.Text = "調整檔案名稱(空白及括弧)";
      this.btnFileNameTune.UseVisualStyleBackColor = true;
      this.btnFileNameTune.Click += new System.EventHandler(this.btnFileNameTune_Click);
      // 
      // Tool005Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(630, 349);
      this.Controls.Add(this.btnFileNameTune);
      this.Controls.Add(this.btnGetSrt);
      this.Controls.Add(this.btnBatUnZip);
      this.Controls.Add(this.lbltotal);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btnRemoveFile);
      this.Controls.Add(this.txtTransPath);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtMkvToolPath);
      this.Controls.Add(this.button1);
      this.Name = "Tool005Form";
      this.Text = "批次更新檔案名稱";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool005Form_FormClosing);
      this.Load += new System.EventHandler(this.Tool005Form_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMkvToolPath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtTransPath;
    private System.Windows.Forms.Button btnRemoveFile;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lbltotal;
    private System.Windows.Forms.Button btnBatUnZip;
    private System.Windows.Forms.Button btnGetSrt;
    private System.Windows.Forms.Button btnFileNameTune;
  }
}