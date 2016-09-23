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
    public partial class ContentDownloadComplete
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }
        
        public void WaitContentDownload ()
        {
        	
        	string line;
        	int i =0;
        	do{
        		using (StreamReader sr = new StreamReader(@"C:\ProgramData\Dell\Dell Help & Support\DellAgent.MDLC.00.log"))
				{
					line = sr.ReadToEnd();	
				}
        		
        		if (i>100) break;
        		Report.Info("Wait for download complete");
        		Delay.Seconds(10);
        		i++;
        	}while (!line.Contains("ContentU: The manifest files have been successfully applied and the temporary files are deleting"));
        	if (i<100) Report.Success("New content is downloaded successfully");
        	else Report.Failure("New content is not downloaded successfully");
        }
    

    }
}