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
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace TestSuite
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the TestSuiteRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.0")]
    [RepositoryFolder("cb7fea5f-d445-41cc-b2d7-891514fc5a58")]
    public partial class TestSuiteRepository : RepoGenBaseFolder
    {
        static TestSuiteRepository instance = new TestSuiteRepository();

        /// <summary>
        /// Gets the singleton class instance representing the TestSuiteRepository element repository.
        /// </summary>
        [RepositoryFolder("cb7fea5f-d445-41cc-b2d7-891514fc5a58")]
        public static TestSuiteRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public TestSuiteRepository() 
            : base("TestSuiteRepository", "/", null, 0, false, "cb7fea5f-d445-41cc-b2d7-891514fc5a58", ".\\RepositoryImages\\TestSuiteRepositorycb7fea5f.rximgres")
        {
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("cb7fea5f-d445-41cc-b2d7-891514fc5a58")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.0")]
    public partial class TestSuiteRepositoryFolders
    {
    }
#pragma warning restore 0436
}