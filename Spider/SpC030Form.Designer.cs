namespace Spider
{
  partial class SpC030Form
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
      this.AddButton = new System.Windows.Forms.Button();
      this.ReadButton = new System.Windows.Forms.Button();
      this.WriteButton = new System.Windows.Forms.Button();
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
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(12, 12);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(75, 23);
      this.AddButton.TabIndex = 2;
      this.AddButton.Text = "AddSheet";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // ReadButton
      // 
      this.ReadButton.Location = new System.Drawing.Point(93, 12);
      this.ReadButton.Name = "ReadButton";
      this.ReadButton.Size = new System.Drawing.Size(75, 23);
      this.ReadButton.TabIndex = 4;
      this.ReadButton.Text = "Read";
      this.ReadButton.UseVisualStyleBackColor = true;
      this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
      // 
      // WriteButton
      // 
      this.WriteButton.Location = new System.Drawing.Point(174, 12);
      this.WriteButton.Name = "WriteButton";
      this.WriteButton.Size = new System.Drawing.Size(75, 23);
      this.WriteButton.TabIndex = 5;
      this.WriteButton.Text = "Write";
      this.WriteButton.UseVisualStyleBackColor = true;
      this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
      // 
      // SpC030Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(467, 269);
      this.Controls.Add(this.WriteButton);
      this.Controls.Add(this.ReadButton);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.AddButton);
      this.Name = "SpC030Form";
      this.Text = "SpC030Form";
      this.Load += new System.EventHandler(this.SpC030Form_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.Button ReadButton;
    private System.Windows.Forms.Button WriteButton;
  }
}