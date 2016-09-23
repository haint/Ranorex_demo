/*
 * Created by Ranorex
 * User: DHS
 * Date: 9/8/2016
 * Time: 4:47 AM
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
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.General
{
	/// <summary>
	/// Description of SetRepoVariables.
	/// </summary>
	[TestModule("3D8D9FB1-1CA6-45E5-9636-7F4DEA384E82", ModuleType.UserCode, 1)]
	public class SetRepoVariables : ITestModule
	{
		public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public SetRepoVariables()
		{
			// Do not delete - a parameterless constructor is required!
		}

		/// <summary>
		/// Performs the playback of actions in this module.
		/// </summary>
		/// <remarks>You should not call this method directly, instead pass the module
		/// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
		/// that will in turn invoke this method.</remarks>
		void ITestModule.Run()
		{
			Mouse.DefaultMoveTime = 300;
			Keyboard.DefaultKeyPressTime = 100;
			Delay.SpeedFactor = 1.0;
			
			DHSTranslateReader reader = new DHSTranslateReader();
			Dictionary<string, string> repoDict = reader.GetRepoText();
			
			repo.varDHSAppName = repoDict["DHSAppName"];
		}
	}
}
