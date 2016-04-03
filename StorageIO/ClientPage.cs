using StorageIO.ClientTables;
using StorageIO.Network;
using StorageIO.Network.JSON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StorageIO
{
    public partial class ClientPage : Form
    {
        User m_user;
        ClientSocketBasement client;
        public string ipAddr;

        public ClientPage( string _ipAddr )
        {
            ipAddr = _ipAddr;
            //DisableTabTest();
            CreateUserTest();

            InitializeComponent();
            RegisterTextBoxWithToolTip(this.Controls);
            this.Shown += ClientPage_Shown;
        }

        #region ToolTips

        private void RegisterTextBoxWithToolTip(Control.ControlCollection ctc)
        {
            foreach (Control con in ctc)
            {
                if (!con.HasChildren)
                {
                    if (con.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        if ((con as TextBox).BorderStyle == BorderStyle.None) continue;

                        (con as TextBox).Enter += TextBoxWithToolTip_Enter;
                        (con as TextBox).Leave += TextBoxWithToolTip_Leave;
                        (con as TextBox).Text = (con as TextBox).Name;
                        continue;
                    }
                }
                RegisterTextBoxWithToolTip(con.Controls);
            }
        }

        private void TextBoxWithToolTip_Enter(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text == ((TextBox)sender).Name)
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void TextBoxWithToolTip_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = ((TextBox)sender).Name;
            }
        }

        #endregion

        private void ClientPage_Shown(object sender, EventArgs e)
        {
            
        }

        private void CreateUserTest()
        {
            client = new ClientSocketBasement();
            if(client.ConnectServer(ipAddr))
            {
                Console.WriteLine("Server connected!");
            }

            m_user = new User();
            m_user.userName = "test";
            m_user.userPass = "test";
            m_user.m_userType = userType.USER_SUPERADMIN;
        }

        /// <summary>
        /// 标签页隐藏测试
        /// </summary>
        void DisableTabTest()
        {
            //对应于超级管理员的权限
            //每移除一个标签页，后面的标签页就会“塞”进原来的位置，所以这里是0, 0, 0, 1, 1.
            mainTabPanel.TabPages.Remove(mainTabPanel.TabPages[0]);
            mainTabPanel.TabPages.Remove(mainTabPanel.TabPages[0]);
            mainTabPanel.TabPages.Remove(mainTabPanel.TabPages[0]);
            mainTabPanel.TabPages.Remove(mainTabPanel.TabPages[1]);
            mainTabPanel.TabPages.Remove(mainTabPanel.TabPages[1]);
        }

        #region “库存管理”页 —— storeManagementTab(00)

        bool storeManagementTab_Entered = false;

        ProductView storeManagementTab_productView;
        TableView storeManagementTab_tableView;
        ViewStoreProduct storeManagementTab_viewStoreProduct;
        ViewStoreReturns storeManagementTab_viewStoreReturns;
        ProductStorage storeManagementTab_selectedProductStorage;

        bool storeManagementTab_onBack = false, storeManagementTab_onChange = false;

        //进入时
        private void storeManagementTab_Enter(object sender, EventArgs e)
        {
            if (!storeManagementTab_Entered)
            {
                #region 初始化库存清单

                //创建ProductView
                storeManagementTab_productView = new ProductView();

                //创建tableView并绑定
                storeManagementTab_tableView = new TableView();
                storeManagementTab_tableView.gridView = productGridView_00;
                storeManagementTab_tableView.controller = storeManagementTab_productView;

                //创建ViewStoreProduct（JsonSocketModule）
                storeManagementTab_viewStoreProduct = new ViewStoreProduct();
                storeManagementTab_viewStoreProduct.user = m_user;

                //初始化tableView
                storeManagementTab_tableView.init();

                //给这个tableView绑定事件
                storeManagementTab_tableView.RowSelected += StoreManagementTab_tableView_RowSelected;

                #endregion
            }
            storeManagementTab_Entered = true;

            StoreManagementTab_GetStoreDataFromServer();
        }

        //从服务器读取库存清单并刷新显示
        private void StoreManagementTab_GetStoreDataFromServer()
        {
            //向服务器发送请求并接收请求
            storeManagementTab_viewStoreReturns = JsonHelper.DeserializeJsonToObject<ViewStoreReturns>(
                client.SendToServerAndWait(storeManagementTab_viewStoreProduct.GenerateObjectClient()));

            //给productView赋值
            storeManagementTab_productView.products = storeManagementTab_viewStoreReturns.products;

            //呈现视图
            storeManagementTab_tableView.flushAll();
        }

        //选中了一行
        private void StoreManagementTab_tableView_RowSelected(object sender, IRowShowable selected)
        {
            storeManagementTab_selectedProductStorage = (ProductStorage)selected;

            labelShowProductType.Text    = storeManagementTab_selectedProductStorage.m_product.productType;
            labelShowProductClass.Text   = storeManagementTab_selectedProductStorage.m_product.productClass;
            labelShowProductMNo.Text     = storeManagementTab_selectedProductStorage.m_product.MNo;
            labelShowProductCost.Text    = storeManagementTab_selectedProductStorage.importCost.ToString();
            labelShowImportTime.Text     = storeManagementTab_selectedProductStorage.importTime.ToString();
        }

        //入库
        private void BtnImport_Click(object sender, EventArgs e)
        {
            ImportToStore importToStore = new ImportToStore();
            importToStore.user = m_user;

            if (storeManagementTab_onBack)
            {
                //追加退换货信息
                importToStore.comments = "（退换货 - 联系方式：" + 请输入联系方式.Text + "）[ " + 请输入退换货备注.Text + " ] ";
                storeManagementTab_onBack = false;

                if(!(storeManagementTab_onBack || storeManagementTab_onChange))
                {
                    BtnBack.Enabled = true;
                    BtnExchange.Enabled = true;
                }

                _UpdateColor00();
            }
            else
            {
                importToStore.comments = "";
            }

            Product tmpProductForImport = new Product();
            tmpProductForImport.productType = 请选择产品种类.Text;
            tmpProductForImport.productClass = 请选择产品型号.Text;
            tmpProductForImport.hasMNo = ProductTypeClassManager.CheckIfHasMNo(请选择产品种类.Text);
            tmpProductForImport.MNo = 请输入产品机号.Text;

            if (请输入入库备注.Text != "请输入入库备注")
            {
                importToStore.comments += 请输入入库备注.Text;
            }

            importToStore.product = tmpProductForImport;
            importToStore.cost = new Money(double.Parse(请输入进货价格.Text));
            
            //向服务器发送入库请求
            ServerResponseWithoutBody simpleRes = JsonHelper.DeserializeJsonToObject<ServerResponseWithoutBody>(
                client.SendToServerAndWait(JsonHelper.SerializeObject(importToStore)));

            if(ToolBox.CheckServerResponse(simpleRes))
            {
                StoreManagementTab_GetStoreDataFromServer();
            }
        }

        //出库
        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExportFromStore exportFromStore = new ExportFromStore();

            if (storeManagementTab_onChange)
            {
                //追加退换货信息
                exportFromStore.comments = "（退换货 - 联系方式：" + 请输入联系方式.Text + "）[ " + 请输入退换货备注.Text + " ] ";
                storeManagementTab_onChange = false;

                if (!(storeManagementTab_onBack || storeManagementTab_onChange))
                {
                    BtnBack.Enabled = true;
                    BtnExchange.Enabled = true;
                }

                _UpdateColor00();
            }
            else
            {
                exportFromStore.comments = "";
            }

            if(请输入出库备注.Text != "请输入出库备注"){ exportFromStore.comments += 请输入出库备注.Text; }
            exportFromStore.user = m_user;
            exportFromStore.product = storeManagementTab_selectedProductStorage;

            //向服务器发送出库请求
            ServerResponseWithoutBody simpleRes = JsonHelper.DeserializeJsonToObject<ServerResponseWithoutBody>(
                client.SendToServerAndWait(JsonHelper.SerializeObject(exportFromStore)));

            if (ToolBox.CheckServerResponse(simpleRes))
            {
                StoreManagementTab_GetStoreDataFromServer();
            }
        }

        //退货
        private void BtnBack_Click(object sender, EventArgs e)
        {
            storeManagementTab_onBack = true;

            BtnBack.Enabled = false;
            BtnExchange.Enabled = false;

            _UpdateColor00();
        }

        //换货
        private void BtnExchange_Click(object sender, EventArgs e)
        {
            storeManagementTab_onBack = true;
            storeManagementTab_onChange = true;

            BtnBack.Enabled = false;
            BtnExchange.Enabled = false;

            _UpdateColor00();
        }

        //根据退换货流程更改出入库背景颜色
        private void _UpdateColor00()
        {
            if (storeManagementTab_onBack)
            {
                groupBox2.BackColor = Color.CornflowerBlue;
            }
            else
            {
                groupBox2.BackColor = Color.Transparent;
            }

            if (storeManagementTab_onChange)
            {
                groupBox3.BackColor = Color.CornflowerBlue;
            }
            else
            {
                groupBox3.BackColor = Color.Transparent;
            }
        }

        #endregion


    }
}
