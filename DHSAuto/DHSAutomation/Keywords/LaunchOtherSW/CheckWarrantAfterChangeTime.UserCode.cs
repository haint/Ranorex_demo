﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
// http://www.ranorex.com
// 
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.LaunchOtherSW
{
    public partial class CheckWarrantAfterChangeTime
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            repo.DHSForm.Warranty.Click();
        }
        
        public void CheckWarrantText ()
        {
        	Report.Info(repo.DHSForm.WarrantyDate.Caption);
        	Delay.Seconds(3);
        	if (repo.DHSForm.WarrantyDate.Caption.ToLower().Contains(textValue)) Report.Success("Text warrant displayed correctly");
        	else Report.Failure("Text warrant not displayed correctly");
        }
    }
}