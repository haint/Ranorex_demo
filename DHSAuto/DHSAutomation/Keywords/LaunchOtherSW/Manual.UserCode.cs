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
    public partial class Manual
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
            
            repo.DHSForm.Manuals.Click();
            Delay.Seconds(4);
        }
        
        public void CheckGuide ()
        {
        	if (repo.DHSForm.QUICKSTARTGUIDEInfo.Exists()) 
        	{
        		repo.DHSForm.QUICKSTARTGUIDE.Click();
        		Delay.Seconds(5);
        		
        		if (repo.MicrosoftEdge.SelfInfo.Exists())
        		{
        			Report.Success("Quick start guilde success");
        			Delay.Seconds(5);
        			repo.MicrosoftEdge.Self.As<Ranorex.Form>().Close();
        		}else Report.Failure("Quick start guilde success failure");
        		
        		Delay.Seconds(5);
        		
        		repo.DHSForm.LinkContent.Click();
        		
        		Delay.Seconds(5);
        		
        		if (repo.IE.SelfInfo.Exists())
        		{
        			Report.Success("Manual link success");
        			Delay.Seconds(5);
        			repo.IE.Self.As<Ranorex.Form>().Close();
        			
        		}else Report.Failure("Manual link failure");
        		
        	}
        }

    }
}