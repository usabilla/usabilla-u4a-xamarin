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

                Usabilla.Initialize("[YOUR APP ID HERE]", null);
                Usabilla.Delegate = new CustomUsabillaDelegate() { ViewController = this };
                Usabilla.CustomVariables = dict;
                //Usabilla.ResetCampaignData(null);
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
        // form button
        partial void UIButton197_TouchUpInside(UIButton sender) => Usabilla.LoadFeedbackForm("[YOUR FORM ID HERE]", null);

        partial void ResetButton_TouchUpInside(UIButton sender) => Usabilla.ResetCampaignData(null);
        // event button
        partial void UIButton199_TouchUpInside(UIButton sender)
        {

            string text = keyword.Text;
            Usabilla.SendEvent(text);
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
