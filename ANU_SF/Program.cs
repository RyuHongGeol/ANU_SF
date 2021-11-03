using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANU_SF
{
    static class Program
    {
        static frmLogin login = null;
        internal static bool logOK = false;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());

            #region
            login = new frmLogin();
            Application.Run(login);

            if (logOK)
            {
                frmMain m = new frmMain();
                //login.Close();
                Application.Run(m);
            }
            #endregion
        }
    }
}
