namespace Spider
{
  partial class SpC040Form
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
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.WriteButton = new System.Windows.Forms.Button();
      this.SheetButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(12, 41);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(445, 209);
      this.richTextBox1.TabIndex = 3;
      this.richTextBox1.Text = "";
      // 
      // WriteButton
      // 
      this.WriteButton.Location = new System.Drawing.Point(12, 12);
      this.WriteButton.Name = "WriteButton";
      this.WriteButton.Size = new System.Drawing.Size(106, 23);
      this.WriteButton.TabIndex = 5;
      this.WriteButton.Text = "ReadDriveToSheet";
      this.WriteButton.UseVisualStyleBackColor = true;
      this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
      // 
      // SheetButton
      // 
      this.SheetButton.Location = new System.Drawing.Point(124, 12);
      this.SheetButton.Name = "SheetButton";
      this.SheetButton.Size = new System.Drawing.Size(75, 23);
      this.SheetButton.TabIndex = 6;
      this.SheetButton.Text = "WriteSheet";
      this.SheetButton.UseVisualStyleBackColor = true;
      this.SheetButton.Click += new System.EventHandler(this.SheetButton_Click);
      // 
      // SpC040Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(467, 269);
      this.Controls.Add(this.SheetButton);
      this.Controls.Add(this.WriteButton);
      this.Controls.Add(this.richTextBox1);
      this.Name = "SpC040Form";
      this.Text = "SpC040Form";
      this.Load += new System.EventHandler(this.SpC040Form_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button WriteButton;
    private System.Windows.Forms.Button SheetButton;
  }
}