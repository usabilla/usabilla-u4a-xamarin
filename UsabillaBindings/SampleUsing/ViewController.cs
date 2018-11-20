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

            Usabilla.LoadFeedbackForm("5a16d9c67d66810f2248aad9", null, IntPtr.Zero);
        }
	}
}

