namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.IE首页 = new DevExpress.XtraTab.XtraTabPage();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.收藏夹 = new System.Windows.Forms.ToolStripMenuItem();
            this.工具 = new System.Windows.Forms.ToolStripMenuItem();
            this.主页设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建内核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建谷歌内核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建IE内核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建火狐内核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(xtraTabControl1)).BeginInit();
            xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            xtraTabControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xtraTabControl1.BackgroundImage")));
            xtraTabControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            xtraTabControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraTab.Buttons.CustomHeaderButton[] {
            new DevExpress.XtraTab.Buttons.CustomHeaderButton()});
            xtraTabControl1.Location = new System.Drawing.Point(0, 36);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = this.IE首页;
            xtraTabControl1.Size = new System.Drawing.Size(1361, 718);
            xtraTabControl1.TabIndex = 0;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.IE首页});
            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            xtraTabControl1.CloseButtonClick += new System.EventHandler(xtraTabControl1_CloseButtonClick);
            // 
            // IE首页
            // 
            this.IE首页.Name = "IE首页";
            this.IE首页.Size = new System.Drawing.Size(1354, 682);
            this.IE首页.Text = "首页";
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxControl1.Location = new System.Drawing.Point(115, 36);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(796, 95);
            this.listBoxControl1.TabIndex = 29;
            this.listBoxControl1.SelectedIndexChanged += new System.EventHandler(this.listBoxControl1_SelectedIndexChanged);
            this.listBoxControl1.DoubleClick += new System.EventHandler(this.listBoxControl1_DoubleClick);
            this.listBoxControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxControl1_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(919, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(950, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.收藏夹,
            this.工具,
            this.帮助,
            this.新建内核ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(942, 6);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(339, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 收藏夹
            // 
            this.收藏夹.Image = ((System.Drawing.Image)(resources.GetObject("收藏夹.Image")));
            this.收藏夹.Name = "收藏夹";
            this.收藏夹.Size = new System.Drawing.Size(86, 24);
            this.收藏夹.Text = "收藏夹";
            // 
            // 工具
            // 
            this.工具.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主页设置ToolStripMenuItem,
            this.选项OToolStripMenuItem,
            this.自定义CToolStripMenuItem,
            this.历史记录ToolStripMenuItem});
            this.工具.Image = ((System.Drawing.Image)(resources.GetObject("工具.Image")));
            this.工具.Name = "工具";
            this.工具.Size = new System.Drawing.Size(71, 24);
            this.工具.Text = "工具";
            // 
            // 主页设置ToolStripMenuItem
            // 
            this.主页设置ToolStripMenuItem.Name = "主页设置ToolStripMenuItem";
            this.主页设置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.主页设置ToolStripMenuItem.Text = "主页设置";
            this.主页设置ToolStripMenuItem.Click += new System.EventHandler(this.主页设置ToolStripMenuItem_Click);
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.选项OToolStripMenuItem.Text = "收藏当前地址";
            this.选项OToolStripMenuItem.Click += new System.EventHandler(this.选项OToolStripMenuItem_Click);
            // 
            // 自定义CToolStripMenuItem
            // 
            this.自定义CToolStripMenuItem.Name = "自定义CToolStripMenuItem";
            this.自定义CToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.自定义CToolStripMenuItem.Text = "地址管理";
            this.自定义CToolStripMenuItem.Click += new System.EventHandler(this.自定义CToolStripMenuItem_Click);
            // 
            // 历史记录ToolStripMenuItem
            // 
            this.历史记录ToolStripMenuItem.Name = "历史记录ToolStripMenuItem";
            this.历史记录ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.历史记录ToolStripMenuItem.Text = "历史记录";
            this.历史记录ToolStripMenuItem.Click += new System.EventHandler(this.历史记录ToolStripMenuItem_Click);
            // 
            // 帮助
            // 
            this.帮助.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.关于AToolStripMenuItem});
            this.帮助.Name = "帮助";
            this.帮助.Size = new System.Drawing.Size(73, 24);
            this.帮助.Text = "帮助(&H)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(144, 6);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // 新建内核ToolStripMenuItem
            // 
            this.新建内核ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建谷歌内核ToolStripMenuItem,
            this.新建IE内核ToolStripMenuItem,
            this.新建火狐内核ToolStripMenuItem});
            this.新建内核ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建内核ToolStripMenuItem.Image")));
            this.新建内核ToolStripMenuItem.Name = "新建内核ToolStripMenuItem";
            this.新建内核ToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.新建内核ToolStripMenuItem.Text = "内核新建";
            // 
            // 新建谷歌内核ToolStripMenuItem
            // 
            this.新建谷歌内核ToolStripMenuItem.Name = "新建谷歌内核ToolStripMenuItem";
            this.新建谷歌内核ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.新建谷歌内核ToolStripMenuItem.Text = "谷歌内核";
            this.新建谷歌内核ToolStripMenuItem.Click += new System.EventHandler(this.新建谷歌内核ToolStripMenuItem_Click);
            // 
            // 新建IE内核ToolStripMenuItem
            // 
            this.新建IE内核ToolStripMenuItem.Name = "新建IE内核ToolStripMenuItem";
            this.新建IE内核ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.新建IE内核ToolStripMenuItem.Text = "IE内核";
            this.新建IE内核ToolStripMenuItem.Click += new System.EventHandler(this.新建IE内核ToolStripMenuItem_Click);
            // 
            // 新建火狐内核ToolStripMenuItem
            // 
            this.新建火狐内核ToolStripMenuItem.Name = "新建火狐内核ToolStripMenuItem";
            this.新建火狐内核ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.新建火狐内核ToolStripMenuItem.Text = "火狐内核";
            this.新建火狐内核ToolStripMenuItem.Click += new System.EventHandler(this.新建火狐内核ToolStripMenuItem_Click);
            // 
            // txt_url
            // 
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_url.Font = new System.Drawing.Font("华文宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_url.Location = new System.Drawing.Point(115, 8);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(796, 31);
            this.txt_url.TabIndex = 19;
            this.txt_url.TextChanged += new System.EventHandler(this.txt_url_TextChanged);
            this.txt_url.Enter += new System.EventHandler(this.txt_url_Enter);
            this.txt_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyDown);
            this.txt_url.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_url_KeyPress);
            this.txt_url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyUp);
            this.txt_url.Leave += new System.EventHandler(this.txt_url_Leave);
            this.txt_url.MouseEnter += new System.EventHandler(this.txt_url_MouseEnter);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(20, 11);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(50, 11);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(82, 11);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 28;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1358, 750);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "国家电网浏览器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(xtraTabControl1)).EndInit();
            xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private DevExpress.XtraTab.XtraTabPage IE首页;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 收藏夹;
        private System.Windows.Forms.ToolStripMenuItem 工具;
        private System.Windows.Forms.ToolStripMenuItem 自定义CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        public  System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ToolStripMenuItem 新建内核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建谷歌内核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建IE内核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建火狐内核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 主页设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史记录ToolStripMenuItem;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        static public DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    } 
}

