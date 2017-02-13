#if net45
using Ninject;
#endif
using System.Collections.Generic;

namespace GoldenEye.Shared.Core.IOC
{
    public static class IOCContainer
    {
#if NET45 && NET451 && NET452
        private static IKernel _kernel;

        public static void Initialize(IKernel kernel)
        {
            _kernel = kernel;
        }
#endif

        public static T Get<T>()
        {
#if NET45 && NET451 && NET452
            try
            {
                return _kernel.Get<T>();
            }
            catch (ActivationException)
            {
                return default(T);
            }
#elif NETSTANDARD1_5
            return default(T);
#endif
        }

        public static IEnumerable<T> GetAll<T>()
        {
#if NET_45
            try
            {
                return _kernel.GetAll<T>();
            }
            catch (ActivationException)
            {
                return new List<T>();
            }
#elif NETSTANDARD1_5
            return new List<T>();
#endif
        }
    }
}