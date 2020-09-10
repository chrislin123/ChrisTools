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
            this.btnFormatFile = new System.Windows.Forms.Button();
            this.ddlFormatFile = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnProcSRTASS = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TraceIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 70);
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
            this.btnRemoveFile.Location = new System.Drawing.Point(409, 70);
            this.btnRemoveFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(99, 46);
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
            this.lblStatus.Location = new System.Drawing.Point(23, 273);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 12);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "狀態";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 293);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(606, 101);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(213, 271);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(410, 16);
            this.progressBar1.TabIndex = 26;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(23, 251);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(29, 12);
            this.lbltotal.TabIndex = 27;
            this.lbltotal.Text = "數量";
            // 
            // btnBatUnZip
            // 
            this.btnBatUnZip.Location = new System.Drawing.Point(324, 70);
            this.btnBatUnZip.Margin = new System.Windows.Forms.Padding(6);
            this.btnBatUnZip.Name = "btnBatUnZip";
            this.btnBatUnZip.Size = new System.Drawing.Size(76, 46);
            this.btnBatUnZip.TabIndex = 28;
            this.btnBatUnZip.Text = "批次解壓縮";
            this.btnBatUnZip.UseVisualStyleBackColor = true;
            this.btnBatUnZip.Click += new System.EventHandler(this.btnBatUnZip_Click);
            // 
            // btnGetSrt
            // 
            this.btnGetSrt.Location = new System.Drawing.Point(155, 70);
            this.btnGetSrt.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetSrt.Name = "btnGetSrt";
            this.btnGetSrt.Size = new System.Drawing.Size(90, 46);
            this.btnGetSrt.TabIndex = 29;
            this.btnGetSrt.Text = "批次擷取字幕";
            this.btnGetSrt.UseVisualStyleBackColor = true;
            this.btnGetSrt.Click += new System.EventHandler(this.btnGetSrt_Click);
            // 
            // btnFileNameTune
            // 
            this.btnFileNameTune.Location = new System.Drawing.Point(232, 128);
            this.btnFileNameTune.Margin = new System.Windows.Forms.Padding(6);
            this.btnFileNameTune.Name = "btnFileNameTune";
            this.btnFileNameTune.Size = new System.Drawing.Size(79, 46);
            this.btnFileNameTune.TabIndex = 30;
            this.btnFileNameTune.Text = "調整資料夾及檔案名稱";
            this.btnFileNameTune.UseVisualStyleBackColor = true;
            this.btnFileNameTune.Click += new System.EventHandler(this.btnFileNameTune_Click);
            // 
            // btnRemoveMKV
            // 
            this.btnRemoveMKV.Location = new System.Drawing.Point(323, 128);
            this.btnRemoveMKV.Margin = new System.Windows.Forms.Padding(6);
            this.btnRemoveMKV.Name = "btnRemoveMKV";
            this.btnRemoveMKV.Size = new System.Drawing.Size(79, 46);
            this.btnRemoveMKV.TabIndex = 31;
            this.btnRemoveMKV.Text = "移除MKV";
            this.btnRemoveMKV.UseVisualStyleBackColor = true;
            this.btnRemoveMKV.Click += new System.EventHandler(this.btnRemoveMKV_Click);
            // 
            // btnMergeMKV
            // 
            this.btnMergeMKV.Location = new System.Drawing.Point(141, 128);
            this.btnMergeMKV.Margin = new System.Windows.Forms.Padding(6);
            this.btnMergeMKV.Name = "btnMergeMKV";
            this.btnMergeMKV.Size = new System.Drawing.Size(79, 46);
            this.btnMergeMKV.TabIndex = 32;
            this.btnMergeMKV.Text = "Mkv合併";
            this.btnMergeMKV.UseVisualStyleBackColor = true;
            this.btnMergeMKV.Click += new System.EventHandler(this.btnMergeMKV_Click);
            // 
            // radMKV
            // 
            this.radMKV.AutoSize = true;
            this.radMKV.Checked = true;
            this.radMKV.Location = new System.Drawing.Point(6, 3);
            this.radMKV.Name = "radMKV";
            this.radMKV.Size = new System.Drawing.Size(49, 16);
            this.radMKV.TabIndex = 33;
            this.radMKV.TabStop = true;
            this.radMKV.Text = "MKV";
            this.radMKV.UseVisualStyleBackColor = true;
            // 
            // radMP4
            // 
            this.radMP4.AutoSize = true;
            this.radMP4.Location = new System.Drawing.Point(61, 3);
            this.radMP4.Name = "radMP4";
            this.radMP4.Size = new System.Drawing.Size(45, 16);
            this.radMP4.TabIndex = 34;
            this.radMP4.TabStop = true;
            this.radMP4.Text = "MP4";
            this.radMP4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radMKV);
            this.panel1.Controls.Add(this.radMP4);
            this.panel1.Location = new System.Drawing.Point(17, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 22);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radASS);
            this.panel2.Controls.Add(this.radSRT);
            this.panel2.Location = new System.Drawing.Point(17, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(115, 22);
            this.panel2.TabIndex = 38;
            // 
            // radASS
            // 
            this.radASS.AutoSize = true;
            this.radASS.Location = new System.Drawing.Point(61, 5);
            this.radASS.Name = "radASS";
            this.radASS.Size = new System.Drawing.Size(44, 16);
            this.radASS.TabIndex = 38;
            this.radASS.Text = "ASS";
            this.radASS.UseVisualStyleBackColor = true;
            // 
            // radSRT
            // 
            this.radSRT.AutoSize = true;
            this.radSRT.Location = new System.Drawing.Point(6, 5);
            this.radSRT.Name = "radSRT";
            this.radSRT.Size = new System.Drawing.Size(45, 16);
            this.radSRT.TabIndex = 37;
            this.radSRT.Text = "SRT";
            this.radSRT.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(213, 249);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(410, 16);
            this.progressBar2.TabIndex = 39;
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(414, 128);
            this.btnSplit.Margin = new System.Windows.Forms.Padding(6);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(79, 46);
            this.btnSplit.TabIndex = 40;
            this.btnSplit.Text = "分類(-1)";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnFinish265
            // 
            this.btnFinish265.Location = new System.Drawing.Point(596, 128);
            this.btnFinish265.Margin = new System.Windows.Forms.Padding(6);
            this.btnFinish265.Name = "btnFinish265";
            this.btnFinish265.Size = new System.Drawing.Size(96, 46);
            this.btnFinish265.TabIndex = 41;
            this.btnFinish265.Text = "轉檔完成處理(256-MP4-RAR)";
            this.btnFinish265.UseVisualStyleBackColor = true;
            this.btnFinish265.Click += new System.EventHandler(this.btnFinish265_Click);
            // 
            // btnBatZip
            // 
            this.btnBatZip.Location = new System.Drawing.Point(505, 128);
            this.btnBatZip.Margin = new System.Windows.Forms.Padding(6);
            this.btnBatZip.Name = "btnBatZip";
            this.btnBatZip.Size = new System.Drawing.Size(79, 46);
            this.btnBatZip.TabIndex = 42;
            this.btnBatZip.Text = "壓縮檔案(5G)";
            this.btnBatZip.UseVisualStyleBackColor = true;
            this.btnBatZip.Click += new System.EventHandler(this.btnAddRAR_Click);
            // 
            // btnSaveAsSrt
            // 
            this.btnSaveAsSrt.Location = new System.Drawing.Point(538, 70);
            this.btnSaveAsSrt.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveAsSrt.Name = "btnSaveAsSrt";
            this.btnSaveAsSrt.Size = new System.Drawing.Size(79, 46);
            this.btnSaveAsSrt.TabIndex = 43;
            this.btnSaveAsSrt.Text = "另存Srt";
            this.btnSaveAsSrt.UseVisualStyleBackColor = true;
            this.btnSaveAsSrt.Click += new System.EventHandler(this.btnSaveAsSrt_Click);
            // 
            // btnFormatFile
            // 
            this.btnFormatFile.Location = new System.Drawing.Point(17, 403);
            this.btnFormatFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnFormatFile.Name = "btnFormatFile";
            this.btnFormatFile.Size = new System.Drawing.Size(138, 23);
            this.btnFormatFile.TabIndex = 44;
            this.btnFormatFile.Text = "格式化檔案名稱";
            this.btnFormatFile.UseVisualStyleBackColor = true;
            this.btnFormatFile.Click += new System.EventHandler(this.BtnFormatFile_Click);
            // 
            // ddlFormatFile
            // 
            this.ddlFormatFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFormatFile.FormattingEnabled = true;
            this.ddlFormatFile.Items.AddRange(new object[] {
            "[歐美]-[英語][官譯]",
            "[動畫]-[台配][台字]",
            "[台灣]-[國語][官譯]",
            "[香港]-[國語][官譯]",
            "[日本]-[日語][官譯]",
            "[韓國]-[韓語][官譯]",
            "[德國]-[德語][官譯]",
            "[法國]-[法語][官譯]",
            "[中國]-[國語][官譯]"});
            this.ddlFormatFile.Location = new System.Drawing.Point(178, 404);
            this.ddlFormatFile.Name = "ddlFormatFile";
            this.ddlFormatFile.Size = new System.Drawing.Size(315, 20);
            this.ddlFormatFile.TabIndex = 45;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 70);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 46);
            this.button2.TabIndex = 46;
            this.button2.Text = "test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnProcSRTASS
            // 
            this.btnProcSRTASS.Location = new System.Drawing.Point(15, 183);
            this.btnProcSRTASS.Margin = new System.Windows.Forms.Padding(6);
            this.btnProcSRTASS.Name = "btnProcSRTASS";
            this.btnProcSRTASS.Size = new System.Drawing.Size(79, 46);
            this.btnProcSRTASS.TabIndex = 47;
            this.btnProcSRTASS.Text = "字幕轉換及處理(網路轉繁體)";
            this.btnProcSRTASS.UseVisualStyleBackColor = true;
            this.btnProcSRTASS.Click += new System.EventHandler(this.btnProcSRTASS_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(106, 184);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 46);
            this.button3.TabIndex = 48;
            this.button3.Text = "字幕轉換及處理(產生SRT跟ASS)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TraceIDText
            // 
            this.TraceIDText.Location = new System.Drawing.Point(257, 94);
            this.TraceIDText.Margin = new System.Windows.Forms.Padding(6);
            this.TraceIDText.Name = "TraceIDText";
            this.TraceIDText.Size = new System.Drawing.Size(53, 22);
            this.TraceIDText.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "擷取軌道";
            // 
            // Tool005Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 476);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TraceIDText);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnProcSRTASS);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ddlFormatFile);
            this.Controls.Add(this.btnFormatFile);
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
        private System.Windows.Forms.Button btnFormatFile;
        private System.Windows.Forms.ComboBox ddlFormatFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnProcSRTASS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TraceIDText;
        private System.Windows.Forms.Label label1;
    }
}