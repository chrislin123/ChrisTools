namespace BlackHoleSupport
{
    partial class BHSup
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblNoS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoE = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNoR = new System.Windows.Forms.Label();
            this.txthtml = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 280);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1334, 499);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://megafunpro.com/forum.php", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(1239, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 35);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "啟動";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNoS
            // 
            this.lblNoS.AutoSize = true;
            this.lblNoS.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNoS.Location = new System.Drawing.Point(156, 17);
            this.lblNoS.Name = "lblNoS";
            this.lblNoS.Size = new System.Drawing.Size(21, 24);
            this.lblNoS.TabIndex = 3;
            this.lblNoS.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "號碼起訖：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(246, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "到";
            // 
            // lblNoE
            // 
            this.lblNoE.AutoSize = true;
            this.lblNoE.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNoE.Location = new System.Drawing.Point(286, 17);
            this.lblNoE.Name = "lblNoE";
            this.lblNoE.Size = new System.Drawing.Size(21, 24);
            this.lblNoE.TabIndex = 6;
            this.lblNoE.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(389, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "目前號碼：";
            // 
            // lblNoR
            // 
            this.lblNoR.AutoSize = true;
            this.lblNoR.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNoR.Location = new System.Drawing.Point(525, 17);
            this.lblNoR.Name = "lblNoR";
            this.lblNoR.Size = new System.Drawing.Size(21, 24);
            this.lblNoR.TabIndex = 8;
            this.lblNoR.Text = "0";
            // 
            // txthtml
            // 
            this.txthtml.Location = new System.Drawing.Point(0, 53);
            this.txthtml.Multiline = true;
            this.txthtml.Name = "txthtml";
            this.txthtml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txthtml.Size = new System.Drawing.Size(1322, 221);
            this.txthtml.TabIndex = 9;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTest.Location = new System.Drawing.Point(1150, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(83, 35);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "測試";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // BHSup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 779);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txthtml);
            this.Controls.Add(this.lblNoR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNoE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNoS);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.webBrowser1);
            this.Name = "BHSup";
            this.Text = "黑洞論壇_支持功能";
            this.Load += new System.EventHandler(this.BHSup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNoS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNoR;
        private System.Windows.Forms.TextBox txthtml;
        private System.Windows.Forms.Button btnTest;
    }
}

