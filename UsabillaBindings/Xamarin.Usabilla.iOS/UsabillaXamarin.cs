using System;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public sealed class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId)
        {
            UsabillaIos.Usabilla.Initialize(appId, null);

            Console.WriteLine("Initializing SDK for iOS appId: {0}", appId);
        }

        public void SendEvent(string anEvent) 
        {
            UsabillaIos.Usabilla.SendEvent(anEvent);
        }

        public void Reset()
        {
            UsabillaIos.Usabilla.ResetCampaignData(null);
        }
    }
}
