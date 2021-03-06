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

namespace DHSAutomation.Keywords.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckWindowsTroubleShooter recording.
    /// </summary>
    [TestModule("83ed9cfc-86a0-439e-95e4-47fdc367ac9f", ModuleType.Recording, 1)]
    public partial class CheckWindowsTroubleShooter : ITestModule
    {
        /// <summary>
        /// Holds an instance of the DHSAutomation.DHSAutomationRepository repository.
        /// </summary>
        public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

        static CheckWindowsTroubleShooter instance = new CheckWindowsTroubleShooter();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckWindowsTroubleShooter()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckWindowsTroubleShooter Instance
        {
            get { return instance; }
        }

#region Variables

        /// <summary>
        /// Gets or sets the value of variable varDHSAppName.
        /// </summary>
        [TestVariable("ee1811b5-a80d-417d-94eb-7a6ed899b6f4")]
        public string varDHSAppName
        {
            get { return repo.varDHSAppName; }
            set { repo.varDHSAppName = value; }
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

            OpenWindowsUpdate();
            Delay.Milliseconds(0);
            
            Validate_WUTitle();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'WindowsUpdate.Cancel' at Center.", repo.WindowsUpdate.CancelInfo, new RecordItemIndex(2));
            repo.WindowsUpdate.Cancel.Click(200);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(3));
            Delay.Duration(2000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DHSMainWindow.BackButton' at Center.", repo.DHSMainWindow.BackButtonInfo, new RecordItemIndex(4));
            repo.DHSMainWindow.BackButton.Click(200);
            Delay.Milliseconds(200);
            
            OpenHardwareAndDevices();
            Delay.Milliseconds(0);
            
            Validate_HardwareAndDeviceTitle();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'HardwareAndDevices.Cancel' at Center.", repo.HardwareAndDevices.CancelInfo, new RecordItemIndex(7));
            repo.HardwareAndDevices.Cancel.Click(200);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DHSMainWindow.BackButton' at Center.", repo.DHSMainWindow.BackButtonInfo, new RecordItemIndex(8));
            repo.DHSMainWindow.BackButton.Click(200);
            Delay.Milliseconds(200);
            
            OpenWireless();
            Delay.Milliseconds(0);
            
            MergedUserCodeMethod();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'WindowsNetworkDiagnostics.Close' at Center.", repo.WindowsNetworkDiagnostics.CloseInfo, new RecordItemIndex(11));
            repo.WindowsNetworkDiagnostics.Close.Click(200);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DHSMainWindow.BackButton' at Center.", repo.DHSMainWindow.BackButtonInfo, new RecordItemIndex(12));
            repo.DHSMainWindow.BackButton.Click(200);
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
