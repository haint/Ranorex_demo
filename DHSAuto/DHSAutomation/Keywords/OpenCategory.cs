﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
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
using Ranorex.Core.Repository;

namespace DHSAutomation.Keywords
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenCategory recording.
    /// </summary>
    [TestModule("b0d26b47-9139-48d9-ba9d-4373e09c484a", ModuleType.Recording, 1)]
    public partial class OpenCategory : ITestModule
    {
        /// <summary>
        /// Holds an instance of the DHSAutomation.DHSAutomationRepository repository.
        /// </summary>
        public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

        static OpenCategory instance = new OpenCategory();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenCategory()
        {
            url = "http://www.dell.com/support/home/vn/en/vnbsdt1/product-support/servicetag/5RQTQX1";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenCategory Instance
        {
            get { return instance; }
        }

#region Variables

        string _url;

        /// <summary>
        /// Gets or sets the value of variable url.
        /// </summary>
        [TestVariable("b6269803-8add-4077-a81f-5c2673455f84")]
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.0")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.0")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DHS_HaiNT21_Form.ClickGetAround' at 111;68.", repo.DHS_HaiNT21_Form.ClickGetAroundInfo, new RecordItemIndex(0));
            repo.DHS_HaiNT21_Form.ClickGetAround.Click("111;68");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DHS_HaiNT21_Form.GetMoreSupportTxt' at CenterRight.", repo.DHS_HaiNT21_Form.GetMoreSupportTxtInfo, new RecordItemIndex(1));
            repo.DHS_HaiNT21_Form.GetMoreSupportTxt.Click(Location.CenterRight);
            Delay.Milliseconds(200);
            
            checkIE();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Get Value", "Getting attribute 'Href' from item 'DHS_HaiNT21_Page.Diagnostics' and assigning its value to variable 'url'.", repo.DHS_HaiNT21_Page.DiagnosticsInfo, new RecordItemIndex(3));
            url = repo.DHS_HaiNT21_Page.Diagnostics.Element.GetAttributeValueText("Href");
            Delay.Milliseconds(0);
            
            CheckLanguage();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IE.Close' at 14;13.", repo.IE.CloseInfo, new RecordItemIndex(5));
            repo.IE.Close.Click("14;13");
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
