using System;
using System.Collections.Generic;
using Xamarin.Usabilla.PCL;
using UIKit;
using Foundation;
using UsabillaIos;

namespace Xamarin.Usabilla
{
    public sealed class UsabillaXamarin : IUsabillaXamarin
    {

        public static UsabillaXamarin Instance { get; } = new UsabillaXamarin();
        private CustomUsabillaDelegate aDelegate = new CustomUsabillaDelegate();

        static UsabillaXamarin() { }
        private UsabillaXamarin() { }

        public void Initialize(string appId)
        {
            UsabillaIos.Usabilla.Initialize(appId, null);
            UsabillaIos.Usabilla.Delegate = aDelegate;
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


        public void ShowFeedbackForm(string formId, Action<XUFormLoadResult> result)
        {
            aDelegate.Result = result;
            UsabillaIos.Usabilla.LoadFeedbackForm(formId, null);

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
                NSMutableDictionary<NSString, NSObject> dictionary = new NSMutableDictionary<NSString, NSObject>();
                foreach (KeyValuePair<string, string> entry in value)
                {
                    NSString val = new NSString(entry.Value);
                    NSObject obj = NSObject.FromObject(val);
                   dictionary.Add(new NSString(entry.Key), obj);
                }

                NSDictionary<NSString, NSObject> aDictionary = new NSDictionary<NSString, NSObject>(dictionary.Keys, dictionary.Values);
                if (aDictionary != null)
                {
                    UsabillaIos.Usabilla.CustomVariables = aDictionary;
                }

            }
        }



        /*
         * Private delegate implementation
         */

        private class CustomUsabillaDelegate : UsabillaIos.UsabillaDelegate
        {
            private Action<XUFormLoadResult> result;
            private UINavigationController currentForm;
            public Action<XUFormLoadResult> Result { get => result; set => result = value; }

            public override void CampaignDidClose(FeedbackResult feedbackResult, bool isRedirectToAppStoreEnabled)
            {
                throw new NotImplementedException();
            }

            public override void FormDidClose(string formID, NSArray feedbackResults, bool isRedirectToAppStoreEnabled)
            {
                throw new NotImplementedException();
            }

            public override void FormDidFailLoading(UBError form)
            {
                result.Invoke(XUFormLoadResult.FormDidFailLoading);
            }

            public override void FormDidLoad(UINavigationController form)
            {
                currentForm = form;
                presentForm();
            }

            public override void FormWillClose(UINavigationController form, string formID, NSArray feedbackResults, bool isRedirectToAppStoreEnabled)
            {
                throw new NotImplementedException();
            }

            private void presentForm() 
            {
                if (currentForm != null)
                {
                    var window = UIApplication.SharedApplication.KeyWindow;
                    var vc = window.RootViewController;
                    vc.PresentViewController(currentForm, true, null);
                    result.Invoke(XUFormLoadResult.FormDidSucceedLoading);
                    return;
                }

                result.Invoke(XUFormLoadResult.FormDidFailLoading);
                            
            }

        }

    }
}
