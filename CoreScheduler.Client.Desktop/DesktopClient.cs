using System;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Forms;

namespace CoreScheduler.Client.Desktop
{
    static class DesktopClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RootForm());


        }
    }
}
