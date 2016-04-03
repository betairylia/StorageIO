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
    public partial class ServerPage : Form
    {
        public ServerSocketBasement server;

        public ServerPage(string ipAddr)
        {
            InitializeComponent();

            ServerSocketBasement.ipAddr = ipAddr;
            server = new ServerSocketBasement();
            server.page = this;
            server.Start();

            testProcess();
        }

        #region testing

        void testProcess()
        {
            Store store = serverMainHandler.GetSingleton().GetStore();

            Product pro;
            Money cny;
            Random rand = new Random();

            for(int i = 0; i < 10000; i++)
            {
                pro = new Product();
                pro.productType = "变频器";
                pro.productClass = "GD10-" + rand.Next(1000, 8000).ToString();
                pro.setMNo(rand.Next(10000, 100000).ToString());
                cny = new Money(rand.NextDouble() * 50.0);

                store.Import(pro, cny);
            }

            MessageBox.Show("Added 10000 test samples!");
        }

        #endregion

        private void Server_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
