/*
 * Created by Ranorex
 * User: DHS
 * Date: 8/28/2016
 * Time: 12:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using DHSAutomation.Common;
using DHSAutomation.Objects;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using WinForms = System.Windows.Forms;

namespace DHSAutomation.Objects
{
	/// <summary>
	/// Description of DHSArticle.
	/// </summary>
	public class DHSArticle
	{
		public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

		public DHSArticle()
		{
		}
		
		public static void CheckArticleOnLeftMenu(string catname, string arname, bool isClick){
			DHSTranslateReader reader = new DHSTranslateReader();
			Dictionary<string, Object> categories = reader.GetCategories();
			Dictionary<string, Object> category = (Dictionary<string, Object>)categories[catname];
			string cattitle = (String)category["title"];

			Dictionary<string, Object> articles = (Dictionary<string, Object>)category["articles"];
			// check article title
			Dictionary<string, Object> article = (Dictionary<string, Object>)articles[arname];
			string artitle = (String)article["title"];
			System.Console.WriteLine("Article: " + artitle);
			
			try{
				Text arText = repo.DHSMainWindow.ContentManagementControl.ArticleTitleList.FindSingle("./listitem/text[@text='"+artitle+"']");
				Report.Log(ReportLevel.Success, "Check if Article title on Side bar with text \"" + artitle + "\"");
				if(isClick){
					arText.Click();
					Delay.Milliseconds(1000);
				}
			}
			catch(RanorexException ex){
				Report.Log(ReportLevel.Failure, "Check if Article title on Side bar with text \"" + artitle + "\"");
				throw;
			}
		}
		
		public static void CheckArticleOnContentPanel(string catname, string arname){
			DHSTranslateReader reader = new DHSTranslateReader();
			Dictionary<string, Object> categories = reader.GetCategories();
			Dictionary<string, Object> category = (Dictionary<string, Object>)categories[catname];
			string cattitle = (String)category["title"];

			Dictionary<string, Object> articles = (Dictionary<string, Object>)category["articles"];
			// check article title
			Dictionary<string, Object> article = (Dictionary<string, Object>)articles[arname];
			string artitle = (String)article["title"];
			System.Console.WriteLine("Article: " + artitle);
			
			Dictionary<string, Object> content = (Dictionary<string, Object>)article["content"];
			string header = (String)content["header"];
			System.Console.WriteLine("Header: " + header);
			
			// get actual header
			H1Tag arHeader = Host.Local.FindSingle<H1Tag>(@"/dom//div[#'ArticleBody']//h1");
			arHeader.Click();
			Delay.Milliseconds(1000);
			string arHeaderText = arHeader.InnerText;
			Report.Log((arHeaderText == header)?ReportLevel.Success:ReportLevel.Failure, 
			           "Check Article title on Content Area: expected text is: \"" + header +"\" and actuall text is: \""+ arHeaderText+ "\"");
			// check verticle scroll bar is shown if article content spread more than 1 page
			try{
				Ranorex.WebElement invisibleElement = Host.Local.FindSingle<Ranorex.WebElement>(@"/dom//div[#'ArticleBody']//*[@visible='False']", 10000);
				CheckVerticleScrollBar(true);
			}
			catch(ElementNotFoundException ex){
				CheckVerticleScrollBar(false);
			}
			
			string networkStatus = repo.Taskbar.NetwordIcon.GetAttributeValue<String>("Text");
			Delay.Milliseconds(5000);
			if(networkStatus.Contains("access")){
				// check article language
				Report.Log(ReportLevel.Info, "Check article language when connect network!");
				CheckArticleLanguage(artitle);
			}
			
		}
		
		public static void CheckVerticleScrollBar(bool isVisible){
			string show = (isVisible == true)?"":"NOT";
			try{
				DivTag verticalScrollBar= Host.Local.FindSingle<DivTag>(@"/dom//div[@class='nicescroll-rails' and @visible='True']", 10000);
				DivTag verticalChildScrollBar = Host.Local.FindSingle<DivTag>(@"/dom//div[@class='nicescroll-rails' and @visible='True']/div", 10000);
				
				//get height of scrollbar and height of scroll item
				double h1 = verticalScrollBar.ScreenRectangle.Height;
				double h2 = verticalChildScrollBar.ScreenRectangle.Height;
				//calculate how many times need to press page down
				int step = (int)Math.Ceiling(h1/h2);
				
				
				//press page down
				for(int i=0;i<step;i++){
					Keyboard.Press("{Next}");
					Delay.Milliseconds(1000);
				}
				
				
				Report.Log((isVisible == true)?ReportLevel.Success:ReportLevel.Failure, "Check Vertical scroll bar is "+ show +" shown");
			}
			catch(ElementNotFoundException ex){
				Report.Log((isVisible == true)?ReportLevel.Failure:ReportLevel.Success, "Check Vertical scroll bar is "+ show +" shown");
			}
		}
		
		public static void CheckArticleLanguage(string arTitle){
			string osLanguage = Utils.GetOSLanguage().Name.ToLower();
			// check language
			
			DivTag body= Host.Local.FindSingle<DivTag>(@"/dom//div[#'ArticleBody']", 5000);
			
			string articleText = StripHTML(body.GetInnerHtml());
			
			Dictionary<string, float> detectedLanguages = null;
			string osLanguageCode = osLanguage.Substring(0,2);
			string[] lines = Regex.Split(articleText, @"(\n)+");
			bool inOSLang = true;
			//int i = 0;
			foreach(string line in lines){
				if(line.Trim() == "" || line.Trim() == @"\n"){
					continue;
				}
				//if(i++ > 20){
				//	break;
				//}
				detectedLanguages = Utils.InWhichLanguages(line.Trim());
				
				if(detectedLanguages.Count > 0 && !detectedLanguages.ContainsKey(osLanguageCode)){
					string detectedLanguageNames = "";
					foreach(string key in detectedLanguages.Keys){
						string lang = (new CultureInfo(key)).DisplayName;
						detectedLanguageNames += "[" + lang + ", confident:" + detectedLanguages[key] + "], ";
					}
					
					inOSLang = false;
					Report.Log(ReportLevel.Failure,
					           "Detected Article with title {"+arTitle+"} contains string not in Expected language: {" + Utils.GetOSLanguage().DisplayName +"}, " +
					           "but in following languages: {" + detectedLanguageNames + "} " +
					           "Refer string: " + line);
				}
			}
			if(inOSLang == true){
				Report.Log(ReportLevel.Success, "Article with title {"+arTitle+"} is in Expected language: {" + Utils.GetOSLanguage().DisplayName +"}");
			}
		}
		
		public static string StripHTML(string HTMLText, bool decode = true) {
			Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
			var stripped = reg.Replace(HTMLText, "");
			return decode ? WebUtility.HtmlDecode(stripped) : stripped;
		}
		
		
	}
}
