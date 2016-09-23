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
    ///The CheckSplashScreen recording.
    /// </summary>
    [TestModule("af906c39-24ea-472c-be12-2ceabf51664a", ModuleType.Recording, 1)]
    public partial class CheckSplashScreen : ITestModule
    {
        /// <summary>
        /// Holds an instance of the DHSAutomation.DHSAutomationRepository repository.
        /// </summary>
        public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

        static CheckSplashScreen instance = new CheckSplashScreen();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckSplashScreen()
        {
            versionApp = "2.2.26.0";
            isConfirmManualSteps = "True";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckSplashScreen Instance
        {
            get { return instance; }
        }

#region Variables

        string _versionApp;

        /// <summary>
        /// Gets or sets the value of variable versionApp.
        /// </summary>
        [TestVariable("6e6c0fe6-f9e1-4909-985e-55fddbdcf71f")]
        public string versionApp
        {
            get { return _versionApp; }
            set { _versionApp = value; }
        }

        string _isConfirmManualSteps;

        /// <summary>
        /// Gets or sets the value of variable isConfirmManualSteps.
        /// </summary>
        [TestVariable("0184621d-8d8f-4181-9e26-9c07c41f015d")]
        public string isConfirmManualSteps
        {
            get { return _isConfirmManualSteps; }
            set { _isConfirmManualSteps = value; }
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

            ValidationSplashScreen();
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
