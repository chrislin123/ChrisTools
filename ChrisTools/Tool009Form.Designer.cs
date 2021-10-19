namespace ChrisTools
{
  partial class Tool009Form
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
            this.btnFFMpegAudio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceFoldIDText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "資料夾路徑：";
            // 
            // txtFFMpegPath
            // 
            this.txtFFMpegPath.Location = new System.Drawing.Point(112, 4);
            this.txtFFMpegPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFFMpegPath.Name = "txtFFMpegPath";
            this.txtFFMpegPath.Size = new System.Drawing.Size(407, 22);
            this.txtFFMpegPath.TabIndex = 8;
            this.txtFFMpegPath.Text = "C:\\gclone\\gclone";
            this.txtFFMpegPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMkvToolPath_MouseClick);
            this.txtFFMpegPath.TextChanged += new System.EventHandler(this.txtMkvToolPath_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "瀏覽";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFFMpegAudio
            // 
            this.btnFFMpegAudio.Location = new System.Drawing.Point(21, 115);
            this.btnFFMpegAudio.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnFFMpegAudio.Name = "btnFFMpegAudio";
            this.btnFFMpegAudio.Size = new System.Drawing.Size(144, 43);
            this.btnFFMpegAudio.TabIndex = 32;
            this.btnFFMpegAudio.Text = "功能1：資料夾刪除指定副檔名檔案";
            this.btnFFMpegAudio.UseVisualStyleBackColor = true;
            this.btnFFMpegAudio.Click += new System.EventHandler(this.btnFFMpegAudio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "指定副檔名：";
            // 
            // SourceFoldIDText
            // 
            this.SourceFoldIDText.Location = new System.Drawing.Point(112, 42);
            this.SourceFoldIDText.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SourceFoldIDText.Name = "SourceFoldIDText";
            this.SourceFoldIDText.Size = new System.Drawing.Size(407, 22);
            this.SourceFoldIDText.TabIndex = 46;
            this.SourceFoldIDText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SourceFoldIDText_MouseClick);
            this.SourceFoldIDText.TextChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "文字框輸入副檔名例如：json";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 115);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 43);
            this.button2.TabIndex = 48;
            this.button2.Text = "功能2：資料夾依照副檔名分類個別資料夾";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Tool009Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 422);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SourceFoldIDText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFFMpegAudio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFFMpegPath);
            this.Controls.Add(this.button1);
            this.Name = "Tool009Form";
            this.Text = "FFMpeg批次音訊轉檔";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool009Form_FormClosing);
            this.Load += new System.EventHandler(this.Tool009Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFFMpegPath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btnFFMpegAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SourceFoldIDText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}