/*
 * Created by Ranorex
 * User: DHS
 * Date: 8/26/2016
 * Time: 2:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;


namespace DHSAutomation.Common
{
	/// <summary>
	/// Description of DHSTranslateReader.
	/// </summary>
	public class DHSTranslateReader
	{
		private XmlReader root = null;
		
		public DHSTranslateReader()
		{
			
		}
		
		public XmlReader GetLanguageTree(){
			CultureInfo ci = Utils.GetOSLanguage();
			string langCode = ci.Name;
			string langScope = "en - zh - pt - ja - fr - es - de";
			if(!langScope.Contains(langCode.Substring(0,2))){
				langCode = "en-US";
			}
			root = XmlReader.Create(Directory.GetCurrentDirectory() + @"\Resources\DHSTranslate.xml");
			// If the node has value
			root.Read();
			root.ReadToFollowing("language");
			do {
				if(root.GetAttribute("code") == langCode){
					return root.ReadSubtree();
				}
			}
			while (root.ReadToNextSibling("language"));
			return null;
		}
		
		public Dictionary<string, string> GetRepoText(){
			Dictionary<string, string> map = new Dictionary<string, string>();
			XmlReader xml = GetLanguageTree();
			if(xml != null){
				xml.ReadToDescendant("repovars");
				xml.ReadToDescendant("var");
				do{
					string name = xml.GetAttribute("name");
					map.Add(name, xml.ReadString());
				}
				while(xml.ReadToNextSibling("var"));
			}
			return map;
		}
		
		public Dictionary<string, string> GetLeftMenuText(){
			Dictionary<string, string> map = new Dictionary<string, string>();
			XmlReader xml = GetLanguageTree();
			if(xml != null){
				xml.ReadToDescendant("leftmenu");
				xml.ReadToDescendant("element");
				do{
					string name = xml.GetAttribute("name");
					map.Add(name, xml.ReadString());
				}
				while(xml.ReadToNextSibling("element"));
			}
			return map;
		}
		
		public Dictionary<string, string> GetNavigationPanelText(string panel){
			Dictionary<string, string> map = new Dictionary<string, string>();
			XmlReader xml = GetLanguageTree();
			if(xml != null){
				xml.ReadToDescendant("navigationpanels");
				xml.ReadToDescendant("navigationpanel");
				do{
					string name = xml.GetAttribute("name");
					if(name == panel){
						XmlReader tree = xml.ReadSubtree();
						tree.ReadToDescendant("element");
						do{
							string key = tree.GetAttribute("name");
							string value = tree.ReadString();
							map.Add(key, value);
						}
						while(tree.ReadToNextSibling("element"));
						break;
					}
				}
				while(xml.ReadToFollowing("navigationpanel"));
			}
			return map;
		}
		
		public Dictionary<string, Object> GetCategories(){
			Dictionary<string, Object> map = new Dictionary<string, Object>();
			XmlReader xml = GetLanguageTree();
			if(xml != null){
				xml.ReadToDescendant("categories");
				xml.ReadToDescendant("category");
				do{
					string catname = xml.GetAttribute("name");
					//System.Console.WriteLine(catname);
					Dictionary<string, Object> category = new Dictionary<string, Object>();
					xml.ReadToDescendant("title");
					string cattitle = xml.ReadString();
					//System.Console.WriteLine(cattitle);
					
					category.Add("title", cattitle);
					
					xml.ReadToNextSibling("articles");
					XmlReader tree= xml.ReadSubtree();
					
					Dictionary<string, Object> articles = new Dictionary<string, Object>();
					tree.ReadToDescendant("article");
					int i=0;
					do{
						string arname = tree.GetAttribute("name");
						//System.Console.WriteLine(arname);
						if(i++ == 0){
							articles.Add("#first", arname);
							//System.Console.WriteLine("First: " + arname);
						}
						Dictionary<string, Object> article = new Dictionary<string, Object>();
						tree.ReadToDescendant("title");
						string artitle = tree.ReadString();
						//System.Console.WriteLine("Title: " + artitle);
						article.Add("title", artitle);
						
						tree.ReadToNextSibling("featuretitle");
						string featuretitle = tree.ReadString();
						//System.Console.WriteLine("Feature title: " + featuretitle);
						article.Add("featuretitle", featuretitle);

						tree.ReadToNextSibling("content");
						Dictionary<string, Object> content = new Dictionary<string, Object>();
						tree.ReadToDescendant("header");
						string header = tree.ReadString();
						content.Add("header", header);
						content.Add("body", "NOBODY");
						//System.Console.WriteLine("Header: " + header);
						
						article.Add("content", content);
						articles.Add(arname, article);
						
					}
					while(tree.ReadToFollowing("article"));
					
					category.Add("articles", articles);
					map.Add(catname, category);
				}
				while(xml.ReadToFollowing("category"));
			}
			return map;
		}
		
	}
}
