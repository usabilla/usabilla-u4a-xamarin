using System;
namespace Xamarin.Usabilla.PCL
{
    public interface IUsabillaXamarin
    {
        void Initialize(String appId);

        void SendEvent(string anEvent);

        void Reset();
    }
}
