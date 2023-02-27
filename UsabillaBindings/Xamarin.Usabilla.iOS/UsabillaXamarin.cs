using System;
using System.Collections.Generic;
using Xamarin.Usabilla.PCL;
using UIKit;
using Foundation;
using UsabillaIos;

namespace Xamarin.Usabilla
{
    public sealed class UBFeedbackResult : IXUFormCompletionResult
    {
        private string? _formId;
        private UBFeedback? _result;
        private UBFeedbackError? _error;
        private bool? _isRedirectToStoreEnabled;
        private bool? _isFormSucceeded;


        public UBFeedbackResult(UBError err)
        {
            _isFormSucceeded = (_isRedirectToStoreEnabled == null) ? false : true;
            _error = new UBFeedbackError(err);
        }
        public UBFeedbackResult(FeedbackResult res, bool isRedirectEnabled)
        {
            _isFormSucceeded = (_isRedirectToStoreEnabled == null) ? false : true;
            _result = new UBFeedback(res);
            _isRedirectToStoreEnabled = isRedirectEnabled;
        }

        public UBFeedbackResult(string formID, FeedbackResult res, bool isRedirectEnabled)
        {
            _isFormSucceeded = (_isRedirectToStoreEnabled == null) ? false : true;
            _formId = formID;
            _result = new UBFeedback(res);
            _isRedirectToStoreEnabled = isRedirectEnabled;
        }

        public bool isFormSucceeded
        {
            get
            {
                return (_isFormSucceeded == null) ? false : true;
            }

        }
        public string? formId
        {
            get
            {
                return _formId;
            }
        }

        public IUBFeedback? result
        {
            get
            {
                return _result;
            }
        }

        public bool? isRedirectToAppStoreEnabled
        {
            get
            {
                return _isRedirectToStoreEnabled;
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
                return result.Sent;
            }
        }
        public int Rating
        {
            get
            {
                return int.Parse(result.Rating);
            }
        }
        public int AbandonedPageIndex
        {
            get
            {
                return int.Parse(result.AbandonedPageIndex);
            }
        }
    }

    public sealed class UsabillaXamarin : IUsabillaXamarin
    {

        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();
        private CustomUsabillaDelegate aDelegate = new CustomUsabillaDelegate();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId, Action<IXUFormCompletionResult> result = null)
        {
            UsabillaIos.Usabilla.Initialize(appId, null);
            UsabillaIos.Usabilla.Delegate = aDelegate;
            if (result != null)
            {
                aDelegate.Result = result;
            }
            
        }

        public void SendEvent(string anEvent, Action<IXUFormCompletionResult> result)
        {
            aDelegate.Result = result;
            UsabillaIos.Usabilla.SendEvent(anEvent);
        }

        public void Reset()
        {
            UsabillaIos.Usabilla.ResetCampaignData();
        }

        public void ShowFeedbackForm(string formId, Action<IXUFormCompletionResult> result)
        {
            aDelegate.Result = result;
            UsabillaIos.Usabilla.LoadFeedbackForm(formId, null);
        }

        public void ShowFeedbackFormWithScreenshot(string formId, Action<IXUFormCompletionResult> result)
        {
            aDelegate.Result = result;
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController.View;
            UIImage image = UsabillaIos.Usabilla.TakeScreenshot(vc);
            UsabillaIos.Usabilla.LoadFeedbackForm(formId, image);
        }

        public IDictionary<string, string> CustomVariables
        {
            get
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (KeyValuePair<NSObject, NSObject> entry in UsabillaIos.Usabilla.CustomVariables)
                {
                    dictionary.Add(entry.Key.ToString(), entry.Value.ToString());
                }
                return dictionary;
            }

            set
            {
                NSMutableDictionary<NSString, NSString> dictionary = new NSMutableDictionary<NSString, NSString>();
                foreach (KeyValuePair<string, string> entry in value)
                {
                    dictionary.Add((NSString)entry.Key, (NSString)entry.Value);
                }

                NSDictionary<NSString, NSString> aDictionary = new NSDictionary<NSString, NSString>(dictionary.Keys, dictionary.Values);
                if (aDictionary != null)
                {
                    UsabillaIos.Usabilla.CustomVariables = aDictionary;
                }
            }
        }

        public bool Dismiss()
        {
            return UsabillaIos.Usabilla.Dismiss();
        }

        public void SetDataMasking(IList<string> masks = null, char maskCharacter = 'X')
        {
            string[] stringArray = null;
            if (masks != null)
            {
                stringArray = new string[masks.Count];
                masks.CopyTo(stringArray, 0);
            }
            UsabillaIos.Usabilla.SetDataMasking(stringArray, maskCharacter);
        }

        public IList<string> DefaultMasks
        {
            get
            {
                string[] masks = UsabillaIos.Usabilla.DefaultDataMasks;
                List<string> list = new List<string>(masks);
                return list;
            }
        }

        public bool DebugEnabled
        {
            get
            {
                return UsabillaIos.Usabilla.DebugEnabled;
            }

            set
            {
                UsabillaIos.Usabilla.DebugEnabled = value;
            }
        }

        public string LocalizedStringFile
        {
            get
            {
                return UsabillaIos.Usabilla.LocalizedStringFile;
            }

            set
            {
                UsabillaIos.Usabilla.LocalizedStringFile = value;
            }
        }

        public void PreloadFeedbackForms(IList<string> formIds)
        {
            string[] formIdArray = null;
            if (formIds != null)
            {
                formIdArray = new string[formIds.Count];
                formIds.CopyTo(formIdArray, 0);
                UsabillaIos.Usabilla.PreloadFeedbackForms(formIdArray);
            }
        }

        public void RemoveCachedForms()
        {
            UsabillaIos.Usabilla.RemoveCachedForms();
        }

        /*
         * Private delegate implementation
         */
        private class CustomUsabillaDelegate : UsabillaIos.UsabillaDelegate
        {
            private Action<IXUFormCompletionResult> result;
            private UINavigationController currentForm;
            public Action<IXUFormCompletionResult> Result { get => result; set => result = value; }

            public override void CampaignDidClose(FeedbackResult withFeedbackResult, bool isRedirectToAppStoreEnabled)
            {
                var obj = withFeedbackResult;
                var aResponse = new UBFeedbackResult(obj, isRedirectToAppStoreEnabled);
                if (result != null)
                {
                    result.Invoke(aResponse);
                }                
            }

            public override void FormDidClose(string formID, FeedbackResult[] withFeedbackResults, bool isRedirectToAppStoreEnabled)
            {
                var obj = withFeedbackResults[0];
                var aResponse = new UBFeedbackResult(formID, obj, isRedirectToAppStoreEnabled);
                result.Invoke(aResponse);
            }

            public override void FormDidFailLoading(UBError error)
            {
                var aResponse = new UBFeedbackResult(error);
                result.Invoke(aResponse);
            }

            public override void FormDidLoad(UINavigationController form)
            {
                currentForm = form;
                presentForm();
            }

            public override void FormWillClose(UINavigationController form, string formID, FeedbackResult[] withFeedbackResult, bool isRedirectToAppStoreEnabled)
            {
                //throw new NotImplementedException();
            }

            private void presentForm()
            {
                if (currentForm != null)
                {
                    var window = UIApplication.SharedApplication.KeyWindow;
                    var vc = window.RootViewController;
                    currentForm.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
                    vc.PresentViewController(currentForm, true, null);
                    return;
                }
            }

            public override void feedbackResultSubmittedWithUserResponse(NSData data)
            {
                
            }
        }
    }
}
