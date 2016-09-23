/*
 * Created by Ranorex
 * User: DHS
 * Date: 8/23/2016
 * Time: 9:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using RS1Automation.Utilities;
using WinForms = System.Windows.Forms;

namespace DHSAutomation.Common
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Utils
	{
		public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

		public Utils()
		{
		}
		
		public static CultureInfo GetOSLanguage(){
			//get os language
			CultureInfo ci = CultureInfo.InstalledUICulture;
			//Console.WriteLine("Installed Language Info:{0}", ci.Name);
			ci = CultureInfo.CurrentUICulture;
			//Console.WriteLine("Current UI Language Info: {0}", ci.Name);
			ci = CultureInfo.CurrentCulture;
			//Console.WriteLine("Current Language Info: {0}", ci.Name);
			return ci;
		}
		
		public static string GetPlatformName(){
			string platformName = TestSuite.Current.Parameters["platformName"];
			Regex rgx = new Regex(@"\s.*");
			return rgx.Replace(platformName, "");
		}
		
		public static string ExtractTextFromPdf(string path)
		{
			using (PdfReader reader = new PdfReader(path))
			{
				StringBuilder text = new StringBuilder();

				for (int i = 1; i <= reader.NumberOfPages; i++)
				{
					text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
				}
				
				return text.ToString();
			}
		}
		
		public static Dictionary<string, float> InWhichLanguages(string text){
			Dictionary<string, float> languages = new Dictionary<string, float>();
			try
			{
				string url = CreateRequest(text);

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
				{
					if (response.StatusCode != HttpStatusCode.OK)
						throw new Exception(String.Format(
							"Server error (HTTP {0}: {1}).",
							response.StatusCode,
							response.StatusDescription));
					using (var reader = new StreamReader(response.GetResponseStream()))
					{
						JavaScriptSerializer js = new JavaScriptSerializer();
						//var objects = js.Deserialize<dynamic>(reader.ReadToEnd());
						Dictionary<string,object> dict = js.Deserialize<Dictionary<string,object>>(reader.ReadToEnd());
						foreach(string key in dict.Keys)
						{
							// data
							Console.WriteLine(key);
							Dictionary<string,object> dict1 = (Dictionary<string,object>)dict[key];
							foreach(string key1 in dict1.Keys)
							{
								// detection
								Console.WriteLine(key1);
								Console.WriteLine(dict1[key1]);
								Console.ReadLine();
								object array = dict1[key1];
								foreach(Dictionary<string, object> dict2 in (ArrayList)array){
									foreach(string key2 in dict2.Keys)
									{
										if(key2 == "language"){
											string lang = dict2["language"].ToString();
											float conf = float.Parse(dict2["confidence"].ToString());
											//if(conf > confident){
											//	language = lang;
											//}
											languages.Add(lang, conf);
											Console.WriteLine(lang + ":" + conf);
										}
										//Console.WriteLine(key2 + ":" + dict2[key2].ToString());
									}
								}
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
			return languages;
		}
		
		public static string CreateRequest(string queryString)
		{
			string UrlRequest = "http://ws.detectlanguage.com/0.2/detect?q="+queryString+"&key=83ac666de8e63ee1d2361aa829228845";
			return (UrlRequest);
		}
		
		public static void OpenFile(string path){
			// press Window E open file explorer
			Ranorex.Keyboard.Press("{LWin down}e{LWin up}");
			Delay.Milliseconds(1000);
			
			System.Diagnostics.Debug.WriteLine(path);
			// split path into item
			string[] dir = path.Split('\\');
			string fileExplorerXpath = null;
			for(int i=0; i< dir.Length; i++){
				System.Diagnostics.Debug.WriteLine(dir[i]);
				if(i==0){
					repo.Explorer.ToolBar1001.Click();
					Ranorex.Keyboard.Press(dir[i]);
					Ranorex.Keyboard.Press("{Return}");
					fileExplorerXpath = "/form[@processname='explorer' and @title='" + "OS (" + dir[i] + ")']";
				}
				else{
					// find file explorer
					Ranorex.Form fileExplorer = null;
					Ranorex.Core.Element element =  Host.Local.FindSingle(fileExplorerXpath,5000);
					if(element != null){
						fileExplorer = element;
					}
					// check if folder exist
					string folderXpath = "element[@class='ShellTabWindowClass']//element[@instance='1']/container[@caption='ShellView']/list/listitem[@text='"+ dir[i] +"']";
					try{
						Ranorex.ListItem folder =  fileExplorer.FindSingle<Ranorex.ListItem>(folderXpath,5000);
						folder.DoubleClick();
						Delay.Milliseconds(500);
					}
					catch(ElementNotFoundException ex){
						// report fail
						Report.Log(ReportLevel.Failure, "Folder not found: " + path);
						throw ex;
					}
					fileExplorerXpath = "/form[@processname='explorer' and @title='" + dir[i] + "']";
				}
			}
		}
		
		public static string GetCurrentGEOLocationCountry(){
			Host.Local.OpenBrowser("http://ipaddress.com/", "IE", "", false, true, false, false, false);
			repo.WhatIsMyIPAddress.TdTagCountryInfo.WaitForExists(10000);
			repo.WhatIsMyIPAddress.TdTagCountry.MoveTo();
			Delay.Milliseconds(2000);
			string coutryName = repo.WhatIsMyIPAddress.TdTagCountry.InnerText;
			Keyboard.Press("{LControlKey down}{Wkey}{LControlKey up}");
			return coutryName;
		}
		
		public static void ExecuteCommand (string command,string fileName)
		{
			Process cmd = new Process();
			cmd.StartInfo.FileName = fileName;
			cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			cmd.StartInfo.Arguments=command;
			cmd.Start();
		}
		public static void SignOut() 
		{
			Report.Log(ReportLevel.Info, "Key sequence '{LWin down}r{LWin up}'.");
            Keyboard.Press("{LWin down}r{LWin up}");
            
            Report.Log(ReportLevel.Info, "Setting attribute shutdown /l /f to TextBox item.");
//            Keyboard.("shutdown /l /f");
			repo.Explorer.WindowR.TextValue = "shutdown /l /f";
			
            Report.Log(ReportLevel.Info, "Mouse Left Click item Button OK.");
            Keyboard.Press("{Enter}");
		}
		
		public static void RunAtStartupUsingBatFile( bool register = true)
		{
			string workingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
			string exePath=System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"\\DHSAutomation.exe";
			
			
			if (register)
			{
				TaskScheduleUtil.createTaskRuningAtStart("DHS_Auto_Start", exePath,workingDirectory);
			}
			else
			{
				TaskScheduleUtil.deleteTaskRunningAtStart("DHS_Auto_Start");
			}
		}
		
		public static void DisableAboveModule(object testModuleRef)
		{
        	TestModuleAttribute testModuleAtt = testModuleRef.GetType().GetCustomAttribute<TestModuleAttribute>();
        	Console.WriteLine(testModuleAtt.Guid.ToString());
        	bool stopped = false;
			try {
				var docSet = XElement.Load("DHSAutomation.rxtst");
				foreach (var e in docSet.XPathSelectElements("//testconfiguration/testcase")) {
					var caseId = e.Attribute("id").Value;
					foreach (var testModule in docSet.XPathSelectElements("//childhierarchy/testsuite/testcase/testcase[@id='" + caseId + "']/testmodule")) {
						var testModuleId = testModule.Attribute("id").Value;
						var orgTestModule = docSet.XPathSelectElement("//flatlistofchildren//testmodule[@id='" + testModuleId + "']");
						var refId = orgTestModule.Attribute("ref").Value;
						orgTestModule.SetAttributeValue("enabled", "False");
						if (refId.Equals(testModuleAtt.Guid.ToString())) break;
					}
				}
				File.WriteAllText("Runner.rxtst", docSet.ToString());
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
        	
		}
		
		
		public static void DisableAboveModule(bool itself = true)
        {
        	bool stopped = false;
        	
			
			try {
				var docSet = XElement.Load("DHSAutomation.rxtst");

				foreach (var e in docSet.XPathSelectElements("//testconfiguration/testcase")) {
					var caseId = e.Attribute("id").Value;
					foreach (var testModule in docSet.XPathSelectElements("//childhierarchy/testsuite/testcase/testcase[@id='" + caseId + "']/testmodule")) {
						var testModuleId = testModule.Attribute("id").Value;
						var orgTestModule = docSet.XPathSelectElement("//flatlistofchildren//testmodule[@id='" + testModuleId + "']");
						var refId = orgTestModule.Attribute("ref").Value;
						if (!stopped) {
							if (!refId.Equals("5110d38b-fdba-4df5-8ebc-549d97bac8e2") || !itself) {
								orgTestModule.SetAttributeValue("enabled", "False");
							}
							Console.WriteLine(orgTestModule);
						}
						if (refId.Equals("5110d38b-fdba-4df5-8ebc-549d97bac8e2")) {
							stopped = true;
						}
					}
				}
				
				File.WriteAllText("Runner.rxtst", docSet.ToString());
				
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
        }
	}
}
