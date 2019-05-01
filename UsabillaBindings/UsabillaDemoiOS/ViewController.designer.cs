// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace UsabillaDemoiOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField keyword { get; set; }


        [Action ("ResetButton_TouchUpInside:")]
        partial void ResetButton_TouchUpInside (UIKit.UIButton sender);


        [Action ("UIButton197_TouchUpInside:")]
        partial void UIButton197_TouchUpInside (UIKit.UIButton sender);


        [Action ("UIButton199_TouchUpInside:")]
        partial void UIButton199_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (keyword != null) {
                keyword.Dispose ();
                keyword = null;
            }
        }
    }
}