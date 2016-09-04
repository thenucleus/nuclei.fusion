//-----------------------------------------------------------------------
// <copyright company="TheNucleus">
// Copyright (c) TheNucleus. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENCE.md file in the project root for full license information.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Nuclei.Fusion.Samples
{
    [TestFixture]
    public sealed class FusionHelperSample
    {
        private static string GetAssemblyPath(Assembly assembly)
        {
            var codebase = assembly.CodeBase;
            var uri = new Uri(codebase);
            return uri.LocalPath;
        }

        [Test]
        public void LocateAssemblyOnAssemblyLoadFailure()
        {
            var assemblies = new Dictionary<string, Assembly>
                {
                    { GetAssemblyPath(typeof(string).Assembly), typeof(string).Assembly },
                    { GetAssemblyPath(typeof(SetUpAttribute).Assembly), typeof(SetUpAttribute).Assembly },
                    { GetAssemblyPath(Assembly.GetExecutingAssembly()), Assembly.GetExecutingAssembly() },
                };

            Func<IEnumerable<string>> assemblyNameResolver = () => assemblies.Keys.ToArray();

            var helper = new FusionHelper(assemblyNameResolver);
            helper.AssemblyLoader = (assemblyPath) =>
                {
                    return assemblies[assemblyPath];
                };

            AppDomain.CurrentDomain.AssemblyResolve += helper.LocateAssemblyOnAssemblyLoadFailure;

            var name = Assembly.GetExecutingAssembly().GetName().Name;
            var result = helper.LocateAssemblyOnAssemblyLoadFailure(null, new ResolveEventArgs(name));
            Assert.AreSame(Assembly.GetExecutingAssembly(), result);
        }
    }
}
