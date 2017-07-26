namespace ChrisTools
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
      this.btnTool001 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnTool001
      // 
      this.btnTool001.Location = new System.Drawing.Point(12, 12);
      this.btnTool001.Name = "btnTool001";
      this.btnTool001.Size = new System.Drawing.Size(117, 23);
      this.btnTool001.TabIndex = 0;
      this.btnTool001.Text = "照片整理歸檔功能";
      this.btnTool001.UseVisualStyleBackColor = true;
      this.btnTool001.Click += new System.EventHandler(this.btnTool001_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.btnTool001);
      this.Name = "MainForm";
      this.Text = "工具程式主畫面";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.Button btnTool001;
  }
}

