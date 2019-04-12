using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using UsabillaIos;

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
                Usabilla.Initialize("71f49b32-c65d-4565-b923-3b176d053122", null);
                Usabilla.Delegate = new CustomUsabillaDelegate() { ViewController = this };
                Usabilla.ResetCampaignData(null);
                Usabilla.SendEvent("r");
                //Usabilla.LoadFeedbackForm("5be4154a4cc4f42e2b1741a4", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
