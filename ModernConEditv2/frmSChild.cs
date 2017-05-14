using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernConEditv2
{
    public partial class frmSChild : Form
    {
        public frmSChild()
        {
            InitializeComponent();
        }

        private static frmSChild m_SChildform;
        public static frmSChild GetChildInstance()
        {
            if (m_SChildform == null) //if not created yet, Create an instance
                m_SChildform = new frmSChild();
            return m_SChildform;  //just created or created earlier.Return it
        }

        //This is to make sure that when we Click on a 'New Single' menu on Parent form twice 
        //it should not open two instance of the same child form
    }
}
