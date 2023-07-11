using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Util;
using Xamarin.Usabilla.PCL;
using Com.Usabilla.Sdk.Ubform.Sdk.Entity;
using Com.Usabilla.Sdk.Ubform.Utils;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;

namespace Xamarin.Usabilla
{
    public sealed class UBError : object
    {
        private string _description;
        public UBError(string desc)
        {
            _description = desc;
        }

        public string description
        {
            get
            {
                return _description;
            }
        }
    }

    public sealed class UBFeedbackResult : IXUFormCompletionResult
    {
        private bool _isFormSucceeded;
        private UBFeedback? _result;
        private UBFeedbackError? _error;

        public string? formId => throw new NotImplementedException();

        public bool? isRedirectToAppStoreEnabled => throw new NotImplementedException();

        public UBFeedbackResult(UBError err)
        {
            _isFormSucceeded = false;
            _error = new UBFeedbackError(err);
        }
        public UBFeedbackResult(FeedbackResult res)
        {
            _isFormSucceeded = true;
            _result = new UBFeedback(res);
        }

        public bool isFormSucceeded
        {
            get
            {
                return _isFormSucceeded;
            }

        }

        public IUBFeedback? result
        {
            get
            {
                return _result;
            }
        }

        public IUBError? error
        {
            get
            {
                return _error;
            }
        }
    }

    public class UBFeedback : IUBFeedback
    {
        private FeedbackResult result;

        public UBFeedback(FeedbackResult res)
        {
            result = res;
        }

        public bool Sent
        {
            get
            {
                return result.IsSent;
            }
        }
        public int Rating
        {
            get
            {
                return result.Rating;
            }
        }
        public int AbandonedPageIndex
        {
            get
            {
                return result.AbandonedPageIndex;
            }
        }
    }

    public class UBFeedbackError : IUBError
    {
        private UBError error;

        public UBFeedbackError(UBError err)
        {
            error = err;
        }

        public string description
        {
            get
            {
                return error.description;
            }
        }
    }

    public class UsabillaXamarin : IUsabillaXamarin
    {
        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();

        public AndroidX.AppCompat.App.AppCompatActivity Activity { get; set; }

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

        internal Action<IXUFormCompletionResult> FormCallback { get; set; }
        public string LocalizedStringFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    
        private ClosingObserve campaignClosingObserve;
        private class ClosingObserve : Java.Lang.Object, AndroidX.Lifecycle.IObserver
        {
            public ClosingObserve() { }
           
            public void OnChanged(Java.Lang.Object obj)
            {
                ClosingFormData closingFormData = obj as ClosingFormData;
                if (closingFormData.FormType.Equals(FormType.Campaign))
                {
                    FeedbackResult parcelable = closingFormData.FeedbackResult;
                    var aResponse = new UBFeedbackResult(parcelable);
                    if (Instance.FormCallback != null)
                    {
                        Instance.FormCallback(aResponse);
                    }
                }
            }
        }

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId, Action<IXUFormCompletionResult> result = null)
        {
            UsabillaAndroid.Usabilla.Instance.Initialize(Application.Context, appId);
            UsabillaAndroid.Usabilla.Instance.UpdateFragmentManager(Activity.SupportFragmentManager);
            FormCallback = result;

            campaignClosingObserve = new ClosingObserve();
            UsabillaAndroid.Usabilla.Instance.ClosingData.ObserveForever(campaignClosingObserve);
        }

        public void SendEvent(string anEvent, Action<IXUFormCompletionResult> result)
        {
            UsabillaAndroid.Usabilla.Instance.SendEvent(Application.Context, anEvent);
            FormCallback = result;
        }

        public void Reset()
        {
            UsabillaAndroid.Usabilla.Instance.ResetCampaignData(Application.Context);
        }

        public void ShowFeedbackForm(string formId, Action<IXUFormCompletionResult> result)
        {
            Xamarin.Usabilla.PassiveFeedbackActivity.start(Application.Context, formId, false);
            FormCallback = result;
        }

        public void ShowFeedbackFormWithScreenshot(string formId, Action<IXUFormCompletionResult> result)
        {
            Xamarin.Usabilla.PassiveFeedbackActivity.start(Application.Context, formId, true);
            FormCallback = result;
        }

        public bool Dismiss()
        {
            UsabillaAndroid.Usabilla.Instance.ClosingData.RemoveObserver(campaignClosingObserve);
            return UsabillaAndroid.Usabilla.Instance.Dismiss(Application.Context);
        }

        public void SetDataMasking(IList<string> masks = null, char maskCharacter = 'X')
        {
            masks = masks ?? UsabillaAndroid.UbConstants.DefaultDataMasks;
            UsabillaAndroid.Usabilla.Instance.SetDataMasking(masks, maskCharacter);
        }

        public void PreloadFeedbackForms(IList<string> formIds)
        {
            UsabillaAndroid.Usabilla.Instance.PreloadFeedbackForms(formIds);
        }

        public void RemoveCachedForms()
        {
            UsabillaAndroid.Usabilla.Instance.RemoveCachedForms();
        }
    }
}
