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

namespace DHSAutomation.Keywords.TelemetryEventsCheckFromDAWS
{
    public partial class OpenAndCloseDHSRepeatTwoTimes
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
        	Keywords.TelemetryEventsCheckFromDAWS.OpenDellHelpAndSupport.Start();
        	Keywords.General.CloseDHS.Start();
        	
        	Keywords.TelemetryEventsCheckFromDAWS.OpenDellHelpAndSupport.Start();
        	Keywords.General.CloseDHS.Start();
        }

    }
}