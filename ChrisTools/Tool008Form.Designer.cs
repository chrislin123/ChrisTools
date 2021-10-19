namespace ChrisTools
{
  partial class Tool008Form
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnFFMpegAudio = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.radSource1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radSource3 = new System.Windows.Forms.RadioButton();
            this.radSource2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceFoldIDText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TargetFoldIDText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radTarget3 = new System.Windows.Forms.RadioButton();
            this.radTarget2 = new System.Windows.Forms.RadioButton();
            this.radTarget1 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "GClone程式路徑：";
            // 
            // txtFFMpegPath
            // 
            this.txtFFMpegPath.Location = new System.Drawing.Point(112, 4);
            this.txtFFMpegPath.Margin = new System.Windows.Forms.Padding(6);
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
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "瀏覽";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 166);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 12);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "指令碼樣板：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 181);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(735, 101);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnFFMpegAudio
            // 
            this.btnFFMpegAudio.Location = new System.Drawing.Point(600, 110);
            this.btnFFMpegAudio.Margin = new System.Windows.Forms.Padding(6);
            this.btnFFMpegAudio.Name = "btnFFMpegAudio";
            this.btnFFMpegAudio.Size = new System.Drawing.Size(144, 45);
            this.btnFFMpegAudio.TabIndex = 32;
            this.btnFFMpegAudio.Text = "確認執行轉檔";
            this.btnFFMpegAudio.UseVisualStyleBackColor = true;
            this.btnFFMpegAudio.Click += new System.EventHandler(this.btnFFMpegAudio_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 298);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "實際執行指令碼：";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 313);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(735, 101);
            this.richTextBox2.TabIndex = 42;
            this.richTextBox2.Text = "";
            // 
            // radSource1
            // 
            this.radSource1.AutoSize = true;
            this.radSource1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radSource1.Location = new System.Drawing.Point(3, 3);
            this.radSource1.Name = "radSource1";
            this.radSource1.Size = new System.Drawing.Size(52, 20);
            this.radSource1.TabIndex = 43;
            this.radSource1.TabStop = true;
            this.radSource1.Text = "area";
            this.radSource1.UseVisualStyleBackColor = true;
            this.radSource1.CheckedChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radSource3);
            this.panel1.Controls.Add(this.radSource2);
            this.panel1.Controls.Add(this.radSource1);
            this.panel1.Location = new System.Drawing.Point(112, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 28);
            this.panel1.TabIndex = 44;
            // 
            // radSource3
            // 
            this.radSource3.AutoSize = true;
            this.radSource3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radSource3.Location = new System.Drawing.Point(185, 3);
            this.radSource3.Name = "radSource3";
            this.radSource3.Size = new System.Drawing.Size(73, 20);
            this.radSource3.TabIndex = 45;
            this.radSource3.TabStop = true;
            this.radSource3.Text = "bak001";
            this.radSource3.UseVisualStyleBackColor = true;
            this.radSource3.CheckedChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // radSource2
            // 
            this.radSource2.AutoSize = true;
            this.radSource2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radSource2.Location = new System.Drawing.Point(94, 3);
            this.radSource2.Name = "radSource2";
            this.radSource2.Size = new System.Drawing.Size(47, 20);
            this.radSource2.TabIndex = 44;
            this.radSource2.TabStop = true;
            this.radSource2.Text = "ucs";
            this.radSource2.UseVisualStyleBackColor = true;
            this.radSource2.CheckedChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "[來源]主機：";
            // 
            // SourceFoldIDText
            // 
            this.SourceFoldIDText.Location = new System.Drawing.Point(112, 69);
            this.SourceFoldIDText.Margin = new System.Windows.Forms.Padding(6);
            this.SourceFoldIDText.Name = "SourceFoldIDText";
            this.SourceFoldIDText.Size = new System.Drawing.Size(407, 22);
            this.SourceFoldIDText.TabIndex = 46;
            this.SourceFoldIDText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SourceFoldIDText_MouseClick);
            this.SourceFoldIDText.TextChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "[來源]資料夾：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 12);
            this.label5.TabIndex = 51;
            this.label5.Text = "[目標]資料夾：";
            // 
            // TargetFoldIDText
            // 
            this.TargetFoldIDText.Location = new System.Drawing.Point(112, 133);
            this.TargetFoldIDText.Margin = new System.Windows.Forms.Padding(6);
            this.TargetFoldIDText.Name = "TargetFoldIDText";
            this.TargetFoldIDText.Size = new System.Drawing.Size(407, 22);
            this.TargetFoldIDText.TabIndex = 50;
            this.TargetFoldIDText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TargetFoldIDText_MouseClick);
            this.TargetFoldIDText.TextChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "[目標]主機：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radTarget3);
            this.panel2.Controls.Add(this.radTarget2);
            this.panel2.Controls.Add(this.radTarget1);
            this.panel2.Location = new System.Drawing.Point(112, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 28);
            this.panel2.TabIndex = 48;
            // 
            // radTarget3
            // 
            this.radTarget3.AutoSize = true;
            this.radTarget3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radTarget3.Location = new System.Drawing.Point(185, 3);
            this.radTarget3.Name = "radTarget3";
            this.radTarget3.Size = new System.Drawing.Size(73, 20);
            this.radTarget3.TabIndex = 45;
            this.radTarget3.TabStop = true;
            this.radTarget3.Text = "bak001";
            this.radTarget3.UseVisualStyleBackColor = true;
            this.radTarget3.CheckedChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // radTarget2
            // 
            this.radTarget2.AutoSize = true;
            this.radTarget2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radTarget2.Location = new System.Drawing.Point(94, 3);
            this.radTarget2.Name = "radTarget2";
            this.radTarget2.Size = new System.Drawing.Size(47, 20);
            this.radTarget2.TabIndex = 44;
            this.radTarget2.TabStop = true;
            this.radTarget2.Text = "ucs";
            this.radTarget2.UseVisualStyleBackColor = true;
            this.radTarget2.CheckedChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // radTarget1
            // 
            this.radTarget1.AutoSize = true;
            this.radTarget1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radTarget1.Location = new System.Drawing.Point(3, 3);
            this.radTarget1.Name = "radTarget1";
            this.radTarget1.Size = new System.Drawing.Size(52, 20);
            this.radTarget1.TabIndex = 43;
            this.radTarget1.TabStop = true;
            this.radTarget1.Text = "area";
            this.radTarget1.UseVisualStyleBackColor = true;
            this.radTarget1.CheckedChanged += new System.EventHandler(this.All_TextChanged);
            // 
            // Tool008Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 422);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TargetFoldIDText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SourceFoldIDText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFFMpegAudio);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFFMpegPath);
            this.Controls.Add(this.button1);
            this.Name = "Tool008Form";
            this.Text = "FFMpeg批次音訊轉檔";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool008Form_FormClosing);
            this.Load += new System.EventHandler(this.Tool008Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFFMpegPath;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button btnFFMpegAudio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RadioButton radSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radSource3;
        private System.Windows.Forms.RadioButton radSource2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SourceFoldIDText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TargetFoldIDText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radTarget3;
        private System.Windows.Forms.RadioButton radTarget2;
        private System.Windows.Forms.RadioButton radTarget1;
    }
}