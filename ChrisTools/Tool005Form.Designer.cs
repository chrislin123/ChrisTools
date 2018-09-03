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
            this.btnRemoveMKV = new System.Windows.Forms.Button();
            this.btnMergeMKV = new System.Windows.Forms.Button();
            this.radMKV = new System.Windows.Forms.RadioButton();
            this.radMP4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radASS = new System.Windows.Forms.CheckBox();
            this.radSRT = new System.Windows.Forms.CheckBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnFinish265 = new System.Windows.Forms.Button();
            this.btnBatZip = new System.Windows.Forms.Button();
            this.btnSaveAsSrt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(23, 88);
            this.btnStart.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(184, 58);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = " 批次全啟動(解=>移=>取)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "MkvTool路徑：";
            // 
            // txtMkvToolPath
            // 
            this.txtMkvToolPath.Location = new System.Drawing.Point(149, 5);
            this.txtMkvToolPath.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtMkvToolPath.Name = "txtMkvToolPath";
            this.txtMkvToolPath.Size = new System.Drawing.Size(541, 25);
            this.txtMkvToolPath.TabIndex = 8;
            this.txtMkvToolPath.Text = "C:\\runtime\\mkvtoolnix-64-bit-20.0.0\\mkvtoolnix";
            this.txtMkvToolPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMkvToolPath_MouseClick);
            this.txtMkvToolPath.TextChanged += new System.EventHandler(this.txtMkvToolPath_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "瀏覽";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTransPath
            // 
            this.txtTransPath.Location = new System.Drawing.Point(149, 45);
            this.txtTransPath.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtTransPath.Name = "txtTransPath";
            this.txtTransPath.Size = new System.Drawing.Size(541, 25);
            this.txtTransPath.TabIndex = 14;
            this.txtTransPath.Text = "F:\\temp\\test";
            this.txtTransPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTransPath_MouseClick);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(623, 88);
            this.btnRemoveFile.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(184, 58);
            this.btnRemoveFile.TabIndex = 20;
            this.btnRemoveFile.Text = "移除不必要檔案(RAR,INI)";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "轉檔路徑：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(708, 42);
            this.button4.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 28);
            this.button4.TabIndex = 23;
            this.button4.Text = "瀏覽";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 265);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 15);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "狀態";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 294);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(807, 125);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(273, 262);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(547, 20);
            this.progressBar1.TabIndex = 26;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(20, 238);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(37, 15);
            this.lbltotal.TabIndex = 27;
            this.lbltotal.Text = "數量";
            // 
            // btnBatUnZip
            // 
            this.btnBatUnZip.Location = new System.Drawing.Point(423, 88);
            this.btnBatUnZip.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnBatUnZip.Name = "btnBatUnZip";
            this.btnBatUnZip.Size = new System.Drawing.Size(184, 58);
            this.btnBatUnZip.TabIndex = 28;
            this.btnBatUnZip.Text = "批次解壓縮";
            this.btnBatUnZip.UseVisualStyleBackColor = true;
            this.btnBatUnZip.Click += new System.EventHandler(this.btnBatUnZip_Click);
            // 
            // btnGetSrt
            // 
            this.btnGetSrt.Location = new System.Drawing.Point(223, 88);
            this.btnGetSrt.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnGetSrt.Name = "btnGetSrt";
            this.btnGetSrt.Size = new System.Drawing.Size(184, 58);
            this.btnGetSrt.TabIndex = 29;
            this.btnGetSrt.Text = "批次擷取字幕";
            this.btnGetSrt.UseVisualStyleBackColor = true;
            this.btnGetSrt.Click += new System.EventHandler(this.btnGetSrt_Click);
            // 
            // btnFileNameTune
            // 
            this.btnFileNameTune.Location = new System.Drawing.Point(309, 160);
            this.btnFileNameTune.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnFileNameTune.Name = "btnFileNameTune";
            this.btnFileNameTune.Size = new System.Drawing.Size(105, 58);
            this.btnFileNameTune.TabIndex = 30;
            this.btnFileNameTune.Text = "調整名稱(空白及括弧)";
            this.btnFileNameTune.UseVisualStyleBackColor = true;
            this.btnFileNameTune.Click += new System.EventHandler(this.btnFileNameTune_Click);
            // 
            // btnRemoveMKV
            // 
            this.btnRemoveMKV.Location = new System.Drawing.Point(431, 160);
            this.btnRemoveMKV.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnRemoveMKV.Name = "btnRemoveMKV";
            this.btnRemoveMKV.Size = new System.Drawing.Size(105, 58);
            this.btnRemoveMKV.TabIndex = 31;
            this.btnRemoveMKV.Text = "移除MKV";
            this.btnRemoveMKV.UseVisualStyleBackColor = true;
            this.btnRemoveMKV.Click += new System.EventHandler(this.btnRemoveMKV_Click);
            // 
            // btnMergeMKV
            // 
            this.btnMergeMKV.Location = new System.Drawing.Point(188, 160);
            this.btnMergeMKV.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnMergeMKV.Name = "btnMergeMKV";
            this.btnMergeMKV.Size = new System.Drawing.Size(105, 58);
            this.btnMergeMKV.TabIndex = 32;
            this.btnMergeMKV.Text = "Mkv合併";
            this.btnMergeMKV.UseVisualStyleBackColor = true;
            this.btnMergeMKV.Click += new System.EventHandler(this.btnMergeMKV_Click);
            // 
            // radMKV
            // 
            this.radMKV.AutoSize = true;
            this.radMKV.Checked = true;
            this.radMKV.Location = new System.Drawing.Point(8, 4);
            this.radMKV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radMKV.Name = "radMKV";
            this.radMKV.Size = new System.Drawing.Size(61, 19);
            this.radMKV.TabIndex = 33;
            this.radMKV.TabStop = true;
            this.radMKV.Text = "MKV";
            this.radMKV.UseVisualStyleBackColor = true;
            // 
            // radMP4
            // 
            this.radMP4.AutoSize = true;
            this.radMP4.Location = new System.Drawing.Point(81, 4);
            this.radMP4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radMP4.Name = "radMP4";
            this.radMP4.Size = new System.Drawing.Size(56, 19);
            this.radMP4.TabIndex = 34;
            this.radMP4.TabStop = true;
            this.radMP4.Text = "MP4";
            this.radMP4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radMKV);
            this.panel1.Controls.Add(this.radMP4);
            this.panel1.Location = new System.Drawing.Point(23, 160);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 28);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radASS);
            this.panel2.Controls.Add(this.radSRT);
            this.panel2.Location = new System.Drawing.Point(23, 191);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 28);
            this.panel2.TabIndex = 38;
            // 
            // radASS
            // 
            this.radASS.AutoSize = true;
            this.radASS.Location = new System.Drawing.Point(81, 6);
            this.radASS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radASS.Name = "radASS";
            this.radASS.Size = new System.Drawing.Size(55, 19);
            this.radASS.TabIndex = 38;
            this.radASS.Text = "ASS";
            this.radASS.UseVisualStyleBackColor = true;
            // 
            // radSRT
            // 
            this.radSRT.AutoSize = true;
            this.radSRT.Location = new System.Drawing.Point(8, 6);
            this.radSRT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radSRT.Name = "radSRT";
            this.radSRT.Size = new System.Drawing.Size(55, 19);
            this.radSRT.TabIndex = 37;
            this.radSRT.Text = "SRT";
            this.radSRT.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(273, 235);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(547, 20);
            this.progressBar2.TabIndex = 39;
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(552, 160);
            this.btnSplit.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(105, 58);
            this.btnSplit.TabIndex = 40;
            this.btnSplit.Text = "分類(-1)";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnFinish265
            // 
            this.btnFinish265.Location = new System.Drawing.Point(795, 160);
            this.btnFinish265.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnFinish265.Name = "btnFinish265";
            this.btnFinish265.Size = new System.Drawing.Size(105, 58);
            this.btnFinish265.TabIndex = 41;
            this.btnFinish265.Text = "265轉檔完成處理";
            this.btnFinish265.UseVisualStyleBackColor = true;
            this.btnFinish265.Click += new System.EventHandler(this.btnFinish265_Click);
            // 
            // btnBatZip
            // 
            this.btnBatZip.Location = new System.Drawing.Point(673, 160);
            this.btnBatZip.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnBatZip.Name = "btnBatZip";
            this.btnBatZip.Size = new System.Drawing.Size(105, 58);
            this.btnBatZip.TabIndex = 42;
            this.btnBatZip.Text = "壓縮檔案(5G)";
            this.btnBatZip.UseVisualStyleBackColor = true;
            this.btnBatZip.Click += new System.EventHandler(this.btnAddRAR_Click);
            // 
            // btnSaveAsSrt
            // 
            this.btnSaveAsSrt.Location = new System.Drawing.Point(823, 88);
            this.btnSaveAsSrt.Margin = new System.Windows.Forms.Padding(8);
            this.btnSaveAsSrt.Name = "btnSaveAsSrt";
            this.btnSaveAsSrt.Size = new System.Drawing.Size(105, 58);
            this.btnSaveAsSrt.TabIndex = 43;
            this.btnSaveAsSrt.Text = "另存Srt";
            this.btnSaveAsSrt.UseVisualStyleBackColor = true;
            this.btnSaveAsSrt.Click += new System.EventHandler(this.btnSaveAsSrt_Click);
            // 
            // Tool005Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 434);
            this.Controls.Add(this.btnSaveAsSrt);
            this.Controls.Add(this.btnBatZip);
            this.Controls.Add(this.btnFinish265);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMergeMKV);
            this.Controls.Add(this.btnRemoveMKV);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Tool005Form";
            this.Text = "批次更新檔案名稱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool005Form_FormClosing);
            this.Load += new System.EventHandler(this.Tool005Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    private System.Windows.Forms.Button btnRemoveMKV;
    private System.Windows.Forms.Button btnMergeMKV;
    private System.Windows.Forms.RadioButton radMKV;
    private System.Windows.Forms.RadioButton radMP4;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ProgressBar progressBar2;
    private System.Windows.Forms.CheckBox radSRT;
    private System.Windows.Forms.CheckBox radASS;
    private System.Windows.Forms.Button btnSplit;
    private System.Windows.Forms.Button btnFinish265;
    private System.Windows.Forms.Button btnBatZip;
        private System.Windows.Forms.Button btnSaveAsSrt;
    }
}