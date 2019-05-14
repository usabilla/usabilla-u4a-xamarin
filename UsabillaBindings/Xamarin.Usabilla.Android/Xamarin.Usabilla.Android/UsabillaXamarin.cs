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

        public bool DebugEnabled
        {
            get => UsabillaAndroid.Usabilla.Instance.DebugEnabled;
            set => UsabillaAndroid.Usabilla.Instance.DebugEnabled = value;
        }

        public IDictionary<string, string> CustomVariables
        {
            get
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (KeyValuePair<string, Java.Lang.Object> entry in UsabillaAndroid.Usabilla.Instance.CustomVariables)
                {
                    dictionary.Add(entry.Key, entry.Value.ToString());
                }
                return dictionary;
            }
            set
            {
                Dictionary<string, Java.Lang.Object> dictionary = new Dictionary<string, Java.Lang.Object>();
                foreach (KeyValuePair<string, string> entry in value)
                {
                    dictionary.Add(entry.Key, entry.Value);
                }
                UsabillaAndroid.Usabilla.Instance.CustomVariables = dictionary;
            }
        }

        public IList<string> DefaultMasks => throw new NotImplementedException();

        internal Action<XUFormLoadResult> FormCallback { get; set; }

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
            PassiveFeedbackActivity.start(Application.Context, formId);
            FormCallback = result;
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
