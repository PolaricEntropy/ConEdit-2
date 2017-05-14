using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernConEditv2.classes
{
    class clsMain
    {
        [STAThread]
        static void Main()
        {
            try
            {
                frmSplash objfrmSplash = new frmSplash();
                objfrmSplash.ShowDialog();
                clsGlobal.g_objfrmMDIMain = new frmMDIMain();
                Application.Run(clsGlobal.g_objfrmMDIMain);
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "My Best MDI",
                 MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //This is the Single Threaded Apartment Model(out of our scope)
        //of the application which will run the Main function
        //when the application starts
    }
}
