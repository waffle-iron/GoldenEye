﻿using System;
using System.Globalization;
using System.Threading;

namespace GoldenEye.Shared.Core.Extensions.Threading
{
    public static class ThreadExtensions
    {
        public static T WithUiCulture<T>(this Thread currentThread, string culture, Func<T> doAction)
        {
            //var currentUiCulture = currentThread.;

            //currentThread.CurrentUICulture = new CultureInfo(culture);

            //T returnValue = doAction();

            //currentThread.CurrentUICulture = currentUiCulture;

            //return returnValue;
            throw new NotImplementedException();
        }
    }
}
