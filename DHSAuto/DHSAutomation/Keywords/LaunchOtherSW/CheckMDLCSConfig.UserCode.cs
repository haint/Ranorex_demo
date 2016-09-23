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
using System.IO;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace DHSAutomation.Keywords.LaunchOtherSW
{
    public partial class CheckMDLCSConfig
    {

        private void Init()
        {
            
        }
        
        public void CheckFile ()
        {
        	string fileContent = "";
        	string filePath =@"C:\Program Files\Dell\Dell Help & Support\MDLCSvc.exe.config";
        	if (File.Exists(filePath))
        	{
        		Report.Success("MDLCSvc.exe.config found at default location");
        		
    			fileContent = File.ReadAllText(filePath);
        		
        		
        		if (fileContent.Contains("WarrantyWebServiceKey")) 
        		{
        			Report.Success("WarrantyWebServiceKey found");
        			if (fileContent.Contains("8822ebc870c5d9a30e1c8045e908e829")) Report.Success("WarrantyWebServiceKey value is correct");
        			else Report.Failure("WarrantyWebServiceKey value is not correct");
        			
        			
        		}else Report.Failure("WarrantyWebServiceKey not found");
        		
        		if (fileContent.Contains("WarrantyWebServiceHost")) 
        		{
        			Report.Success("WarrantyWebServiceHost found");
        			if (fileContent.Contains("https://api.dell.com")) Report.Success("WarrantyWebServiceHost value is correct");
        			else Report.Failure("WarrantyWebServiceHost value is not correct");
        		}else Report.Failure("WarrantyWebServiceHost not found");
        		
        		
        		
        	}else Report.Failure("MDLCSvc.exe.config not found at default location");
        }

    }
}