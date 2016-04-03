using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StorageIO
{
    static class Program
    {
        public static bool isServer = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(isServer)
            {
                Application.Run(new LoginPage());
            }
            else
            {
                Application.Run(new LoginPage());
            }

            Application.Exit();
        }
    }
}
