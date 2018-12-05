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

            Usabilla.LoadFeedbackForm("5be4154a4cc4f42e2b1741a4", null);
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

