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
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using WinForms = System.Windows.Forms;

namespace DHSAutomation.Keywords.Validation
{
	public partial class CheckFindAccessories
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void CheckFindAccessoriesOnMouseHover()
		{
			repo.DHSMainWindow.SelfInfo.WaitForExists(10000);
			// Notify user to start check border
			string msg = "Please observe if Find Accessories icon will be highlight with white rectangle border when mouse hover.\n\n" +
				"To mouse hover on Find Accessories icon, Press OK";
			WinForms.MessageBox.Show(new WinForms.Form{TopMost = true},
			                         msg, "Notification",
			                         WinForms.MessageBoxButtons.OK,
			                         MessageBoxIcon.Information);
			
			// get list of categories
			Text findAccessoriesText = repo.DHSMainWindow.FindAccessories.FindSingle(".");
			findAccessoriesText.MoveTo();
			Delay.Milliseconds(1000);
			
			if(isConfirmManualSteps.Equals("True")){
				msg = "Please observe if Find Accessories icon will be highlight with white rectangle border? (Yes/No)";
				string msgResult = "Check if Find Accessories icon will be highlight with white rectangle border";
				DialogResult result =  WinForms.MessageBox.Show(new WinForms.Form{TopMost = true},
				                                                msg, "Confirm Step",
				                                                WinForms.MessageBoxButtons.YesNo,
				                                                WinForms.MessageBoxIcon.Question,
				                                                WinForms.MessageBoxDefaultButton.Button1);
				Report.Log(result == DialogResult.Yes?ReportLevel.Success:ReportLevel.Failure, msgResult);
			}
		}

	}
}