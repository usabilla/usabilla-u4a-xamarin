using System;
using System.Runtime.InteropServices;
using Foundation;
using UIKit;

namespace UsabillaNative
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FeedbackResult
    {
        public int Rating;
        public int AbandonedPageIndex;
        public bool Sent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UBError
    {
        public int Description;
    }

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

