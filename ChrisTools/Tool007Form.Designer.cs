namespace ChrisTools
{
  partial class Tool007Form
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
            this.txtFFMpegPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTransPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbltotal = new System.Windows.Forms.Label();
            this.btnFFMpegAudio = new System.Windows.Forms.Button();
            this.radDTS = new System.Windows.Forms.RadioButton();
            this.radAC3 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.radAAC = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "FFMpegl路徑：";
            // 
            // txtFFMpegPath
            // 
            this.txtFFMpegPath.Location = new System.Drawing.Point(112, 4);
            this.txtFFMpegPath.Margin = new System.Windows.Forms.Padding(6);
            this.txtFFMpegPath.Name = "txtFFMpegPath";
            this.txtFFMpegPath.Size = new System.Drawing.Size(407, 22);
            this.txtFFMpegPath.TabIndex = 8;
            this.txtFFMpegPath.Text = "C:\\runtime\\mkvtoolnix-64-bit-20.0.0\\mkvtoolnix";
            this.txtFFMpegPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMkvToolPath_MouseClick);
            this.txtFFMpegPath.TextChanged += new System.EventHandler(this.txtMkvToolPath_TextChanged);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 39);
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
            this.lblStatus.Location = new System.Drawing.Point(15, 212);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "狀態";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 235);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(606, 101);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(205, 210);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(410, 16);
            this.progressBar1.TabIndex = 26;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(15, 190);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(29, 12);
            this.lbltotal.TabIndex = 27;
            this.lbltotal.Text = "數量";
            // 
            // btnFFMpegAudio
            // 
            this.btnFFMpegAudio.Location = new System.Drawing.Point(531, 68);
            this.btnFFMpegAudio.Margin = new System.Windows.Forms.Padding(6);
            this.btnFFMpegAudio.Name = "btnFFMpegAudio";
            this.btnFFMpegAudio.Size = new System.Drawing.Size(144, 46);
            this.btnFFMpegAudio.TabIndex = 32;
            this.btnFFMpegAudio.Text = "音訊批次轉檔";
            this.btnFFMpegAudio.UseVisualStyleBackColor = true;
            this.btnFFMpegAudio.Click += new System.EventHandler(this.btnFFMpegAudio_Click);
            // 
            // radDTS
            // 
            this.radDTS.AutoSize = true;
            this.radDTS.Checked = true;
            this.radDTS.Location = new System.Drawing.Point(6, 3);
            this.radDTS.Name = "radDTS";
            this.radDTS.Size = new System.Drawing.Size(44, 16);
            this.radDTS.TabIndex = 33;
            this.radDTS.TabStop = true;
            this.radDTS.Text = "DTS";
            this.radDTS.UseVisualStyleBackColor = true;
            // 
            // radAC3
            // 
            this.radAC3.AutoSize = true;
            this.radAC3.Location = new System.Drawing.Point(61, 3);
            this.radAC3.Name = "radAC3";
            this.radAC3.Size = new System.Drawing.Size(45, 16);
            this.radAC3.TabIndex = 34;
            this.radAC3.TabStop = true;
            this.radAC3.Text = "AC3";
            this.radAC3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radAAC);
            this.panel1.Controls.Add(this.radDTS);
            this.panel1.Controls.Add(this.radAC3);
            this.panel1.Location = new System.Drawing.Point(112, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 22);
            this.panel1.TabIndex = 37;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(205, 188);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(410, 16);
            this.progressBar2.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "音訊格式：";
            // 
            // radAAC
            // 
            this.radAAC.AutoSize = true;
            this.radAAC.Location = new System.Drawing.Point(112, 3);
            this.radAAC.Name = "radAAC";
            this.radAAC.Size = new System.Drawing.Size(47, 16);
            this.radAAC.TabIndex = 35;
            this.radAAC.TabStop = true;
            this.radAAC.Text = "AAC";
            this.radAAC.UseVisualStyleBackColor = true;
            // 
            // Tool007Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 347);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFFMpegAudio);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTransPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFFMpegPath);
            this.Controls.Add(this.button1);
            this.Name = "Tool007Form";
            this.Text = "FFMpeg批次音訊轉檔";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool007Form_FormClosing);
            this.Load += new System.EventHandler(this.Tool007Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFFMpegPath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtTransPath;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lbltotal;
    private System.Windows.Forms.Button btnFFMpegAudio;
    private System.Windows.Forms.RadioButton radDTS;
    private System.Windows.Forms.RadioButton radAC3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.RadioButton radAAC;
        private System.Windows.Forms.Label label1;
    }
}