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

namespace StorageIO
{
    public partial class socketTestPage : Form
    {
        public bool isServer = true;
        public ServerSocketBasement server;
        public ClientSocketBasement client;

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
            }
            else
            {
                client = new ClientSocketBasement();
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
            string testString = requestIDTextBox.Text;
            Console.WriteLine("request: " + testString);
            
            resLabel.Text = client.SendToServerAndWait(testString);
        }
    }
}
