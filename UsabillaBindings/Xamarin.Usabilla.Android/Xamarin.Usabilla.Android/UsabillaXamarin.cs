using System;
using System.Collections.Generic;
using Android.App;
using Android.Util;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();
        public bool DebugEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, string> CustomVariables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<string> DefaultMasks => throw new NotImplementedException();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId)
        {
            Log.Debug("UBInfo", "Initializing SDK");
            UsabillaAndroid.Usabilla.Instance.Initialize(Application.Context, appId);
        }

        public void SendEvent(string anEvent)
        {
            Log.Debug("UBInfo", anEvent + " is sent");
            UsabillaAndroid.Usabilla.Instance.SendEvent(Application.Context, anEvent);
        }

        public void Reset()
        {
            Log.Debug("UBInfo", "reset");
            UsabillaAndroid.Usabilla.Instance.ResetCampaignData(Application.Context);
        }

        public void ShowFeedbackForm(string formId, Action<XUFormLoadResult> result)
        {
            Log.Debug("UBInfo", "show " + formId);
        }

        public void ShowFeedbackFormWithScreenshot(string formId, Action<XUFormLoadResult> result)
        {
            throw new NotImplementedException();
        }

        public bool Dismiss()
        {
            throw new NotImplementedException();
        }

        public void SetDataMasking(IList<string> masks, char maskCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
