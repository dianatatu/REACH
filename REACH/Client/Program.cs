using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using REACH.Client.Base;
using REACH.Client.Views;
using REACH.Client.Models;

namespace REACH.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Basic inits */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
			/* Create the entry point of the application */
            ReachWindow mdiForm = new ReachWindow();

            /* Set up the starting context of the application */
			Context.EntryPoint = mdiForm;
            Service.Instance.Start();
            Application.Run(mdiForm);
        }
    }
}
