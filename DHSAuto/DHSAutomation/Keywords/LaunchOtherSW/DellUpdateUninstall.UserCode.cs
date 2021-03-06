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
using System.Diagnostics;
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
    public partial class DellUpdateUninstall
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }
        
        public void Uninstall()
        {
        	Process.Start("appwiz.cpl");
        	
        	if (repo.ControlPanel.ProgramsAndFeatures.DellUpdateInfo.Exists())
        	{
        		repo.ControlPanel.ProgramsAndFeatures.DellUpdate.DoubleClick();
        		if (repo.Explorer.ButtonYesInfo.Exists(10000))
        		{
        			if (repo.Explorer.ButtonYesInfo.Exists(10000)) repo.Explorer.ButtonYes.Click();
	        		Delay.Seconds(5);
	        		repo.Explorer.ButtonOK.Click();
	        		if (repo.Explorer.ButtonOKInfo.Exists(20000)) repo.Explorer.ButtonOK.Click();
	        		Delay.Seconds(90);
	        		repo.ControlPanel.ProgramsAndFeatures.Close.Click();
	        		Delay.Seconds(2);
        		}
        		
        		if (repo.DellUpdate17Setup.SelfInfo.Exists())
        		{
        			repo.DellUpdate17Setup.ButtonUninstall.Click();
        			Delay.Seconds(90);
        			repo.DellUpdate17Setup.ButtonClose.Click();
        			repo.ControlPanel.ProgramsAndFeatures.Close.Click();
        			Delay.Seconds(2);
        		}
        		
        	}else return;
        	

        	
        	
        }

    }
}