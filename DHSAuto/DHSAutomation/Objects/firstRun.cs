/*
 * Created by Ranorex
 * User: DHS
 * Date: 9/20/2016
 * Time: 5:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Ranorex;

namespace DHSAutomation.Objects
{
	/// <summary>
	/// Description of firstRun.
	/// </summary>
	public class firstRun
	{
		
		DHSAutomationRepository repo = new DHSAutomationRepository();
		
		public firstRun()
		{
		}
		
		
		
		public void checkDHSFirstRun(){
        
//        	if DHS run for the 1st time, the "Warranty" panel will be opened
        	if(repo.DHS_HaiNT21_Form.SomeContainer1.Visible == true){
        		Report.Info("DHS run at the first time");
        		
//        		close the "Warranty" panel
        		string exButt = @"/form[@wpfnative='True' and @name='mainWindow']/container[@automationid='MainWindowGrid']
									/container[@automationid='HomepageGrid']/container[@automationid='NavigationPanel']
									/container[@automationid='LeftNavItemPanel']//picture[@automationid='ClosePanelImage']";
        		Mouse.Click(repo.MainWindow.Self.FindSingle(exButt));
			} else {
				Report.Info("DHS is running");
			}
							
        }
		
		public void checkIEForm(){

//        	Form ieForm = "/form[@title='Internet Explorer 11']";
//        	Validate.Exists(repo.IESetupPopop.SelfInfo.Exists().ToString());

//			Open IE if necessary
			/*
			string winSymbol = @"/menubar[@processname='explorer']/element[@class='Start']/button";
			Mouse.Click(repo.Taskbar.Self.FindSingle(winSymbol));
			Ranorex.Keyboard.Press("ie{Return}");
			Delay.Milliseconds(3000);
			*/

//			check if IE11 - First Run Wizard is Pop up or not
			if(repo.IESetupPopop.SelfInfo.Exists().ToString() == "True"){
	
//				if IE runs the first time
				Report.Info("IE First Run Wizard is visible");
				
//				choose "use recommend security" and close it
				string path = @"/form[@title='Internet Explorer 11']/radiobutton[@text~'Use recommended security']";
				Mouse.Click(repo.IESetupPopop.Self.FindSingle(path));
				
//				click ok
				string okButt = @"/form[@title='Internet Explorer 11']/button[@text='&OK']";
				Mouse.Click(repo.IESetupPopop.Self.FindSingle(okButt));
				
			} else {
//				Report.Info("invisible");
				Report.Info("IE First Run Wizard is not exist.");
			}
        	
        	
        }
		
		
	}
}
