using System;
using System.Collections.Generic;
using Java.Util;
using Xamarin.Forms;

namespace Xamarin.Usabilla.Sample
{
    public partial class MainPage : ContentPage
    {

        private string eventText = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void formHandler(XUFormLoadResult result)
        {
            if (result == XUFormLoadResult.FormDidSucceedLoading) {
                var a = 1;
            } else {
                var b = 1;
            }
        }

        void OnSendEventClicked(object sender, EventArgs args)
        {
            EventName.Unfocus();
            UsabillaXamarin.Instance.SendEvent(eventText);
        }

        void OnResetClicked(object sender, EventArgs args)
        {
            UsabillaXamarin.Instance.Reset();
        }
        void Entry_Changed(object sender, EventArgs e)
        {
            eventText = ((Entry)sender).Text;
        }
        void OnLoadFormClicked(object sender, EventArgs e) 
        {
            Action<XUFormLoadResult> handler = formHandler;
            UsabillaXamarin.Instance.ShowFeedbackForm("5be4154a4cc4f42e2b1741a4", handler);
        }
        void AddCustomVariableClicked(object sender, EventArgs e)
        {
            Dictionary<string,string> keyValuePairs  = new Dictionary<string, string>
        {
            { "xamarin", "ios" },
            { "ios", "working" }
        };
           UsabillaXamarin.Instance.CustomVariables = keyValuePairs;

        }
    }
}
