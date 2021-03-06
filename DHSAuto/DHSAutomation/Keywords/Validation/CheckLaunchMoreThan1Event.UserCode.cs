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

namespace DHSAutomation.Keywords.Validation
{
    public partial class CheckLaunchMoreThan1Event
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void CheckLaunchMoreThan1()
        {
        	//TODO search for the last item match
        	IList<TrTag> trList = repo.DellApplicationWebServiceDAWS.Self.Find<TrTag>(@".//div[#'daws-body']/table//td[@innertext~'Learning Center']/following-sibling::td[@innertext~'CustomEvent']/parent::tr");
        	try{
        	TrTag lastTr = trList[trList.Count - 1];
        	lastTr.MoveTo();
        	ATag link = lastTr.FindSingle<ATag>("./td[1]/a");
        	link.MoveTo();
        	link.Click(Location.UpperRight);
        	
        	DdTag ddtag = repo.DellApplicationWebServiceDAWS.DtTagAdditionalData1.FindSingle<DdTag>("./following-sibling::dd[][1]");
        	ddtag.MoveTo();
        	string ddtext = ddtag.InnerText.Trim();
        	Validate.AreEqual(ddtext, "Launch > 1", "Check Custom Event has AdditionalData1 = Launch > 1, actual = {0}, expect = {1}");
        	}catch{
        		Report.Failure("No event 'CustomEvent' sented.");
        	}
        	Delay.Seconds(5);
        }

    }
}