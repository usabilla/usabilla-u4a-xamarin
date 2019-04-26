# Usabilla for React Native

Usabilla for Apps allows you to collect feedback from your users with great ease and flexibility.
This Xamarin bridge to the Native Usabilla SDK allows you to load passive feedback forms and submit results from a Xamarin app.

The bridge is created using Xamarin native and does not yet have a unified API for both Android and iOS

## Installation

Installation is done via NuGet: <NuGet Link>

## Usage

### Android
To use the Xamarin bridge for Android, you must include:
```C#
using UsabillaAndroid;
```

The initialization of the library is done with:
```C#
Usabilla.Instance.Initialize(context, "[YOUR APP ID HERE]");
```
This should be done as early as possible, as there can be a few seconds delay before the SDK has downloaded data from the server.

To present the form:
```C#
Usabilla.Instance.LoadFeedbackForm("[YOUR FORM ID HERE]", callback);
```
`callback` is a callback used to communicate when the loading ends.

The Xamarin Bridge for Android is similar to the native Android SDK. The only difference is with the bridge follows C# conventions.

You can refer to the [native Android SDK](https://github.com/usabilla/usabilla-u4a-android-sdk), for in-depth explanation of the SDK.

### iOS
To use the Xamarin bridge for iOS, you must include:
```C#
using UsabillaIos;
```

The initialization of the library is done with 
```C#
Usabilla.Initialize("[YOUR APP ID HERE]", null);
```
This should be done as early as possible, as there can be a few seconds delay before the SDK has downloaded data from the server.

To present a form you must setup a delegate, to act in, when the form has loaded:
```C#
Usabilla.Delegate = new CustomUsabillaDelegate() { ViewController = this };
```

In the main class create the delegate implementation:

```C#
private class CustomUsabillaDelegate : UsabillaDelegate {
	public ViewController ViewController { get; set; }

    public override void FormDidLoad(UINavigationController form) {
       // form did load, present it
        ViewController.PresentViewController(form, true, null);
    }
    public override void FormDidFailLoading(UBError form) {
		// some action here
    }
}
```
And then load the form to present 

`Usabilla.LoadFeedbackForm("[Your FORM ID here]", null);`


You can refer to the [native iOS SDK](https://github.com/usabilla/usabilla-u4a-ios-swift-sdk), for in-depth explanation of the SDK.