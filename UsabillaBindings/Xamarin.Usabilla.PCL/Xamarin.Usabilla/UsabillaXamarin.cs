using System;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void initialize(string appId, Func<object> callback)
        {
            throw new NotImplementedException("Dummy Implementation for Bait And Switch Trick and should not be called");
        }
    }
}
