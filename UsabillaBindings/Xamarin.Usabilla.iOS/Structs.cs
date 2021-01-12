using System;
using System.Runtime.InteropServices;
using Foundation;
using UIKit;

namespace UsabillaIos
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UsabillaTheme
    {
        public Colors Colors;
        public Fonts Fonts;
        public Images Images;
        public UIStatusBarStyle StatusBarStyle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Colors
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Fonts
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Images
    {

    }
}

