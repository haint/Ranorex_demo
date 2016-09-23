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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.Validation
{
	public partial class CheckDHSInstalled
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void CheckRegistryKeyExist()
		{
			string regKey = @"HKEY_LOCAL_MACHINE/SOFTWARE/Dell/Dell Help & Support";
			// open regedit
			Keyboard.Press("{LWin down}r{LWin up}");
			Delay.Milliseconds(1000);
			
			Keyboard.Press("regedit");
			Delay.Milliseconds(200);
			
			Keyboard.Press("{Return}");
			Delay.Milliseconds(200);
			
			// click Computer Root Item
			TreeItem parentKey = repo.RegistryEditor.Computer.FindSingle(".");
			
			ExpandRegTreeItem(parentKey);
			
			// split path into item
			string[] key = regKey.Split('/');
			
			Report.Info("Check the Registry items of DHS");
			for(int i=0; i< key.Count(); i++){
				// select & open child key
				string childKeyXpath = @"./treeitem[@text='" + key[i] + "']";
				TreeItem childKey = null;
				try{
					childKey = parentKey.FindSingle(childKeyXpath);
				}
				catch(ElementNotFoundException){
					// report failure
					Report.Log(ReportLevel.Failure, "Registry KEY not found: " + key[i]);
					break;
				}
				childKey.Click();
				ExpandRegTreeItem(childKey);
				Delay.Milliseconds(500);
				parentKey = childKey;
				if(i == key.Count() - 1){
					// report success
					Report.Log(ReportLevel.Success, "Registry KEY found: " + regKey);
				}
			}
			// close registry window
			repo.RegistryEditor.Close.Click();
		}

		public void CheckServiceDetail()
		{
			// open services
			Keyboard.Press("{LWin down}r{LWin up}");
			Delay.Milliseconds(1000);
			
			Keyboard.Press("services.msc");
			Delay.Milliseconds(200);
			
			Keyboard.Press("{Return}");
			Delay.Milliseconds(3000);
			
			// select dell help & support
			//get all services
			IList<Row> allServiceList = repo.Services.ServiceList.Find<Ranorex.Row>(@"./row");
			int allServiceCount = allServiceList.Count;
			
			int index = 0;
			Row selectService = null;
			
			do{
				//get all visible service
				IList<Row> serviceList = repo.Services.ServiceList.Find<Ranorex.Row>(@"./row[@Visible='True']");
				int serviceCount = serviceList.Count;
				System.Diagnostics.Debug.WriteLine(serviceCount);
				Row lastItem = null;
				foreach(Row srv in serviceList){
					Cell srvNameCell = srv.FindSingle<Cell>(@"./cell[1]");
					string srvName = srvNameCell.GetAttributeValue<String>("Text");
					if(srvName.Contains("Dell Help & Support")){
						selectService = srv;
						break;
					}
					//Console.Out.WriteLine(srvName);
					lastItem = srv;
				}
				
				if(selectService == null){
					lastItem.Click();
					Delay.Milliseconds(500);
					// push page-down key
					Ranorex.Keyboard.Press("{PageDown}");
					Delay.Milliseconds(1000);
				}
				index = index + serviceCount;
			}
			while(selectService == null && index < allServiceCount - 1);
			
			selectService.Click();
			// check startup type
			Cell cell = selectService.FindSingle<Cell>(@"./cell[4]");
			
			//Console.Out.WriteLine(cell.GetAttributeValue<String>("Text"));
			
			Validate.AreEqual(cell.GetAttributeValue<String>("Text"), "Automatic (Delayed Start)", "Check DHS service Startup Type: actual = {0} and expected = {1}");
			Delay.Milliseconds(200);
			
			//close task manager
			repo.Services.Close.Click();
		}

		public void CheckServiceIsRunningInTaskManager()
		{
			
			Report.Info("Check the DHS Service from task manager:");
			
			// open task manager
			Keyboard.Press(System.Windows.Forms.Keys.Escape | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, 1, Keyboard.DefaultKeyPressTime, 1, true);
			Delay.Milliseconds(1000);
			
			//click more detail if it now in mini mode
			if(repo.TaskManager.CBExpandoButtonImage.GetAttributeValue<String>("Name") == "More details"){
				repo.TaskManager.CBExpandoButtonImage.Click();
				Delay.Milliseconds(1000);
			}
			
			// select service tab
			repo.TaskManager.Services.Click();
			Delay.Milliseconds(200);
			
			// select dell help & support
			//get all services
			IList<Row> allServiceList = repo.TaskManager.ServiceList.Find<Ranorex.Row>(@"./row");
			int allServiceCount = allServiceList.Count;
			
			int index = 0;
			Row selectService = null;
			
			do{
				//get all visible service
				IList<Row> serviceList = repo.TaskManager.ServiceList.Find<Ranorex.Row>(@"./row[@Visible='True']");
				int serviceCount = serviceList.Count;
				System.Diagnostics.Debug.WriteLine(serviceCount);
				Row lastItem = null;
				foreach(Row srv in serviceList){
					string srvName = srv.GetAttributeValue<String>("Name");
					if(srvName.Contains("Dell Help & Support")){
						selectService = srv;
						break;
					}
					System.Diagnostics.Debug.WriteLine(srvName);
					//Console.Out.WriteLine(srvName);
					lastItem = srv;
				}
				
				if(selectService == null){
					lastItem.Click();
					Delay.Milliseconds(500);
					// push page-down key
					Ranorex.Keyboard.Press("{PageDown}");
					Delay.Milliseconds(1000);
				}
				index = index + serviceCount;
			}
			while(selectService == null && index < allServiceCount - 1);
			
			selectService.Click();
			// check status = Running
			Cell cell = selectService.FindSingle<Cell>(@"./cell[4]");
			Validate.AreEqual(cell.GetAttributeValue<String>("Text"), "Running", "Check DHS service runnning status: actual={0} and expected = {1}");
			Delay.Milliseconds(200);
			
			//close task manager
			repo.TaskManager.Close.Click();
		}

		public void CheckProgramAndFeatureInfo()
		{
			Keyboard.Press("{LWin down}r{LWin up}");
			Delay.Milliseconds(1000);
			
			Keyboard.Press("control");
			Delay.Milliseconds(200);
			
			Keyboard.Press("{Return}");
			Delay.Milliseconds(200);
			
			repo.ControlPanel.CPanel.Programs.Click();
			Delay.Milliseconds(200);
			
			repo.ControlPanel.Programs.ProgramsAndFeatures.Click();
			Delay.Milliseconds(200);
			
			// check app information
			Report.Info("Check Control Panel - Programs and Features:");
			Validate.Exists (repo.ControlPanel.ProgramsAndFeatures.DHSAppTitle, "Check DHS found in program list");
			repo.ControlPanel.ProgramsAndFeatures.DHSAppTitle.Click();
			// check app name
			Cell cell = repo.ControlPanel.ProgramsAndFeatures.DHSAppTitle.FindSingle<Cell>(".");
			Validate.AreEqual(cell.GetAttributeValue<String>("Text"), "Dell Help & Support", "Check App Name: actual={0} and expected = {1}");
			
			// check publisher
			cell = cell.FindSingle<Cell>(@"./following-sibling::cell[2]");
			Validate.AreEqual(cell.GetAttributeValue<String>("Text"), "Dell Inc.", "Check Publisher: actual={0} and expected = {1}");
			
			// check install time
			cell = repo.ControlPanel.ProgramsAndFeatures.DHSAppTitle.FindSingle<Cell>(@"./following-sibling::cell[3]");
			string currentDate = System.DateTime.Now.ToString("M/d/yyyy");
			string installDate = cell.Text;
			Regex rgx = new Regex("[^a-zA-Z0-9 -/]");
			installDate = rgx.Replace(installDate, "");
			
			try{
				Validate.AreEqual(installDate, currentDate, "Check Installation date: actual = {0} and expected = {1}");
			}
			catch(ValidationException ex){
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
			// check version
			cell = repo.ControlPanel.ProgramsAndFeatures.DHSAppTitle.FindSingle<Cell>(@"./following-sibling::cell[5]");
			Validate.AreEqual(cell.GetAttributeValue<String>("Text"), varAppVersion, "Check Version: actual={0} and expected = {1}");
			
			// close
			repo.ControlPanel.ProgramsAndFeatures.Close.Click();
		}
		
		public void ExpandRegTreeItem(TreeItem item)
		{
			item.Click(System.Windows.Forms.MouseButtons.Right);
			// expand key
			try{
				repo.Regedit.ExpandInfo.WaitForExists(500);
				if(repo.Regedit.Expand.Enabled){
					repo.Regedit.Expand.Click();
				}
				else{
					Keyboard.Press("{Escape}");
				}
			}
			catch(RanorexException){
				Keyboard.Press("{Escape}");
			}
		}
		
		public void CheckFileFolderExist(string path)
		{
			// press Window E open file explorer
			Ranorex.Keyboard.Press("{LWin down}e{LWin up}");
			Delay.Milliseconds(1000);
			
			System.Diagnostics.Debug.WriteLine(path);
			// split path into item
			string[] dir = path.Split('\\');
			string fileExplorerXpath = null;
			for(int i=0; i< dir.Count(); i++){
				System.Diagnostics.Debug.WriteLine(dir[i]);
				if(i==0){
					repo.Explorer.ToolBar1001.Click();
					Ranorex.Keyboard.Press(dir[i]);
					Ranorex.Keyboard.Press("{Return}");
					fileExplorerXpath = "/form[@processname='explorer' and @title~'" + "(" + dir[i] + ")']";
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
						ListItem folder =  fileExplorer.FindSingle<ListItem>(folderXpath,5000);
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
			// report success
			Report.Log(ReportLevel.Success, "Install the DHS content to: " + path);
			// close file explorer
			repo.Explorer.Close.Click();
		}
		
		public void CheckDHSIconImage()
		{
			// get the screenshot from the repository
			Bitmap MyScreenshot = Imaging.Load(@"C:\DHSIcon.jpg");
			// create FindOptions with similarity set to 95%
			Imaging.FindOptions MyFindOptions = new Imaging.FindOptions(0.95);
			// compare the captured screenshot with the actual list item
			Validate.CompareImage(repo.Desktop.DellHelpSupportIconInfo, MyScreenshot, MyFindOptions);
		}
		
		public void CheckAppMetroTileColor()
		{
			repo.Taskbar.Start.Click();
			Delay.Milliseconds(200);
			
			try{
				repo.Start.GroupItems.MoveTo(new Location(GroupItems_Screenshot1, GroupItems_Screenshot1_Options));
				Delay.Milliseconds(200);
			}
			catch(RanorexException){
				Report.Log(ReportLevel.Failure, "DHS Icon NOT found on All App Start Menu");
			}
			
			Delay.Milliseconds(3000);
			//confirm color of metro tile
			if(isConfirmManualSteps.Equals("True")){
				string msg = "Please check if the color of DHS metro tile should be the same as that of other Dell software.\n\n" +
					"Are their colors the same? (Yes/No)";
				string msgResult = "The color of DHS metro tile should be the same as that of other Dell software";
				DialogResult result =  WinForms.MessageBox.Show(new WinForms.Form{TopMost = true},
				                                                msg, "Confirm Step",
				                                                WinForms.MessageBoxButtons.YesNo,
				                                                WinForms.MessageBoxIcon.Question,
				                                                WinForms.MessageBoxDefaultButton.Button1);
				Report.Log(result == DialogResult.Yes?ReportLevel.Success:ReportLevel.Failure, msgResult);
				
			}
			
		}

		public void CheckDHSIconOnDesktop(bool exist)
		{
			string msg = (exist==true)?"":"NOT";
			//try{
			//ListItem dhsIcon =  repo.Desktop.DellHelpSupportIcon.FindSingle<ListItem>(".",new Duration(1000));
			bool found = repo.Desktop.DellHelpSupportIconInfo.Exists(3000);
			if(found){
				Report.Log((exist==true)?ReportLevel.Success:ReportLevel.Failure, "Check DHS Icon is "+ msg +" found on Desktop");
			}
			else{			//}
				//catch(ElementNotFoundException ex){
				Report.Log((exist==true)?ReportLevel.Failure:ReportLevel.Success, "Check DHS Icon is "+ msg +" found on Desktop");
			}//}
		}
		
		public void CheckDHSIconInAllApp()
		{
			//confirm DHS Icon in All app Menu
			/*
			if(isConfirmManualSteps.Equals("True")){
				string msg = "1. Open All App from Start menu \n" +
					"2. Then check if the icon of DHS display there.\n\n" +
					"Does DHS icon display in All App? (Yes/No)";
				string msgResult = "DHS icon display in All App";
				DialogResult result =  WinForms.MessageBox.Show(msg, "Confirm Step",
				                                                WinForms.MessageBoxButtons.YesNo,
				                                                WinForms.MessageBoxIcon.Question,
				                                                WinForms.MessageBoxDefaultButton.Button1);
				Report.Log(result == DialogResult.Yes?ReportLevel.Success:ReportLevel.Failure, msgResult);
			}*/
			repo.Taskbar.Start.Click();
			Delay.Milliseconds(200);
			
			repo.Start.ContainerHash.Click();
			Delay.Milliseconds(200);
			
			repo.Start.TextD.Click();
			Delay.Milliseconds(200);
			
			try{
//				repo.Start.AppsList.Click(new Location(AppsList_Screenshot1, "4;4", AppsList_Screenshot1_Options));
//				Delay.Milliseconds(200);
				Keyboard.Press("{ENTER}");
				
				repo.Start.AppsList.MoveTo(new Location(AppsList_Screenshot2, "12;15", AppsList_Screenshot2_Options));
				Delay.Milliseconds(200);
				/*
				repo.Start.AppsList.Click(new Location(AppsList_Screenshot3, "4;5", AppsList_Screenshot3_Options));
				Delay.Milliseconds(200);
				
				repo.Start.AppsList.Click(new Location(AppsList_Screenshot4, "8;7", AppsList_Screenshot4_Options));
				Delay.Milliseconds(200);
				*/
				/*
				repo.Start.AppsList.Click(new Location(AppsList_Screenshot1, "4;4", AppsList_Screenshot1_Options));
				Delay.Milliseconds(200);
				
				repo.Start.AppsList.MoveTo(new Location(AppsList_Screenshot2, "12;15", AppsList_Screenshot2_Options));
				Delay.Milliseconds(200);
				*/
				Report.Log(ReportLevel.Success, "DHS Icon found on All App Start Menu");
			}
			catch(RanorexException){
				Report.Log(ReportLevel.Failure, "DHS Icon NOT found on All App Start Menu");
			}
			
			Keyboard.Press("{Escape}");
		}
		
		public void ConfirmInstallationCriteria()
		{
			// CheckDHSIconImage();
			Report.Info("Confirm the installation criteria was met:");
			CheckFileFolderExist(@"C:\Program Files\Dell\Dell Help & Support");
			CheckFileFolderExist(@"C:\ProgramData\Dell\Dell Help & Support\ContentRepo");
			CheckDHSIconOnDesktop(false);
			CheckDHSIconInAllApp();
			CheckAppMetroTileColor();
		}

		public void CheckDigitalSignature()
		{
			string path = @"C:\Program Files\Dell\Dell Help & Support";
			string fileName = @"Microsoft.Win32.TaskScheduler.dll";
			// press Window E open file explorer
			Ranorex.Keyboard.Press("{LWin down}e{LWin up}");
			Delay.Milliseconds(1000);
			
			System.Diagnostics.Debug.WriteLine(path);
			// split path into item
			string[] dir = path.Split('\\');
			Ranorex.Form fileExplorer = null;
			string fileExplorerXpath = null;
			for(int i=0; i< dir.Count(); i++){
				System.Diagnostics.Debug.WriteLine(dir[i]);
				if(i==0){
					repo.Explorer.ToolBar1001.Click();
					Ranorex.Keyboard.Press(dir[i]);
					Ranorex.Keyboard.Press("{Return}");
					fileExplorerXpath = "/form[@processname='explorer' and @title='" + "OS (" + dir[i] + ")']";
				}
				else{
					// find file explorer
					fileExplorer = null;
					Ranorex.Core.Element element =  Host.Local.FindSingle(fileExplorerXpath,5000);
					if(element != null){
						fileExplorer = element;
					}
					// check if folder exist
					string folderXpath = "element[@class='ShellTabWindowClass']//element[@instance='1']/container[@caption='ShellView']/list/listitem[@text='"+ dir[i] +"']";
					try{
						ListItem folder =  fileExplorer.FindSingle<ListItem>(folderXpath,5000);
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
			
			// select file Microsoft.Win32.TaskScheduler.dll, open property
			Ranorex.Keyboard.Press("Microsoft");
			// check if folder exist
			string fileXpath = "element[@class='ShellTabWindowClass']//element[@instance='1']/container[@caption='ShellView']/list/listitem[@text='"+ fileName +"']";
			ListItem file =  fileExplorer.FindSingle<ListItem>(fileXpath,5000);
			file.Click();
			Delay.Milliseconds(200);
			// open property
			Ranorex.Keyboard.Press("{RMenu down}{Return}{RMenu up}");
			Delay.Milliseconds(200);
			
			repo.MicrosoftWin32TaskSchedulerDllProper.DigitalSignatures.Click();
			Delay.Milliseconds(200);
			
			Cell nameOfSigner = repo.MicrosoftWin32TaskSchedulerDllProper.Self.FindSingle<Cell>(@"container[@caption='Digital Signatures']//cell[@text='Name of signer:']/following-sibling::cell[][1]");
			nameOfSigner.Click();
			
			string expectedNameOfSigner = "Dell Inc";
			string actualNameOfSigner = nameOfSigner.Text;
			
			Report.Info("Launch SHD install location and check Digital Signaltures:");
			Report.Log((actualNameOfSigner==expectedNameOfSigner)?ReportLevel.Success:ReportLevel.Failure, "Check name of Signer actual= " + actualNameOfSigner + ", expected = " + expectedNameOfSigner);
			
			repo.MicrosoftWin32TaskSchedulerDllProper.Close.Click();
			Delay.Milliseconds(1000);
			
			// close file explorer
			repo.Explorer.Close.Click();
		}
		
		#region Image Feature Data
		CompressedImage AppsList_Screenshot1
		{ get { return repo.Start.AppsListInfo.GetScreenshot1(new Rectangle(27, 51, 8, 8)); } }

		Imaging.FindOptions AppsList_Screenshot1_Options
		{ get { return Imaging.FindOptions.Default; } }

		CompressedImage AppsList_Screenshot2
		{ get { return repo.Start.AppsListInfo.GetScreenshot2(new Rectangle(31, 81, 18, 19)); } }

		Imaging.FindOptions AppsList_Screenshot2_Options
		{ get { return Imaging.FindOptions.Default; } }

		CompressedImage GroupItems_Screenshot1
		{ get { return repo.Start.GroupItemsInfo.GetScreenshot1(new Rectangle(19, 480, 18, 18)); } }

		Imaging.FindOptions GroupItems_Screenshot1_Options
		{ get { return Imaging.FindOptions.Default; } }
		
		CompressedImage AppsList_Screenshot3
		{ get { return repo.Start.AppsListInfo.GetScreenshot3(new Rectangle(16, 3, 8, 9)); } }

		Imaging.FindOptions AppsList_Screenshot3_Options
		{ get { return Imaging.FindOptions.Parse("0.9;None;0,0,0,0;True;10000000;5000ms"); } }

		CompressedImage AppsList_Screenshot4
		{ get { return repo.Start.AppsListInfo.GetScreenshot4(new Rectangle(2, 1, 18, 17)); } }

		Imaging.FindOptions AppsList_Screenshot4_Options
		{ get { return Imaging.FindOptions.Parse("0.9;None;0,0,0,0;True;10000000;5000ms"); } }
		#endregion
	}
}