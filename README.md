# Usabilla for Xamarin.

Usabilla for Apps allows you to collect feedback from your users with great ease and flexibility.
This Xamarin bridge to the Native Usabilla SDK allows you to load passive feedback forms and submit results from a Xamarin app.

The bridge is created using Xamarin native and does not yet have a unified API for both Android and iOS.

⚠️ From v2.0.0; Usabilla.Xamarin package has been migrated to .netstandard from PCL.
For more information please check [here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

⚠️ Make sure you clear your nuget cache before installing the new package by doing: 
```
dotnet nuget locals all --clear
```

## Installation

Installation is done via NuGet: <https://www.nuget.org/packages/Usabilla.Xamarin>

## Usage

### Xamarin.Forms
- The package uses the Bait and Switch PCL Trick. You need to add the package to the shared, Android and iOS projects.

To use the Xamarin bridge for Xamarin.Forms, you must include:
```C#
using Xamarin.Usabilla;
```

The initialization of the library is done with:
```C#
UsabillaXamarin.Instance.Initialize("[YOUR APP ID HERE]");
```

To present the form:
```C#
UsabillaXamarin.Instance.ShowFeedbackForm("[YOUR FORM ID HERE]", (XUFormCompletionResult) => {
// XUFormCompletionResult contains the following information: 
// isFormSucceeded:  this tells whether a form is shown or not
// formId: this is an optional field which occurs when called via passive forms
// result contains an object :
// rating: this value contains the response to the Mood/Star rating question. 
// sent: this value contains whether Campaign / Form is sent.
// abandonedpageindex: this value is set if the user Campaign is closed before submission. 
// isRedirectToAppStoreEnabled: defining a value will enable the App Store Rating prompt.
// description :  this is an optional field which tells error description
});
```

To present the form with current screenshot:
```C#
UsabillaXamarin.Instance.ShowFeedbackFormWithScreenshot("[YOUR FORM ID HERE]", (XUFormCompletionResult) => {
// XUFormCompletionResult contains the following information: 
// isFormSucceeded:  this tells whether a form is shown or not
// formId: this is an optional field which occurs when called via passive forms
// result contains an object :
// rating: this value contains the response to the Mood/Star rating question. 
// sent: this value contains whether Campaign / Form is sent.
// abandonedpageindex: this value is set if the user Campaign is closed before submission. 
// isRedirectToAppStoreEnabled: defining a value will enable the App Store Rating prompt.
// description :  this is an optional field which tells error description
});
```

To send an event:
```C#
UsabillaXamarin.Instance.SendEvent("[YOUR EVENT NAME HERE]", (XUFormCompletionResult) => {
// XUFormCompletionResult contains the following information: 
// isFormSucceeded:  this tells whether a form is shown or not
// formId: this is an optional field which occurs when called via passive forms
// result contains an object :
// rating: this value contains the response to the Mood/Star rating question. 
// sent: this value contains whether Campaign / Form is sent.
// abandonedpageindex: this value is set if the user Campaign is closed before submission. 
// isRedirectToAppStoreEnabled: defining a value will enable the App Store Rating prompt.
// description :  this is an optional field which tells error description
});
```
To set localization for all the text that is not customizable in the web interface, you can provide your own translation.
For ios  using a .string localized file inside your application and set the string file `Localizable.strings` name as mentioned below 
**Note : This is only available for ios**
```C#
 if (Device.RuntimePlatform == Device.iOS) { 
      UsabillaXamarin.Instance.LocalizedStringFile = "Localizable"; 
   }
```
For android, use Strings.xml localized file inside your application.

#### Additional Setup for Android
You need to set:
```C#
UsabillaXamarin.Instance.Activity = /*Activity instance where your Xamarin.Forms is initialized*/;
```
This is for the SDK to have a reference on the `Activity Context` which is used to get the `SupportFragmentManager` and getting a screenshot of the current `Xamarin.Forms` screen.

### Android
The SDK uses HTTP legacy so you must include this line in your `AndroidManifest` inside the `<application>` tags:
```xml
<uses-library android:name="org.apache.http.legacy" android:required="false" />
```

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

The Xamarin Bridge for Android is similar to the native Android SDK. The only difference is that the bridge follows C# conventions.

You can refer to the [native Android SDK](https://github.com/usabilla/usabilla-u4a-android-sdk), for in-depth explanation of the SDK.

⚠️ Please note that, from Usabilla.Xamarin v2.0.0, native Android SDK has been temporarily downgraded to version 7.0.9 due to .netstandard compatibility issues.


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
```C#
Usabilla.LoadFeedbackForm("[YOUR FORM ID HERE]", null);
```

Make sure to add:
```
Privacy - Camera Usage Description  
```
and
```
Privacy - Photo Library Usage Description
```
with a meaning full explanation to the end-user.


You can refer to the [native iOS SDK](https://github.com/usabilla/usabilla-u4a-ios-swift-sdk), for in-depth explanation of the SDK.

### IMPORTANT:

When you build an app that depends on the Usabilla SDK, that is build using Swift, you need to include everything that the library depends on in your app, including runtime and standard libraries. You can include all dependencies manually or you can use [Flash3001/Xamarin.Swift](https://github.com/Flash3001/Xamarin.Swift) to achieve the same result.

If not all dependencies are included your app will crash at startup with a message like:

    Dyld Error Message:
    Library not loaded: @rpath/libswiftCore.dylib
    Referenced from: /Users/asv/Library/Developer/CoreSimulator/Devices/AC440891-C819–4050–8CAB-CE15AB4B3830/data/Containers/Bundle/Application/27D2EC87–5042–4FA7–9B80-A24A8971FB48/SampleIOSApp/Usabilla.framework/usabilla
