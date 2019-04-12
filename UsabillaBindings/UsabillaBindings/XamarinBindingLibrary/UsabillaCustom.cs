using System;
using Foundation;
using UIKit;
using ObjCRuntime;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace XamarinBindingLibrary
{
    //public delegate void FormLoaded(object sender, System.EventArgs e);

    //public static class UsabillaNative
    //{
    //    [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    //    static extern CGSize ObjC_MsgSend_UsabillaSetDelegate(IntPtr target, IntPtr selector, UsabillaDelegate usabillaDelegate);

    //    [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    //    static extern CGSize ObjC_MsgSend_UsabillaInitialize(IntPtr target, IntPtr selector, string appID, IntPtr completion);

    //    public static void Initialize(string appID, Action completion)
    //    {
    //        Selector initializeSelector = new Selector("initializeWithAppID:completion:");

    //        var obj = new Class("Usabilla");

    //        ObjC_MsgSend_UsabillaInitialize(obj.Handle, initializeSelector.Handle, appID, completion == null ? IntPtr.Zero: completion.Method.MethodHandle.Value);

    //        Selector delegateSelector = new Selector("setDelegate:");
    //        ObjC_MsgSend_UsabillaSetDelegate(obj.Handle, delegateSelector.Handle, new UsabillaDelegateCustom());
    //    }


    //    [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    //    static extern CGSize ObjC_MsgSend_UsabillaLoadFeedbackForm(IntPtr target, IntPtr selector, string formID, IntPtr image, IntPtr theme);

    //    public static void LoadFeedbackFrom(string formID, CGImage image, IntPtr theme)
    //    {
    //        var loadFeedbsckFormSelector = new Selector("loadFeedbackForm:screenshot:theme:");
    //        var obj = new Class("Usabilla");
    //        ObjC_MsgSend_UsabillaLoadFeedbackForm(obj.Handle, loadFeedbsckFormSelector.Handle, formID, image == null ? IntPtr.Zero : image.Handle, theme);
    //    }


    //    public static event FormLoaded FormDidLoad;
    //}

    //internal class UsabillaDelegateCustom : UsabillaDelegate
    //{
    //    public void CampaignDidClose(FeedbackResult feedbackResult, bool isRedirectToAppStoreEnabled)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void FormDidClose(string formID, NSArray feedbackResults, bool isRedirectToAppStoreEnabled)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void FormDidFailLoading(UBError form)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void FormDidLoad(UINavigationController form)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void FormWillClose(UINavigationController form, string formID, NSArray feedbackResults, bool isRedirectToAppStoreEnabled)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}