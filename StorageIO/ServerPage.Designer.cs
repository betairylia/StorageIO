namespace StorageIO
{
    partial class ServerPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerPage));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看本机IPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置开机自启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存服务器数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存并关闭服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.还原ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器已经在运行，点击最小化即可隐藏图标";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务器ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(269, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 服务器ToolStripMenuItem
            // 
            this.服务器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看本机IPToolStripMenuItem,
            this.设置开机自启动ToolStripMenuItem,
            this.保存服务器数据ToolStripMenuItem,
            this.保存并关闭服务器ToolStripMenuItem});
            this.服务器ToolStripMenuItem.Name = "服务器ToolStripMenuItem";
            this.服务器ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.服务器ToolStripMenuItem.Text = "通用";
            // 
            // 查看本机IPToolStripMenuItem
            // 
            this.查看本机IPToolStripMenuItem.Name = "查看本机IPToolStripMenuItem";
            this.查看本机IPToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查看本机IPToolStripMenuItem.Text = "查看本机IP";
            // 
            // 设置开机自启动ToolStripMenuItem
            // 
            this.设置开机自启动ToolStripMenuItem.Name = "设置开机自启动ToolStripMenuItem";
            this.设置开机自启动ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.设置开机自启动ToolStripMenuItem.Text = "设置开机自启动";
            // 
            // 保存服务器数据ToolStripMenuItem
            // 
            this.保存服务器数据ToolStripMenuItem.Name = "保存服务器数据ToolStripMenuItem";
            this.保存服务器数据ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.保存服务器数据ToolStripMenuItem.Text = "保存服务器数据";
            // 
            // 保存并关闭服务器ToolStripMenuItem
            // 
            this.保存并关闭服务器ToolStripMenuItem.Name = "保存并关闭服务器ToolStripMenuItem";
            this.保存并关闭服务器ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.保存并关闭服务器ToolStripMenuItem.Text = "保存并关闭服务器";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 173);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器运行状况";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "进出货管理系统 - 服务器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.还原ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 还原ToolStripMenuItem
            // 
            this.还原ToolStripMenuItem.Name = "还原ToolStripMenuItem";
            this.还原ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.还原ToolStripMenuItem.Text = "还原";
            this.还原ToolStripMenuItem.Click += new System.EventHandler(this.还原ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "双击托盘图标即可还原此界面";
            // 
            // ServerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 276);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerPage";
            this.Text = "进销存管理系统 - 服务器";
            this.Resize += new System.EventHandler(this.Server_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看本机IPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置开机自启动ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 还原ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存服务器数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存并关闭服务器ToolStripMenuItem;
    }
}