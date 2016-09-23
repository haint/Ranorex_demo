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
    ///The CheckTabsShowUp recording.
    /// </summary>
    [TestModule("06a2e3da-cd02-4522-97d8-f539e7c7d0e9", ModuleType.Recording, 1)]
    public partial class CheckTabsShowUp : ITestModule
    {
        /// <summary>
        /// Holds an instance of the DHSAutomation.DHSAutomationRepository repository.
        /// </summary>
        public static DHSAutomation.DHSAutomationRepository repo = DHSAutomation.DHSAutomationRepository.Instance;

        static CheckTabsShowUp instance = new CheckTabsShowUp();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckTabsShowUp()
        {
            numTabs = "3";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckTabsShowUp Instance
        {
            get { return instance; }
        }

#region Variables

        string _numTabs;

        /// <summary>
        /// Gets or sets the value of variable numTabs.
        /// </summary>
        [TestVariable("951a68bd-5534-496a-b498-fea5f5f23548")]
        public string numTabs
        {
            get { return _numTabs; }
            set { _numTabs = value; }
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

            CheckAllTabs(ValueConverter.ArgumentFromString<int>("totalTab", numTabs));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}