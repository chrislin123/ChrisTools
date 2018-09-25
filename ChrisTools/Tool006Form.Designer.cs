namespace ChrisTools
{
    partial class Tool006Form
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
            this.btnTrans = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnTrans
            // 
            this.btnTrans.Location = new System.Drawing.Point(12, 21);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(75, 23);
            this.btnTrans.TabIndex = 0;
            this.btnTrans.Text = "格式轉換";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 50);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(401, 304);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(419, 50);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(427, 304);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            this.richTextBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox2_MouseClick);
            // 
            // Tool006Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 395);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnTrans);
            this.Name = "Tool006Form";
            this.Text = "Tool006Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}