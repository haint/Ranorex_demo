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

namespace DHSAutomation.Keywords
{
    public partial class FilterByServiceTag
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Events'.");
            repo.DellApplicationWebServiceDAWS.Events.Click();
            Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 3s.");
            Delay.Duration(3000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SpanTag'.");
            repo.DellApplicationWebServiceDAWS.SomeSpanTag.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable on 'Search'.");
            repo.DellApplicationWebServiceDAWS.SearchString.PressKeys(TestSuite.Current.Parameters["serviceTag"].ToString());
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click Button 'Filter'.");
            repo.DellApplicationWebServiceDAWS.FilterButton.Click();
            Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 10s.");
            Delay.Duration(10000, false);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{End}'.");
            Keyboard.Press("{End}");
            Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 3s.");
            Delay.Duration(3000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Last'.");
            repo.DellApplicationWebServiceDAWS.Last.Click();
            Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 10s.", new RecordItemIndex(9));
            Delay.Duration(10000, false);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{End}'.");
            Keyboard.Press("{End}");
            Delay.Milliseconds(0);
        }

    }
}