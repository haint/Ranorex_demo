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

namespace DHSAutomation.Keywords.Network
{
    public partial class OpenNetworkConnectionPanel
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void MergedUserCodeMethod()
        {
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'Windows + R'.");
            Keyboard.Press("{LWin down}r{LWin up}");
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.");
            Delay.Duration(1000, false);
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'ncpa.cpl' and Press Enter.");
            Keyboard.Press("ncpa.cpl{Return}");
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 3s.");
            Delay.Duration(3000, false);
        }

    }
}