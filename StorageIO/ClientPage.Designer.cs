namespace StorageIO
{
    partial class ClientPage
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
            this.mainTabPanel = new System.Windows.Forms.TabControl();
            this.storeManagementTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnExchange = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.请输入退换货备注 = new System.Windows.Forms.TextBox();
            this.请输入联系方式 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.请输入出库备注 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.请输入进货价格 = new System.Windows.Forms.TextBox();
            this.BtnImport = new System.Windows.Forms.Button();
            this.请输入入库备注 = new System.Windows.Forms.TextBox();
            this.请输入产品机号 = new System.Windows.Forms.TextBox();
            this.请选择产品型号 = new System.Windows.Forms.ComboBox();
            this.请选择产品种类 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productGridView_00 = new System.Windows.Forms.DataGridView();
            this.import = new System.Windows.Forms.TabPage();
            this.export = new System.Windows.Forms.TabPage();
            this.solderTab_sold = new System.Windows.Forms.TabPage();
            this.solderTab_log = new System.Windows.Forms.TabPage();
            this.solderTab_customer = new System.Windows.Forms.TabPage();
            this.adminPage_store = new System.Windows.Forms.TabPage();
            this.adminPage_import = new System.Windows.Forms.TabPage();
            this.adminPage_export = new System.Windows.Forms.TabPage();
            this.adminPage_customer = new System.Windows.Forms.TabPage();
            this.adminPage_sold = new System.Windows.Forms.TabPage();
            this.superadmin_Users = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.labelShowProductType = new System.Windows.Forms.TextBox();
            this.labelShowProductClass = new System.Windows.Forms.TextBox();
            this.labelShowProductCost = new System.Windows.Forms.TextBox();
            this.labelShowProductMNo = new System.Windows.Forms.TextBox();
            this.labelShowImportTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mainTabPanel.SuspendLayout();
            this.storeManagementTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView_00)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabPanel
            // 
            this.mainTabPanel.Controls.Add(this.storeManagementTab);
            this.mainTabPanel.Controls.Add(this.import);
            this.mainTabPanel.Controls.Add(this.export);
            this.mainTabPanel.Controls.Add(this.solderTab_sold);
            this.mainTabPanel.Controls.Add(this.solderTab_log);
            this.mainTabPanel.Controls.Add(this.solderTab_customer);
            this.mainTabPanel.Controls.Add(this.adminPage_store);
            this.mainTabPanel.Controls.Add(this.adminPage_import);
            this.mainTabPanel.Controls.Add(this.adminPage_export);
            this.mainTabPanel.Controls.Add(this.adminPage_customer);
            this.mainTabPanel.Controls.Add(this.adminPage_sold);
            this.mainTabPanel.Controls.Add(this.superadmin_Users);
            this.mainTabPanel.Location = new System.Drawing.Point(12, 12);
            this.mainTabPanel.Name = "mainTabPanel";
            this.mainTabPanel.SelectedIndex = 0;
            this.mainTabPanel.Size = new System.Drawing.Size(984, 705);
            this.mainTabPanel.TabIndex = 0;
            // 
            // storeManagementTab
            // 
            this.storeManagementTab.Controls.Add(this.groupBox4);
            this.storeManagementTab.Controls.Add(this.groupBox3);
            this.storeManagementTab.Controls.Add(this.groupBox2);
            this.storeManagementTab.Controls.Add(this.groupBox1);
            this.storeManagementTab.Location = new System.Drawing.Point(4, 22);
            this.storeManagementTab.Name = "storeManagementTab";
            this.storeManagementTab.Padding = new System.Windows.Forms.Padding(3);
            this.storeManagementTab.Size = new System.Drawing.Size(976, 679);
            this.storeManagementTab.TabIndex = 0;
            this.storeManagementTab.Text = "库存管理";
            this.storeManagementTab.UseVisualStyleBackColor = true;
            this.storeManagementTab.Enter += new System.EventHandler(this.storeManagementTab_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnExchange);
            this.groupBox4.Controls.Add(this.BtnBack);
            this.groupBox4.Controls.Add(this.请输入退换货备注);
            this.groupBox4.Controls.Add(this.请输入联系方式);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(720, 444);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 229);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "退换货";
            // 
            // BtnExchange
            // 
            this.BtnExchange.Location = new System.Drawing.Point(128, 200);
            this.BtnExchange.Name = "BtnExchange";
            this.BtnExchange.Size = new System.Drawing.Size(116, 23);
            this.BtnExchange.TabIndex = 8;
            this.BtnExchange.Text = "换货";
            this.BtnExchange.UseVisualStyleBackColor = true;
            this.BtnExchange.Click += new System.EventHandler(this.BtnExchange_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(6, 200);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(116, 23);
            this.BtnBack.TabIndex = 7;
            this.BtnBack.Text = "退货";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // 请输入退换货备注
            // 
            this.请输入退换货备注.Location = new System.Drawing.Point(6, 103);
            this.请输入退换货备注.Multiline = true;
            this.请输入退换货备注.Name = "请输入退换货备注";
            this.请输入退换货备注.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.请输入退换货备注.Size = new System.Drawing.Size(238, 91);
            this.请输入退换货备注.TabIndex = 6;
            this.请输入退换货备注.Text = "请输入退换货备注";
            // 
            // 请输入联系方式
            // 
            this.请输入联系方式.Location = new System.Drawing.Point(6, 76);
            this.请输入联系方式.Name = "请输入联系方式";
            this.请输入联系方式.Size = new System.Drawing.Size(238, 21);
            this.请输入联系方式.TabIndex = 5;
            this.请输入联系方式.Text = "请输入联系方式";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "换货流程：填写信息，确认后入库并出库";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "退货流程：填写信息，确认后入库";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(245, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "系统会自动在出入库记录备注栏中添加信息。";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.labelShowImportTime);
            this.groupBox3.Controls.Add(this.labelShowProductMNo);
            this.groupBox3.Controls.Add(this.labelShowProductCost);
            this.groupBox3.Controls.Add(this.labelShowProductClass);
            this.groupBox3.Controls.Add(this.labelShowProductType);
            this.groupBox3.Controls.Add(this.BtnExport);
            this.groupBox3.Controls.Add(this.请输入出库备注);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(720, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 209);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出库";
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(8, 180);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(237, 23);
            this.BtnExport.TabIndex = 6;
            this.BtnExport.Text = "确定出库（请仔细核对信息！）";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // 请输入出库备注
            // 
            this.请输入出库备注.Location = new System.Drawing.Point(7, 101);
            this.请输入出库备注.Multiline = true;
            this.请输入出库备注.Name = "请输入出库备注";
            this.请输入出库备注.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.请输入出库备注.Size = new System.Drawing.Size(237, 73);
            this.请输入出库备注.TabIndex = 6;
            this.请输入出库备注.Text = "请输入出库备注";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请在左侧表格中选择。所选择的产品信息：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.请输入进货价格);
            this.groupBox2.Controls.Add(this.BtnImport);
            this.groupBox2.Controls.Add(this.请输入入库备注);
            this.groupBox2.Controls.Add(this.请输入产品机号);
            this.groupBox2.Controls.Add(this.请选择产品型号);
            this.groupBox2.Controls.Add(this.请选择产品种类);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(720, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(250, 217);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入库";
            // 
            // 请输入进货价格
            // 
            this.请输入进货价格.Location = new System.Drawing.Point(7, 101);
            this.请输入进货价格.Name = "请输入进货价格";
            this.请输入进货价格.Size = new System.Drawing.Size(215, 21);
            this.请输入进货价格.TabIndex = 5;
            this.请输入进货价格.Text = "请输入进货价格";
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(7, 188);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(237, 23);
            this.BtnImport.TabIndex = 4;
            this.BtnImport.Text = "确定入库（请仔细核对信息！）";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // 请输入入库备注
            // 
            this.请输入入库备注.Location = new System.Drawing.Point(7, 128);
            this.请输入入库备注.Multiline = true;
            this.请输入入库备注.Name = "请输入入库备注";
            this.请输入入库备注.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.请输入入库备注.Size = new System.Drawing.Size(237, 54);
            this.请输入入库备注.TabIndex = 3;
            this.请输入入库备注.Text = "请输入入库备注";
            this.请输入入库备注.Enter += new System.EventHandler(this.TextBoxWithToolTip_Enter);
            this.请输入入库备注.Leave += new System.EventHandler(this.TextBoxWithToolTip_Leave);
            // 
            // 请输入产品机号
            // 
            this.请输入产品机号.Location = new System.Drawing.Point(7, 74);
            this.请输入产品机号.Name = "请输入产品机号";
            this.请输入产品机号.Size = new System.Drawing.Size(237, 21);
            this.请输入产品机号.TabIndex = 2;
            this.请输入产品机号.Text = "请输入产品机号";
            // 
            // 请选择产品型号
            // 
            this.请选择产品型号.FormattingEnabled = true;
            this.请选择产品型号.Location = new System.Drawing.Point(7, 47);
            this.请选择产品型号.Name = "请选择产品型号";
            this.请选择产品型号.Size = new System.Drawing.Size(237, 20);
            this.请选择产品型号.TabIndex = 1;
            this.请选择产品型号.Text = "请选择产品型号";
            // 
            // 请选择产品种类
            // 
            this.请选择产品种类.FormattingEnabled = true;
            this.请选择产品种类.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e"});
            this.请选择产品种类.Location = new System.Drawing.Point(6, 20);
            this.请选择产品种类.Name = "请选择产品种类";
            this.请选择产品种类.Size = new System.Drawing.Size(238, 20);
            this.请选择产品种类.TabIndex = 0;
            this.请选择产品种类.Text = "请选择产品种类";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.productGridView_00);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 667);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存清单";
            // 
            // productGridView_00
            // 
            this.productGridView_00.AllowUserToAddRows = false;
            this.productGridView_00.AllowUserToDeleteRows = false;
            this.productGridView_00.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView_00.Location = new System.Drawing.Point(6, 20);
            this.productGridView_00.MultiSelect = false;
            this.productGridView_00.Name = "productGridView_00";
            this.productGridView_00.RowTemplate.Height = 23;
            this.productGridView_00.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productGridView_00.Size = new System.Drawing.Size(696, 641);
            this.productGridView_00.TabIndex = 0;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(4, 22);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(976, 679);
            this.import.TabIndex = 5;
            this.import.Text = "入库记录";
            this.import.UseVisualStyleBackColor = true;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(4, 22);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(976, 679);
            this.export.TabIndex = 6;
            this.export.Text = "出库记录";
            this.export.UseVisualStyleBackColor = true;
            // 
            // solderTab_sold
            // 
            this.solderTab_sold.Location = new System.Drawing.Point(4, 22);
            this.solderTab_sold.Name = "solderTab_sold";
            this.solderTab_sold.Padding = new System.Windows.Forms.Padding(3);
            this.solderTab_sold.Size = new System.Drawing.Size(976, 679);
            this.solderTab_sold.TabIndex = 1;
            this.solderTab_sold.Text = "销售管理";
            this.solderTab_sold.UseVisualStyleBackColor = true;
            // 
            // solderTab_log
            // 
            this.solderTab_log.Location = new System.Drawing.Point(4, 22);
            this.solderTab_log.Name = "solderTab_log";
            this.solderTab_log.Size = new System.Drawing.Size(976, 679);
            this.solderTab_log.TabIndex = 7;
            this.solderTab_log.Text = "销售记录";
            this.solderTab_log.UseVisualStyleBackColor = true;
            // 
            // solderTab_customer
            // 
            this.solderTab_customer.Location = new System.Drawing.Point(4, 22);
            this.solderTab_customer.Name = "solderTab_customer";
            this.solderTab_customer.Size = new System.Drawing.Size(976, 679);
            this.solderTab_customer.TabIndex = 3;
            this.solderTab_customer.Text = "客户信息";
            this.solderTab_customer.UseVisualStyleBackColor = true;
            // 
            // adminPage_store
            // 
            this.adminPage_store.Location = new System.Drawing.Point(4, 22);
            this.adminPage_store.Name = "adminPage_store";
            this.adminPage_store.Size = new System.Drawing.Size(976, 679);
            this.adminPage_store.TabIndex = 2;
            this.adminPage_store.Text = "库存产品管理";
            this.adminPage_store.UseVisualStyleBackColor = true;
            // 
            // adminPage_import
            // 
            this.adminPage_import.Location = new System.Drawing.Point(4, 22);
            this.adminPage_import.Name = "adminPage_import";
            this.adminPage_import.Size = new System.Drawing.Size(976, 679);
            this.adminPage_import.TabIndex = 4;
            this.adminPage_import.Text = "入库信息管理";
            this.adminPage_import.UseVisualStyleBackColor = true;
            // 
            // adminPage_export
            // 
            this.adminPage_export.Location = new System.Drawing.Point(4, 22);
            this.adminPage_export.Name = "adminPage_export";
            this.adminPage_export.Size = new System.Drawing.Size(976, 679);
            this.adminPage_export.TabIndex = 8;
            this.adminPage_export.Text = "出库信息管理";
            this.adminPage_export.UseVisualStyleBackColor = true;
            // 
            // adminPage_customer
            // 
            this.adminPage_customer.Location = new System.Drawing.Point(4, 22);
            this.adminPage_customer.Name = "adminPage_customer";
            this.adminPage_customer.Size = new System.Drawing.Size(976, 679);
            this.adminPage_customer.TabIndex = 9;
            this.adminPage_customer.Text = "客户信息管理";
            this.adminPage_customer.UseVisualStyleBackColor = true;
            // 
            // adminPage_sold
            // 
            this.adminPage_sold.Location = new System.Drawing.Point(4, 22);
            this.adminPage_sold.Name = "adminPage_sold";
            this.adminPage_sold.Size = new System.Drawing.Size(976, 679);
            this.adminPage_sold.TabIndex = 10;
            this.adminPage_sold.Text = "销售记录管理";
            this.adminPage_sold.UseVisualStyleBackColor = true;
            // 
            // superadmin_Users
            // 
            this.superadmin_Users.Location = new System.Drawing.Point(4, 22);
            this.superadmin_Users.Name = "superadmin_Users";
            this.superadmin_Users.Size = new System.Drawing.Size(976, 679);
            this.superadmin_Users.TabIndex = 11;
            this.superadmin_Users.Text = "账户管理";
            this.superadmin_Users.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "元";
            // 
            // labelShowProductType
            // 
            this.labelShowProductType.BackColor = System.Drawing.SystemColors.Window;
            this.labelShowProductType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelShowProductType.Location = new System.Drawing.Point(8, 39);
            this.labelShowProductType.Name = "labelShowProductType";
            this.labelShowProductType.ReadOnly = true;
            this.labelShowProductType.Size = new System.Drawing.Size(100, 14);
            this.labelShowProductType.TabIndex = 7;
            this.labelShowProductType.Text = "<产品类型>";
            // 
            // labelShowProductClass
            // 
            this.labelShowProductClass.BackColor = System.Drawing.SystemColors.Window;
            this.labelShowProductClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelShowProductClass.Location = new System.Drawing.Point(114, 39);
            this.labelShowProductClass.Name = "labelShowProductClass";
            this.labelShowProductClass.ReadOnly = true;
            this.labelShowProductClass.Size = new System.Drawing.Size(125, 14);
            this.labelShowProductClass.TabIndex = 8;
            this.labelShowProductClass.Text = "<产品型号>";
            this.labelShowProductClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelShowProductCost
            // 
            this.labelShowProductCost.BackColor = System.Drawing.SystemColors.Window;
            this.labelShowProductCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelShowProductCost.Location = new System.Drawing.Point(8, 60);
            this.labelShowProductCost.Name = "labelShowProductCost";
            this.labelShowProductCost.ReadOnly = true;
            this.labelShowProductCost.Size = new System.Drawing.Size(100, 14);
            this.labelShowProductCost.TabIndex = 9;
            this.labelShowProductCost.Text = "<进货价格>";
            // 
            // labelShowProductMNo
            // 
            this.labelShowProductMNo.BackColor = System.Drawing.SystemColors.Window;
            this.labelShowProductMNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelShowProductMNo.Location = new System.Drawing.Point(114, 59);
            this.labelShowProductMNo.Name = "labelShowProductMNo";
            this.labelShowProductMNo.ReadOnly = true;
            this.labelShowProductMNo.Size = new System.Drawing.Size(125, 14);
            this.labelShowProductMNo.TabIndex = 10;
            this.labelShowProductMNo.Text = "<产品机号>";
            this.labelShowProductMNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelShowImportTime
            // 
            this.labelShowImportTime.BackColor = System.Drawing.SystemColors.Window;
            this.labelShowImportTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelShowImportTime.Location = new System.Drawing.Point(8, 81);
            this.labelShowImportTime.Name = "labelShowImportTime";
            this.labelShowImportTime.ReadOnly = true;
            this.labelShowImportTime.Size = new System.Drawing.Size(136, 14);
            this.labelShowImportTime.TabIndex = 11;
            this.labelShowImportTime.Text = "<入库时间>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "可以选中并复制";
            // 
            // ClientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mainTabPanel);
            this.Name = "ClientPage";
            this.Text = "进销存管理系统";
            this.mainTabPanel.ResumeLayout(false);
            this.storeManagementTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productGridView_00)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabPanel;
        private System.Windows.Forms.TabPage storeManagementTab;
        private System.Windows.Forms.TabPage solderTab_sold;
        private System.Windows.Forms.TabPage adminPage_store;
        private System.Windows.Forms.TabPage solderTab_customer;
        private System.Windows.Forms.TabPage import;
        private System.Windows.Forms.TabPage export;
        private System.Windows.Forms.TabPage solderTab_log;
        private System.Windows.Forms.TabPage adminPage_import;
        private System.Windows.Forms.TabPage adminPage_export;
        private System.Windows.Forms.TabPage adminPage_customer;
        private System.Windows.Forms.TabPage adminPage_sold;
        private System.Windows.Forms.TabPage superadmin_Users;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox 请输入进货价格;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.TextBox 请输入入库备注;
        private System.Windows.Forms.TextBox 请输入产品机号;
        private System.Windows.Forms.ComboBox 请选择产品型号;
        private System.Windows.Forms.ComboBox 请选择产品种类;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView productGridView_00;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.TextBox 请输入退换货备注;
        private System.Windows.Forms.TextBox 请输入联系方式;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.TextBox 请输入出库备注;
        private System.Windows.Forms.Button BtnExchange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox labelShowProductType;
        private System.Windows.Forms.TextBox labelShowProductMNo;
        private System.Windows.Forms.TextBox labelShowProductCost;
        private System.Windows.Forms.TextBox labelShowProductClass;
        private System.Windows.Forms.TextBox labelShowImportTime;
        private System.Windows.Forms.Label label3;
    }
}