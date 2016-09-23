/*
 * Created by Ranorex
 * User: public
 * Date: 8/14/2016
 * Time: 8:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using System.Xml.XPath;

using DHSAutomation.Common;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Reporting;
using Ranorex.Core.Testing;
using WinForms = System.Windows.Forms;

namespace DHSAutomation
{
	class Program
	{
		[STAThread]
		public static int Main(string[] args)
		{
			// Uncomment the following 2 lines if you want to automate Windows apps
			// by starting the test executable directly
			
			if (Util.IsRestartRequiredForWinAppAccess)
				return Util.RestartWithUiAccess();
//			try 
//			{
//				Utils.DisableAboveModule(false);
//				
//				
//			}catch (Exception e)
//			{
//				Console.WriteLine(e.ToString());
//				Console.ReadLine();
//			}
			
			
			Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
			int error = 0;
			var testSuiteXml = File.Exists("Runner.rxtst") ? XElement.Load("Runner.rxtst").ToString() : XElement.Load("DHSAutomation.rxtst").ToString();
			CultureInfo ci = Utils.GetOSLanguage();
			string langCode = ci.Name;
			Console.WriteLine(langCode);
			
//			bool stopped = false;
//			bool itself = true;
//			
//			try {
//				var docSet = XElement.Load("DHSAutomation.rxtst");
//
//				foreach (var e in docSet.XPathSelectElements("//testconfiguration/testcase")) {
//					var caseId = e.Attribute("id").Value;
//					foreach (var testModule in docSet.XPathSelectElements("//childhierarchy/testsuite/testcase/testcase[@id='" + caseId + "']/testmodule")) {
//						var testModuleId = testModule.Attribute("id").Value;
//						var orgTestModule = docSet.XPathSelectElement("//flatlistofchildren//testmodule[@id='" + testModuleId + "']");
//						var refId = orgTestModule.Attribute("ref").Value;
//						if (!stopped) {
//							if (!refId.Equals("5110d38b-fdba-4df5-8ebc-549d97bac8e2") || !itself) {
//								orgTestModule.SetAttributeValue("enabled", "False");
//							}
//							Console.WriteLine(orgTestModule);
//						}
//						if (refId.Equals("5110d38b-fdba-4df5-8ebc-549d97bac8e2")) {
//							stopped = true;
//						}
//					}
//				}
//				
//				File.WriteAllText("Runner.rxtst", docSet.ToString());
//				
//			} catch (Exception e) {
//				Console.WriteLine(e.ToString());
//			}
//			
//			Console.ReadLine();
			
			try
			{
				error = TestSuiteRunner.Run(typeof(Program), Environment.CommandLine, testSuiteXml);
			}
			catch (Exception e)
			{
				Report.Error("Unexpected exception occurred: " + e.ToString());
				error = -1;
			}
			
			return error;
		}
	}
}
