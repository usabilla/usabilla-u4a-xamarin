﻿using System;
using Android.Util;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public sealed class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void initialize(string appId, Func<object> callback)
        {
            Log.Debug("UBInfo", "Initializing SDK");
        }
    }
}
