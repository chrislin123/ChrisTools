namespace CheckOver4gFile
{
    partial class CheckOver4g
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnRAR = new System.Windows.Forms.Button();
            this.chkWait = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(695, 8);
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
            this.label2.Location = new System.Drawing.Point(32, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "解析路徑：";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(149, 16);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(6);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(384, 22);
            this.txtFrom.TabIndex = 8;
            this.txtFrom.Text = "D:\\!testRAR";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(545, 8);
            this.btnBrowser.Margin = new System.Windows.Forms.Padding(6);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(138, 46);
            this.btnBrowser.TabIndex = 7;
            this.btnBrowser.Text = "瀏覽";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 12;
            this.lstFiles.Location = new System.Drawing.Point(34, 60);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(799, 232);
            this.lstFiles.TabIndex = 12;
            // 
            // btnRAR
            // 
            this.btnRAR.Location = new System.Drawing.Point(845, 8);
            this.btnRAR.Margin = new System.Windows.Forms.Padding(6);
            this.btnRAR.Name = "btnRAR";
            this.btnRAR.Size = new System.Drawing.Size(138, 46);
            this.btnRAR.TabIndex = 13;
            this.btnRAR.Text = "RAR壓縮各檔案資料夾(切3g大小)";
            this.btnRAR.UseVisualStyleBackColor = true;
            this.btnRAR.Click += new System.EventHandler(this.btnRAR_Click);
            // 
            // chkWait
            // 
            this.chkWait.AutoSize = true;
            this.chkWait.Location = new System.Drawing.Point(856, 60);
            this.chkWait.Name = "chkWait";
            this.chkWait.Size = new System.Drawing.Size(72, 16);
            this.chkWait.TabIndex = 14;
            this.chkWait.Text = "是否等待";
            this.chkWait.UseVisualStyleBackColor = true;
            // 
            // CheckOver4g
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 555);
            this.Controls.Add(this.chkWait);
            this.Controls.Add(this.btnRAR);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.btnBrowser);
            this.Name = "CheckOver4g";
            this.Text = "判斷資料夾中大於4g的檔案功能";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnRAR;
        private System.Windows.Forms.CheckBox chkWait;
    }
}

