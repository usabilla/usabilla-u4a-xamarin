using System;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId)
        {
            throw new NotImplementedException("Dummy Implementation for Initialize and should not be called");
        }
        public void SendEvent(string anEvent)
        {
            throw new NotImplementedException("Dummy Implementation for SendEvent and should not be called");
        }
        public void Reset()
        {
            throw new NotImplementedException("Dummy Implementation for Reset and should not be called");
        }
    }
}
