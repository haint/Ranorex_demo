/*
 * Created by Ranorex
 * User: DHS
 * Date: 8/28/2016
 * Time: 1:24 AM
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
	/// Description of DHSCategory.
	/// </summary>
	public class DHSCategory
	{
		public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

		public DHSCategory()
		{
		}
		
		public static void CheckCategoryOnLeftMenu(string name){
			
			
			DHSTranslateReader reader = new DHSTranslateReader();
			Dictionary<string, Object> categories = reader.GetCategories();
			Dictionary<string, Object> category = (Dictionary<string, Object>)categories[name];
			string cattitle = (String)category["title"];
			// check category title
			System.Console.WriteLine("Category: " + cattitle);
			// compare category name on left menu
			try{
				Text catText = repo.DHSMainWindow.ContentManagementControl.Self.FindSingle("./text[@text='"+cattitle+"']");
				
				Report.Log(ReportLevel.Success, "Check if Category title on Side bar with text \"" + cattitle + "\"");
			}
			catch(RanorexException ex){
				Report.Log(ReportLevel.Failure, "Check if Category title on Side bar with text \"" + cattitle + "\"");
				throw;
			}
			/*
			Dictionary<string, Object> articles = (Dictionary<string, Object>)category["articles"];
			foreach(string key in articles.Keys){
				// check article title
				Dictionary<string, Object> article = (Dictionary<string, Object>)articles[key];
				string artitle = (String)article["title"];
				System.Console.WriteLine("Article: " + artitle);
				
				try{
					Text arText = repo.DHSMainWindow.ContentManagementControl.ArticleTitleList.FindSingle("./listitem/text[@text='"+artitle+"']");
					Report.Log(ReportLevel.Success, "Check if Article title on Side bar with text \"" + artitle + "\"");
					arText.Click();
					Delay.Milliseconds(1000);
				}
				catch(RanorexException ex){
					Report.Log(ReportLevel.Failure, "Check if Category title on Side bar with text \"" + artitle + "\"");
					throw;
				}
				
				Dictionary<string, Object> content = (Dictionary<string, Object>)article["content"];
				string header = (String)content["header"];
				System.Console.WriteLine("Header: " + header);
			}
			 */
		}
	}
}
