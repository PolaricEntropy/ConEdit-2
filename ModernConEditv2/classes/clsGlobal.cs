using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernConEditv2.classes
{
    public sealed class clsGlobal
    {
        public static frmMDIMain g_objfrmMDIMain;
        //this is to declare a global static reference to our MDI parent so that the same 
        //instance is referred across all child with no extra line of code
    }
}
