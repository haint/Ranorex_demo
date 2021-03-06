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
    public partial class WarrantyNoRegisWithoutKickstart
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            
            repo.DHSForm.Warranty.Click();
        }
        
        public void RegisterButtonWithoutKickstart ()
        {
        	if (repo.DHSMainWindow.RegisterBtnInfo.Exists(10000))
        	{
        		repo.DHSMainWindow.RegisterBtn.Click();      		
        		if (repo.IE.SelfInfo.Exists(10000))
        		{
        			Report.Success("Registration application show up when installed");
        			Delay.Seconds(10);
        			repo.IE.Self.As<Ranorex.Form>().Close();
        		}else Report.Failure("Registration application is not show up when installed");

        	}else 
        	{
        		Report.Failure("Register button not appear");
        		return;
        	}
        }

    }
}