using System;
namespace Xamarin.Usabilla.PCL
{
    public interface IUsabillaXamarin
    {
        void initialize(String appId, Func<object> callback);
    }
}
