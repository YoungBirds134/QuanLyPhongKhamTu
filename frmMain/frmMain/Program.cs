using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using frmMain.GUI;
namespace frmMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static frmLogin frmDN = null;
        public static frmPolyclinic frmKhamBenh = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            frmDN = new frmLogin();
            Application.Run(frmDN);
            //Application.Run(new frmMain());
        }
    }
}
