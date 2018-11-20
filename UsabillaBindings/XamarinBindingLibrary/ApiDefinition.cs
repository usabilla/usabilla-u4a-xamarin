using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace UsabillaNative
{
	[BaseType(typeof(NSObject), Name = "Usabilla")]
	interface Usabilla
	{
        [Static, Export("initializeWithAppID:completion:")]
        void Initialize([NullAllowed]string appId, [NullAllowed]Action completion);

        [Static, Export("customVariables")]
        NSDictionary<NSString, NSObject> CustomVariables { get; set; }

        [Static, Export("localizedStringFile")]
        String LocalizedStringFile { get; set; }

        [Static, Export("theme")]
        UsabillaTheme Theme { get; set; }

        [Static, Export("dismissAutomatically")]
        bool DismissAutomatically { get; set; }

        [Static, Export("canDisplayCampaigns")]
        bool CanDisplayCampaigns { get; set; }

        [Static, Export("debugEnabled")]
        bool debugEnabled { get; set; }

        [Static, Export("sendEvent:")]
        void SendEvent(string eventName);

        [Static, Export("removeCachedForms")]
        void RemoveCachedForms();

        [Static, Export("resetCampaignData:")]
        void ResetCampaignData(Action completion);

        [Static, Export("preloadFeedbackForms:")]
        void PreloadFeedbackForms(String[] formIDs);

        [Static, Export("loadFeedbackForm:screenshot:theme:")]
        void LoadFeedbackForm(string formID, [NullAllowed]UIImage image, IntPtr theme);

        [Static, Export("takeScreenshot:")]
        [NullAllowed] UIImage TakeScreenshot(UIView view);

    }

    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface UsabillaDelegate
    {
        [Export("formDidLoad:")]
        void FormDidLoad(UINavigationController form);

        [Export("formDidFailLoading:")]
        void FormDidFailLoading(UBError form);

        [Export("formDidClose:results:isRedirectToAppStoreEnabled")]
        void FormDidClose(String formID, NSArray feedbackResults, bool isRedirectToAppStoreEnabled);

        //func formWillClose(form: UINavigationController, formID: String, withFeedbackResults results: [FeedbackResult], isRedirectToAppStoreEnabled: Bool)
        [Export("formWillClose:formID:results:isRedirectToAppStoreEnabled:")]
        void FormWillClose(UINavigationController form, String formID, NSArray feedbackResults, bool isRedirectToAppStoreEnabled);

        //func campaignDidClose(withFeedbackResult result: FeedbackResult, isRedirectToAppStoreEnabled: Bool)
        [Export("campaignDidClose:isRedirectToAppStoreEnabled:")]
        void CampaignDidClose(FeedbackResult feedbackResult, bool isRedirectToAppStoreEnabled);
    }
}
