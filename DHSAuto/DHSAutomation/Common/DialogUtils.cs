using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;

namespace DHSAutomation.Common
{

    public class DialogUtils 
    {

        public DialogUtils()
        {

        }
        
        public static DialogResult DialogConfirm (string question)
        {
        	DialogResult rs = MessageBox.Show(new WinForms.Form {TopMost = true},question,"Confirm",MessageBoxButtons.YesNo);
        	return rs;
        }

    }
}
