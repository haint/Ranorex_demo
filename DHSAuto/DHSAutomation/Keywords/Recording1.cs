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
    ///The Recording1 recording.
    /// </summary>
    [TestModule("47d2bb0f-dcbc-47f4-9e16-4b69150de92b", ModuleType.Recording, 1)]
    public partial class Recording1 : ITestModule
    {
        /// <summary>
        /// Holds an instance of the DHSAutomation.DHSAutomationRepository repository.
        /// </summary>
        public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

        static Recording1 instance = new Recording1();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Recording1()
        {
            testVariable = "xxxxxx";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Recording1 Instance
        {
            get { return instance; }
        }

#region Variables

        string _testVariable;

        /// <summary>
        /// Gets or sets the value of variable testVariable.
        /// </summary>
        [TestVariable("a0cbe63e-ef51-4c2b-8bf6-b64c85b88595")]
        public string testVariable
        {
            get { return _testVariable; }
            set { _testVariable = value; }
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

            Mouse_Click_Start();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Start.ContainerHash' at Center.", repo.Start.ContainerHashInfo, new RecordItemIndex(1));
            repo.Start.ContainerHash.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Start.TextD' at 6;19.", repo.Start.TextDInfo, new RecordItemIndex(2));
            repo.Start.TextD.Click("6;19");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Start.AppsList' at 4;4.", repo.Start.AppsListInfo, new RecordItemIndex(3));
            repo.Start.AppsList.Click(new Location(AppsList_Screenshot5, "4;4", AppsList_Screenshot5_Options));
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'Start.AppsList' at 10;8.", repo.Start.AppsListInfo, new RecordItemIndex(4));
            repo.Start.AppsList.Click(new Location(AppsList_Screenshot6, "10;8", AppsList_Screenshot6_Options));
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
        CompressedImage AppsList_Screenshot5
        { get { return repo.Start.AppsListInfo.GetScreenshot5(new Rectangle(30, 47, 8, 8)); } }

        Imaging.FindOptions AppsList_Screenshot5_Options
        { get { return Imaging.FindOptions.Default; } }

        CompressedImage AppsList_Screenshot6
        { get { return repo.Start.AppsListInfo.GetScreenshot6(new Rectangle(31, 81, 18, 18)); } }

        Imaging.FindOptions AppsList_Screenshot6_Options
        { get { return Imaging.FindOptions.Default; } }

#endregion
    }
#pragma warning restore 0436
}
