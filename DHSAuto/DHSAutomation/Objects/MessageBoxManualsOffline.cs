/*
 * Created by Ranorex
 * User: DHS
 * Date: 8/27/2016
 * Time: 9:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;

using DHSAutomation.Common;
using DHSAutomation.Objects;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Objects
{
	/// <summary>
	/// Description of MessageBoxManualsOffline.
	/// </summary>
	public class MessageBoxManualsOffline
	{
		public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

		public MessageBoxManualsOffline()
		{
		}
		
		public static void WaitForExist(){
			repo.OfflineMessageWindow.SelfInfo.WaitForExists(new Duration(3000));
			if(repo.OfflineMessageWindow.HmmmInfo.Exists()){
				string text = repo.OfflineMessageWindow.ErrorInfo.TextValue;
				if(text == "Looks like you're offline. Would you like to learn how to get online?"){
					Report.Log(ReportLevel.Success, "Offline Message is shown as expected");
				}
				else{
					Report.Log(ReportLevel.Failure, "Offline Message is NOT shown as expected");
				}
			}
		}
		
		public static void ClickNotNow(){
			// click Not now
			repo.OfflineMessageWindow.NotNow.Click();
			Delay.Milliseconds(1000);
		}
		
		public static void ClickGetOnline(){
			repo.OfflineMessageWindow.GetOnline.Click();
			Delay.Milliseconds(1000);
		}
	}
}
