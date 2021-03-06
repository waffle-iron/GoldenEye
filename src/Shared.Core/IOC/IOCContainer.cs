﻿using Ninject;
using System.Collections.Generic;

namespace GoldenEye.Shared.Core.IOC
{
    public static class IOCContainer
    {
        private static IKernel _kernel;

        public static void Initialize(IKernel kernel)
        {
            _kernel = kernel;
        }

        public static T Get<T>()
        {
            try
            {
                return _kernel.Get<T>();
            }
            catch (ActivationException)
            {
                return default(T);
            }
        }

        public static IEnumerable<T> GetAll<T>()
        {
            try
            {
                return _kernel.GetAll<T>();
            }
            catch (ActivationException)
            {
                return new List<T>();
            }
        }
    }
}