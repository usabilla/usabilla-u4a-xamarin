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

                //var keys = new NSString[] { new NSString("test"), new NSString("xamarin") };
                // var values = new NSObject[] { new NSObject("feast"), new NSObject("Other") };

                NSDictionary<NSString, NSObject> dict = new NSDictionary<NSString, NSObject>(new NSString("tesr"), NSObject.FromObject("xamarint"));

                Usabilla.Initialize("8a925f70-276d-4301-968e-92acc91ea3f2", null);
                Usabilla.Delegate = new CustomUsabillaDelegate() { ViewController = this };
                Usabilla.CustomVariables = dict;
                Usabilla.ResetCampaignData(null);
               // sendEvent();

                Usabilla.LoadFeedbackForm("5be4154a4cc4f42e2b1741a4", null);
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
