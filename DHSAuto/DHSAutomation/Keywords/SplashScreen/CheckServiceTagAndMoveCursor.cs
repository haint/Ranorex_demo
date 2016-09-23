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

namespace DHSAutomation.Keywords.SplashScreen
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckServiceTagAndMoveCursor recording.
    /// </summary>
    [TestModule("639bdc57-b6f2-4044-94c7-3a15ba4751e0", ModuleType.Recording, 1)]
    public partial class CheckServiceTagAndMoveCursor : ITestModule
    {
        /// <summary>
        /// Holds an instance of the DHSAutomation.DHSAutomationRepository repository.
        /// </summary>
        public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

        static CheckServiceTagAndMoveCursor instance = new CheckServiceTagAndMoveCursor();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckServiceTagAndMoveCursor()
        {
            isConfirmManualSteps = "True";
            varPlatformName = "Inspiron 3558";
            varServiceTag = "";
            varServiceCode = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckServiceTagAndMoveCursor Instance
        {
            get { return instance; }
        }

#region Variables

        string _isConfirmManualSteps;

        /// <summary>
        /// Gets or sets the value of variable isConfirmManualSteps.
        /// </summary>
        [TestVariable("d555a642-e6cb-4df2-9e56-b75d6d822b45")]
        public string isConfirmManualSteps
        {
            get { return _isConfirmManualSteps; }
            set { _isConfirmManualSteps = value; }
        }

        string _varPlatformName;

        /// <summary>
        /// Gets or sets the value of variable varPlatformName.
        /// </summary>
        [TestVariable("4e413576-e3ba-4850-a2c7-9b509c437774")]
        public string varPlatformName
        {
            get { return _varPlatformName; }
            set { _varPlatformName = value; }
        }

        string _varServiceTag;

        /// <summary>
        /// Gets or sets the value of variable varServiceTag.
        /// </summary>
        [TestVariable("f887b710-c313-409c-acfa-31201869890e")]
        public string varServiceTag
        {
            get { return _varServiceTag; }
            set { _varServiceTag = value; }
        }

        string _varServiceCode;

        /// <summary>
        /// Gets or sets the value of variable varServiceCode.
        /// </summary>
        [TestVariable("c0b3644d-f377-4aa2-ae53-ffcb35f28689")]
        public string varServiceCode
        {
            get { return _varServiceCode; }
            set { _varServiceCode = value; }
        }

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

            CheckServiceTagInfo();
            Delay.Milliseconds(0);
            
            Mouse_Move_ServiceTagTooltip();
            Delay.Milliseconds(0);
            
            ValidateServiceTagTooltip();
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}