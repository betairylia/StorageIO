using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using StorageIO.Network;
using StorageIO.Network.JSON;

using Newtonsoft.Json.Linq;

namespace StorageIO
{
    public partial class socketTestPage : Form
    {
        public bool isServer = false;
        public ServerSocketBasement server;
        public ClientSocketBasement client;

        ViewStoreProduct tmp2;
        User usr;

        public socketTestPage()
        {
            InitializeComponent();

            if(isServer)
            {
                server = new ServerSocketBasement();
                server.Start();
                connectBtn.Enabled = false;
                requestBtn.Enabled = false;
                requestIDTextBox.Enabled = false;
                requestIDTextBox.Text = "Server mode";

                Product pro = new Product();
                pro.productType = "变频器";
                pro.productClass = "GD10-0R2G-S2-B";
                pro.setMNo("I01161002599");

                Money cny = new Money(10.0);

                User usr = new User();
                usr.userName = "张三";
                usr.userPass = "123123";
                usr.m_userType = userType.USER_SUPERADMIN;

                Store store = serverMainHandler.GetSingleton().GetStore();

                ImportToStore tmp = new ImportToStore();
                tmp.product = pro;
                tmp.cost = cny;
                tmp.user = usr;
                tmp.store = store;

                string req = tmp.GenerateObjectClient();
                string res1 = tmp.GetObjectServer(req);
                string res2 = tmp.GetObjectServer(req);
                string res3 = tmp.GetObjectServer(req);
                string res4 = tmp.GetObjectServer(req);

                MessageBox.Show("Request: \n" + req + "\n\nResponse1:\n" + res1 + "\n\nResponse2:\n" + res2 + "\n\nResponse3:\n" + res3 + "\n\nResponse4:\n" + res4);
            }
            else
            {
                client = new ClientSocketBasement();

                usr = new User();
                usr.userName = "张三";
                usr.userPass = "123123";
                usr.m_userType = userType.USER_SUPERADMIN;

                tmp2 = new ViewStoreProduct();
                tmp2.user = usr;
            }
        }

        #region ignore this please

        private void resLabel_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void connectBtn_Click(object sender, EventArgs e)
        {
            string serverAddr = serverAddrTextBox.Text;//从输入框中获取服务器地址。端口号目前为内置不可更改（12580）@ 2016-3-26 16:25
            Console.WriteLine("address: " + serverAddr);

            if(client.ConnectServer(serverAddr))//成功连接服务器
            {
                serverAddrLabel.Text = serverAddr;
            }
            else
            {
                return;
            }
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            /*string testString = requestIDTextBox.Text;
            Console.WriteLine("request: " + testString);
            
            resLabel.Text = client.SendToServerAndWait(testString);*/
            MessageBox.Show(client.SendToServerAndWait(tmp2.GenerateObjectClient()));
        }
    }
}
