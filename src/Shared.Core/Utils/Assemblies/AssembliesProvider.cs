using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace GoldenEye.Shared.Core.Utils.Assemblies
{
    public static class AssembliesProvider
    {
        public static RuntimeLibrary[] GetAll()
        {
            return DependencyContext.Default.RuntimeLibraries.ToArray();
        }
    }
}
