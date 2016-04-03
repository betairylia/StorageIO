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

            #region 从服务器读取库存清单并刷新显示

            //向服务器发送请求并接收请求
            storeManagementTab_viewStoreReturns = JsonHelper.DeserializeJsonToObject<ViewStoreReturns>(
                client.SendToServerAndWait(storeManagementTab_viewStoreProduct.GenerateObjectClient()));

            //给productView赋值
            storeManagementTab_productView.products = storeManagementTab_viewStoreReturns.products;

            //呈现视图
            storeManagementTab_tableView.flushAll();

            #endregion
        }

        //选中了一行
        private void StoreManagementTab_tableView_RowSelected(object sender, IRowShowable selected)
        {
            ProductStorage product = (ProductStorage)selected;

            labelShowProductType.Text    = product.m_product.productType;
            labelShowProductClass.Text   = product.m_product.productClass;
            labelShowProductMNo.Text     = product.m_product.MNo;
            labelShowProductCost.Text    = product.importCost.ToString();
            labelShowImportTime.Text     = product.importTime.ToString();
        }

        #endregion
    }
}
