using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosApplication.Interfaces;
using DataAccessLayer;
using Unity;

namespace POSApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = DependencyInjector.Register();
            Application.Run(container.Resolve<Forms.FrmLogin>());
        }       
    }
}
