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
    public partial class SupportAssitInstalled
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
            repo.DHSForm.SupportAssist.Click();
            Delay.Seconds(5);
        }
        
        public void LaunchSupport ()
        {
        	repo.DHSForm.Launch.Click();
        	Delay.Seconds(5);
        	
        	if (repo.SupportAssit.SelfInfo.Exists()) 
        	{
        		Delay.Seconds(3);
        		repo.SupportAssit.Self.As<Ranorex.Form>().Close();
        		Report.Success("Support Assit launch successfully");
        	}
        	else Report.Failure("Support Assit launch failure");
        	
        	
        }

    }
}