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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.ContentSelfupdate
{
    public partial class CompleteRemove
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {

        }
        
        public void RemoveConfig ()
        {
        	if (File.Exists(@"C:\ProgramData\Dell\Dell Help & Support\DellAgent.MDLC.00.log")) File.Delete(@"C:\ProgramData\Dell\Dell Help & Support\DellAgent.MDLC.00.log");
        	if (File.Exists(@"C:\ProgramData\Dell\Dell Help & Support\DHSSrv.exe.config")) File.Delete(@"C:\ProgramData\Dell\Dell Help & Support\DHSSrv.exe.config");
        }
    }
}