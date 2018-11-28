using System;
using Foundation;
using UIKit;
using UsabillaNative;

namespace SampleUsing
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Usabilla.Delegate = new UsabillaDelegateImplementation() { ViewController = this };

            Usabilla.LoadFeedbackForm("5a16d9c67d66810f2248aad9", null);
        }



        class UsabillaDelegateImplementation : UsabillaDelegate
        {
            public UIViewController ViewController { get; set; }

            [Export("formDidLoad:")]
            public override void FormDidLoad(UINavigationController form)
            {
                ViewController.PresentViewController(form, true, null);
            }
        }
    }
}

