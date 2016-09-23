/*
 * Created by Ranorex
 * User: 22
 * Date: 7/11/2016
 * Time: 11:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using WinForms = System.Windows.Forms;

namespace DHSAutomation.Objects
{
	/// <summary>
	/// Description of LANandWLAN.
	/// </summary>
	[TestModule("B276BADC-DD29-4F9D-8F31-94FBD5EE8340", ModuleType.UserCode, 1)]
	public class Internet
	{
		public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public Internet()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		public static bool CanPingToAdressOrIP(string nameOrAdress)
		{

			bool pingable = false;
			Ping pinger = new Ping();
			try
			{
				PingReply reply = pinger.Send(nameOrAdress);
				pingable = reply.Status == IPStatus.Success;
			}
			catch (PingException)
			{
				// Discard PingExceptions and return false;
			}
			return pingable;

		}
		
		public static bool CanPingToDNSWithoutConfig()
		{
			return CanPingToAdressOrIP("208.67.222.222")
				||CanPingToAdressOrIP("8.8.8.8")?  true: false;
		}
		public static bool CanPingPopularWebsiteWithOutConfig()
		{
			return CanPingToAdressOrIP("google.com")
				||CanPingToAdressOrIP("bing.com")
				||CanPingToAdressOrIP("baidu.com")?  true: false;
		}
		public static bool IsConnectToInternetOKWithOutConfig()
		{
			return CanPingToDNSWithoutConfig()&&CanPingPopularWebsiteWithOutConfig();
		}
		public static void DoConnectDisconnectNetwork(bool connect)
		{
			string expectedStatus = "";
			string originStatus = TestSuite.Current.Parameters["networkConnectionStatus"];
			string originName = TestSuite.Current.Parameters["networkConnectionName"];
			System.Console.WriteLine(expectedStatus);
			bool isActionSucceeded = false;
			
			if(connect){
				if(!IsNetworkConnected()){
					// do connect
					if(originStatus == "Connected"){
						ListItem item = repo.Network.NetworkConnectionPanel.NetworkConnectionList.FindSingle<ListItem>("./listitem[@text='"+originName+"']");
						isActionSucceeded = DoEnable(item, true);
					}
					else{
						do{
							try{
								ListItem disabledItem = repo.Network.NetworkConnectionPanel.NetworkConnectionList.FindSingle<ListItem>("./listitem/text[@childindex=3 and @text='Disabled']/parent::listitem");
								isActionSucceeded = DoEnable(disabledItem, true);
							}
							catch(RanorexException ex){
								break;
							}
						}
						while(true);
						/*
						try{
							// ethernet connection
							IList<ListItem> ethernets = repo.Network.NetworkConnectionPanel.NetworkConnectionList.Find<ListItem>("./listitem[@text~'Ethernet']/text[@ChildIndex=3 and @text='Disabled']/parent::listitem");
							foreach(ListItem ethernet in ethernets){
								isActionSucceeded = DoEnable(ethernet, true);
								if(isActionSucceeded){
									break;
								}
							}
						}
						catch(RanorexException ex){
							// wifi	connection
							
						}
						*/
					}
				}
			}
			else{
				if(IsNetworkConnected()){
					// do disconnect all
					do{
						try{
							repo.Network.NetworkConnectionPanel.NetworkConnectedItemsInfo.WaitForExists(new Duration(15000));
							ListItem connectedItems = repo.Network.NetworkConnectionPanel.NetworkConnectedItems.FindSingle<ListItem>(".");
							isActionSucceeded = DoEnable(connectedItems, false);
						}
						catch(RanorexException ex){
							break;
						}
					}
					while(true);
				}
			}
		}
		
		public static bool DoEnable(ListItem item, bool isEnable){
			bool isActionSucceeded = false;
			
			if(isEnable){
				// do enable
				item.Click(System.Windows.Forms.MouseButtons.Right);
				Delay.Milliseconds(1000);
				// select disable
				Ranorex.MenuItem menuitem = repo.ContextMenu.Self.FindSingle<Ranorex.MenuItem>("./?/?/menuitem[@accessiblename='Enable']");
				menuitem.Click();
				int i = 0;
				do{
					Delay.Milliseconds(3000);
					Text text = item.FindSingle<Text>("./text[@childindex=3]");
					string status = text.TextValue;
					if(status != "Not connected" && status != "Identifing..." && status != "Disabled" && status != "Network cable unplugged" && status!= "Unidentified network"){
						isActionSucceeded = true;
						break;
					}
					i++;
				}
				while(i < 3);
			}
			else{
				// do disable
				item.Click(System.Windows.Forms.MouseButtons.Right);
				Delay.Milliseconds(1000);
				// select disable
				Ranorex.MenuItem menuitem = repo.ContextMenu.Self.FindSingle<Ranorex.MenuItem>("./?/?/menuitem[@accessiblename='Disable']");
				menuitem.Click();
				int i = 0;
				do{
					Delay.Milliseconds(3000);
					Text text = item.FindSingle<Text>("./text[@childindex=3]");
					string status = text.TextValue;
					if(status == "Disabled"){
						isActionSucceeded = true;
						break;
					}
					i++;
				}
				while(i < 3);
			}
			return isActionSucceeded;
		}
		
		public static bool IsNetworkConnected(){
			bool isConnected = true;
			try{
				repo.Network.NetworkConnectionPanel.NetworkConnectedItemsInfo.WaitForExists(new Duration(3000));
			}
			catch(RanorexException ex){
				isConnected = false;
			}
			return isConnected;
		}
		//============================asdasd========================
	}
}
