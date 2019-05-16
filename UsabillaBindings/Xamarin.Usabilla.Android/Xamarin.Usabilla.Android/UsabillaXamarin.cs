using System;
using System.Collections.Generic;
using Android.App;
using Android.Support.V7.App;
using Android.Util;
using Xamarin.Usabilla.PCL;

namespace Xamarin.Usabilla
{
    public class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        public AppCompatActivity Activity { get; set; }

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

        public IList<string> DefaultMasks => UsabillaAndroid.UbConstants.DefaultDataMasks;

        internal Action<XUFormLoadResult> FormCallback { get; set; }

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId)
        {
            Log.Debug("UBInfo", "Initializing SDK");
            UsabillaAndroid.Usabilla.Instance.Initialize(Application.Context, appId);
            UsabillaAndroid.Usabilla.Instance.UpdateFragmentManager(Activity.SupportFragmentManager);
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
            PassiveFeedbackActivity.start(Application.Context, formId, false);
            FormCallback = result;
        }

        public void ShowFeedbackFormWithScreenshot(string formId, Action<XUFormLoadResult> result)
        {
            PassiveFeedbackActivity.start(Application.Context, formId, true);
            FormCallback = result;
        }

        public bool Dismiss()
        {
            return UsabillaAndroid.Usabilla.Instance.Dismiss(Application.Context);
        }

        public void SetDataMasking(IList<string> masks = null, char maskCharacter = 'X')
        {
            masks = masks ?? UsabillaAndroid.UbConstants.DefaultDataMasks;
            UsabillaAndroid.Usabilla.Instance.SetDataMasking(masks, maskCharacter);
        }
    }
}
