﻿namespace ChrisTools
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
      this.txtFrom = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.NewNameText = new System.Windows.Forms.TextBox();
      this.startindexText = new System.Windows.Forms.TextBox();
      this.lengthText = new System.Windows.Forms.TextBox();
      this.TestButton = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(15, 136);
      this.btnStart.Margin = new System.Windows.Forms.Padding(6);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(138, 46);
      this.btnStart.TabIndex = 10;
      this.btnStart.Text = "啟動";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 9);
      this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 9;
      this.label2.Text = "路徑：";
      // 
      // txtFrom
      // 
      this.txtFrom.Location = new System.Drawing.Point(68, 6);
      this.txtFrom.Margin = new System.Windows.Forms.Padding(6);
      this.txtFrom.Name = "txtFrom";
      this.txtFrom.Size = new System.Drawing.Size(384, 22);
      this.txtFrom.TabIndex = 8;
      this.txtFrom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFrom_MouseClick);
      this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(464, 6);
      this.button1.Margin = new System.Windows.Forms.Padding(6);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(138, 46);
      this.button1.TabIndex = 7;
      this.button1.Text = "瀏覽";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 74);
      this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(101, 12);
      this.label1.TabIndex = 11;
      this.label1.Text = "新檔案名稱格式：";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 105);
      this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(125, 12);
      this.label3.TabIndex = 12;
      this.label3.Text = "舊檔名識別字串起始：";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(269, 112);
      this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(125, 12);
      this.label4.TabIndex = 13;
      this.label4.Text = "舊檔名識別字串長度：";
      // 
      // NewNameText
      // 
      this.NewNameText.Location = new System.Drawing.Point(241, 64);
      this.NewNameText.Margin = new System.Windows.Forms.Padding(6);
      this.NewNameText.Name = "NewNameText";
      this.NewNameText.Size = new System.Drawing.Size(362, 22);
      this.NewNameText.TabIndex = 14;
      // 
      // startindexText
      // 
      this.startindexText.Location = new System.Drawing.Point(152, 102);
      this.startindexText.Margin = new System.Windows.Forms.Padding(6);
      this.startindexText.Name = "startindexText";
      this.startindexText.Size = new System.Drawing.Size(91, 22);
      this.startindexText.TabIndex = 15;
      // 
      // lengthText
      // 
      this.lengthText.Location = new System.Drawing.Point(406, 109);
      this.lengthText.Margin = new System.Windows.Forms.Padding(6);
      this.lengthText.Name = "lengthText";
      this.lengthText.Size = new System.Drawing.Size(98, 22);
      this.lengthText.TabIndex = 16;
      this.lengthText.Text = "2";
      // 
      // TestButton
      // 
      this.TestButton.Location = new System.Drawing.Point(517, 104);
      this.TestButton.Margin = new System.Windows.Forms.Padding(6);
      this.TestButton.Name = "TestButton";
      this.TestButton.Size = new System.Drawing.Size(86, 29);
      this.TestButton.TabIndex = 19;
      this.TestButton.Text = "取得測試";
      this.TestButton.UseVisualStyleBackColor = true;
      this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(191, 136);
      this.button2.Margin = new System.Windows.Forms.Padding(6);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(138, 46);
      this.button2.TabIndex = 20;
      this.button2.Text = "test";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(341, 136);
      this.button3.Margin = new System.Windows.Forms.Padding(6);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(138, 46);
      this.button3.TabIndex = 21;
      this.button3.Text = "test";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // Tool005Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(630, 212);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.TestButton);
      this.Controls.Add(this.lengthText);
      this.Controls.Add(this.startindexText);
      this.Controls.Add(this.NewNameText);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtFrom);
      this.Controls.Add(this.button1);
      this.Name = "Tool005Form";
      this.Text = "批次更新檔案名稱";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFrom;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox NewNameText;
    private System.Windows.Forms.TextBox startindexText;
    private System.Windows.Forms.TextBox lengthText;
    private System.Windows.Forms.Button TestButton;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
  }
}