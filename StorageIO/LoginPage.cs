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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();

            //debug
            ipAddrTextBox.Text = "127.0.0.1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Program.isServer)
            {
                //检查用户信息

                ServerPage serverForm = new ServerPage(ipAddrTextBox.Text);
                serverForm.Show();

                serverForm.FormClosed += FormClosed;

                this.Hide();
            }
            else
            {
                //检查用户信息

                ClientPage clientForm = new ClientPage(ipAddrTextBox.Text);
                clientForm.Show();

                clientForm.FormClosed += FormClosed;

                this.Hide();
            }
        }

        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
