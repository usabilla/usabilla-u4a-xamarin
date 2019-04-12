# UsabillaBindings
Xamarin bindings for both Usabilla iOS and Android native libraries

# iOS Bindings 
The main project for iOS part of this project is called XamarinBindingLibrary.
It contatins binding code, which is mainly placed in ApiDefinition.cs file.
Follow these steps when you need to build a new version of Binding Library:
- open XamarinBindingLibrary
- check "NativeReferences" folder: if this folder contains "Usabilla.framwork" - remove it and add the new one
- right click on the XamarinBindingLibrary and select Clean, then Rebuild
Now you can use UsabillaIos.dll in your Xamarin Demo.

# Android Bindings
The main project for Android part of this project is called Xamarin.Usabilla.Android.
It generates binding code, which is mainly configured in Metadata.xml file.
Follow these steps when you need to build a new version of Binding Library:
- open Xamarin.Usabilla.Android
- check "Jars" folder: if this folder contains "Usabilla.aar" - remove it and add the new one
- right click on the Xamarin.Usabilla.Android and select Clean, then Rebuild
Now you can use UsabillaIos.dll in your Xamarin Demo.

# Demo
To use UsabillaIos.dll library, just reference it in your Xamarin project. You can do that by right clicking on References -> Edit references -> add UsabillaIos.dll
