namespace ChrisTools
{
  partial class MainMdiForm
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
    /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
    /// 這個方法的內容。
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMdiForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.檔案相關ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool002 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool003 = new System.Windows.Forms.ToolStripMenuItem();
            this.照片相關ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool001 = new System.Windows.Forms.ToolStripMenuItem();
            this.雲端相關ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool004 = new System.Windows.Forms.ToolStripMenuItem();
            this.媒體相關ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTool005 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.轉換相關ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.白馬去除之後文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.檔案相關ToolStripMenuItem,
            this.照片相關ToolStripMenuItem,
            this.雲端相關ToolStripMenuItem,
            this.媒體相關ToolStripMenuItem,
            this.轉換相關ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(927, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printSetupToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(57, 20);
            this.fileMenu.Text = "檔案(&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newToolStripMenuItem.Text = "開新檔案(&N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openToolStripMenuItem.Text = "開啟舊檔(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveToolStripMenuItem.Text = "儲存檔案(&S)";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveAsToolStripMenuItem.Text = "另存新檔(&A)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(182, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printToolStripMenuItem.Text = "列印(&P)";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printPreviewToolStripMenuItem.Text = "預覽列印(&V)";
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printSetupToolStripMenuItem.Text = "列印設定";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "結束(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // 檔案相關ToolStripMenuItem
            // 
            this.檔案相關ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTool002,
            this.MenuItemTool003});
            this.檔案相關ToolStripMenuItem.Name = "檔案相關ToolStripMenuItem";
            this.檔案相關ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.檔案相關ToolStripMenuItem.Text = "檔案相關";
            // 
            // MenuItemTool002
            // 
            this.MenuItemTool002.Name = "MenuItemTool002";
            this.MenuItemTool002.Size = new System.Drawing.Size(182, 22);
            this.MenuItemTool002.Text = "從資料夾移出大檔案";
            this.MenuItemTool002.Click += new System.EventHandler(this.MenuItemTool002_Click);
            // 
            // MenuItemTool003
            // 
            this.MenuItemTool003.Name = "MenuItemTool003";
            this.MenuItemTool003.Size = new System.Drawing.Size(182, 22);
            this.MenuItemTool003.Text = "批次更新檔案名稱";
            this.MenuItemTool003.Click += new System.EventHandler(this.MenuItemTool003_Click);
            // 
            // 照片相關ToolStripMenuItem
            // 
            this.照片相關ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTool001});
            this.照片相關ToolStripMenuItem.Name = "照片相關ToolStripMenuItem";
            this.照片相關ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.照片相關ToolStripMenuItem.Text = "照片相關";
            // 
            // MenuItemTool001
            // 
            this.MenuItemTool001.Name = "MenuItemTool001";
            this.MenuItemTool001.Size = new System.Drawing.Size(170, 22);
            this.MenuItemTool001.Text = "照片整理歸檔功能";
            this.MenuItemTool001.Click += new System.EventHandler(this.MenuItemTool001_Click);
            // 
            // 雲端相關ToolStripMenuItem
            // 
            this.雲端相關ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTool004});
            this.雲端相關ToolStripMenuItem.Name = "雲端相關ToolStripMenuItem";
            this.雲端相關ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.雲端相關ToolStripMenuItem.Text = "雲端相關";
            // 
            // MenuItemTool004
            // 
            this.MenuItemTool004.Name = "MenuItemTool004";
            this.MenuItemTool004.Size = new System.Drawing.Size(158, 22);
            this.MenuItemTool004.Text = "MEGA批次登入";
            this.MenuItemTool004.Click += new System.EventHandler(this.MenuItemTool004_Click);
            // 
            // 媒體相關ToolStripMenuItem
            // 
            this.媒體相關ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTool005});
            this.媒體相關ToolStripMenuItem.Name = "媒體相關ToolStripMenuItem";
            this.媒體相關ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.媒體相關ToolStripMenuItem.Text = "媒體相關";
            // 
            // MenuItemTool005
            // 
            this.MenuItemTool005.Name = "MenuItemTool005";
            this.MenuItemTool005.Size = new System.Drawing.Size(152, 22);
            this.MenuItemTool005.Text = "Mkv提取";
            this.MenuItemTool005.Click += new System.EventHandler(this.MenuItemTool005_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 384);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(927, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel.Text = "狀態";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // 轉換相關ToolStripMenuItem
            // 
            this.轉換相關ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.白馬去除之後文字ToolStripMenuItem});
            this.轉換相關ToolStripMenuItem.Name = "轉換相關ToolStripMenuItem";
            this.轉換相關ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.轉換相關ToolStripMenuItem.Text = "轉換相關";
            // 
            // 白馬去除之後文字ToolStripMenuItem
            // 
            this.白馬去除之後文字ToolStripMenuItem.Name = "白馬去除之後文字ToolStripMenuItem";
            this.白馬去除之後文字ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.白馬去除之後文字ToolStripMenuItem.Text = "白馬去除|之後文字";
            this.白馬去除之後文字ToolStripMenuItem.Click += new System.EventHandler(this.白馬去除之後文字ToolStripMenuItem_Click);
            // 
            // MainMdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 406);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainMdiForm";
            this.Text = "小工具主畫面";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion


    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    private System.Windows.Forms.ToolStripMenuItem fileMenu;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.ToolStripMenuItem 檔案相關ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuItemTool002;
    private System.Windows.Forms.ToolStripMenuItem 照片相關ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuItemTool001;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripMenuItem MenuItemTool003;
    private System.Windows.Forms.ToolStripMenuItem 雲端相關ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuItemTool004;
    private System.Windows.Forms.ToolStripMenuItem 媒體相關ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuItemTool005;
        private System.Windows.Forms.ToolStripMenuItem 轉換相關ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 白馬去除之後文字ToolStripMenuItem;
    }
}



