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
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.General
{
    public partial class OpenTelemetry
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            Report.Log(ReportLevel.Info, "Website", "Opening web site 'https://daws-portal-test.azurewebsites.net' with browser 'IE' in maximized mode.");
            Host.Local.OpenBrowser("https://daws-portal-test.azurewebsites.net", "IE", "", false, true, false, false, false);
            Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{LWin down}r{LWin up}'.", new RecordItemIndex(1));
            //Keyboard.Press("{LWin down}r{LWin up}");
            //Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(2));
            //Delay.Duration(1000, false);
            
            //Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'iexplore.exe{Return}'.", new RecordItemIndex(3));
            //Keyboard.Press("iexplore.exe{Return}");
            //Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(4));
            //Delay.Duration(1000, false);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IE.Edit' at CenterLeft.", repo.IE.EditInfo, new RecordItemIndex(5));
            //repo.IE.Edit.Click(Location.CenterLeft);
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'https://daws-portal-test.azurewebsites.net {Return}' with focus on 'IE.Edit'.", repo.IE.EditInfo, new RecordItemIndex(6));
            //repo.IE.Edit.PressKeys("https://daws-portal-test.azurewebsites.net {Return}", 200);
            //Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'dawsuser' at 'UserName'.");
            repo.DellApplicationWebServiceDAWS.UserName.PressKeys("dawsuser");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'Daws@Dell' at 'Password'.");
            repo.DellApplicationWebServiceDAWS.Password.PressKeys("Daws@Dell");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Login'.");
            repo.DellApplicationWebServiceDAWS.Submit.Click();
            Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 3s.", new RecordItemIndex(10));
            Delay.Duration(3000, false);
        }

    }
}