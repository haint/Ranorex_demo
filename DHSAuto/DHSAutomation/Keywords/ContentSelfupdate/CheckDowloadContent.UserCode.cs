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
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using DHSAutomation.Common;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.ContentSelfupdate
{
    public partial class CheckDowloadContent
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }
        
        public void CheckDir ()
        {
        	CultureInfo info = Utils.GetOSLanguage();
        	
        	string shortName = info.Name.Remove(2);
        	Report.Info(shortName);
        	if (Directory.Exists(@"C:\ProgramData\Dell\Dell Help & Support\ContentRepo\Win10\"+shortName)||
        	    Directory.Exists(@"C:\ProgramData\Dell\Dell Help & Support\ContentRepo\Win10\"+info.Name)) Report.Success("Content is downloaded");
        	else 
        	{
        		Report.Failure("Content is not downloaded");
        	}
        }

    }
}