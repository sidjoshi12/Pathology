using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pathology
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Engine.initConn();

            //frmLogin login = new frmLogin();
            //if (login.ShowDialog() == DialogResult.OK)
            //{
                Application.Run(new frmMain(args));
            //    login.Dispose();
            //}
        }
    }
}
