namespace Spider
{
  partial class SpC010Form
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
      this.StartButton = new System.Windows.Forms.Button();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.FileSavePathText = new System.Windows.Forms.TextBox();
      this.FileSavePathButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // StartButton
      // 
      this.StartButton.Location = new System.Drawing.Point(12, 12);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(75, 23);
      this.StartButton.TabIndex = 0;
      this.StartButton.Text = "Start";
      this.StartButton.UseVisualStyleBackColor = true;
      this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(12, 41);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(445, 209);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      // 
      // FileSavePathText
      // 
      this.FileSavePathText.Location = new System.Drawing.Point(187, 12);
      this.FileSavePathText.Name = "FileSavePathText";
      this.FileSavePathText.Size = new System.Drawing.Size(243, 22);
      this.FileSavePathText.TabIndex = 2;
      // 
      // FileSavePathButton
      // 
      this.FileSavePathButton.Location = new System.Drawing.Point(436, 12);
      this.FileSavePathButton.Name = "FileSavePathButton";
      this.FileSavePathButton.Size = new System.Drawing.Size(21, 23);
      this.FileSavePathButton.TabIndex = 3;
      this.FileSavePathButton.Text = "瀏";
      this.FileSavePathButton.UseVisualStyleBackColor = true;
      this.FileSavePathButton.Click += new System.EventHandler(this.FileSavePathButton_Click);
      // 
      // SpC010Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(469, 262);
      this.Controls.Add(this.FileSavePathButton);
      this.Controls.Add(this.FileSavePathText);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.StartButton);
      this.Name = "SpC010Form";
      this.Text = "SpC010Form";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button StartButton;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.TextBox FileSavePathText;
    private System.Windows.Forms.Button FileSavePathButton;
  }
}