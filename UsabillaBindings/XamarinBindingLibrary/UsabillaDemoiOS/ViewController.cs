using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using UsabillaIos;
using System.Threading.Tasks;

namespace UsabillaDemoiOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
            
                NSDictionary<NSString, NSObject> dict = new NSDictionary<NSString, NSObject>(new NSString("tesr"), NSObject.FromObject("xamarint"));

                Usabilla.Initialize("[YOU APP ID HERE]", null);
                Usabilla.Delegate = new CustomUsabillaDelegate() { ViewController = this };
                Usabilla.CustomVariables = dict;
                Usabilla.ResetCampaignData(null);

                Usabilla.LoadFeedbackForm("[YOUR FORM ID HERE]", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        async Task PutTaskDelay()
        {
            await Task.Delay(2000);
        }

        private async void sendEvent()
        {
            await PutTaskDelay();
            Usabilla.SendEvent("xamarin");

        }

        private class CustomUsabillaDelegate : UsabillaDelegate
        {
            public ViewController ViewController { get; set; }
            public override void FormDidLoad(UINavigationController form)
            {
                ViewController.PresentViewController(form, true, null);
            }
            public override void FormDidFailLoading(UBError form)
            {

            }
        }

    }
}
