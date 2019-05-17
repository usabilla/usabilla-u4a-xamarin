using System;
using System.Collections.Generic;
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
            System.Diagnostics.Debug.WriteLine("Result of showForm : {0}", result);
        }

        void OnSendEventClicked(object sender, EventArgs args)
        {
            EventName.Unfocus();
            UsabillaXamarin.Instance.SendEvent(eventText);
        }

        void OnDismissClicked(object sender, EventArgs args)
        {
            UsabillaXamarin.Instance.Dismiss();
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
            UsabillaXamarin.Instance.ShowFeedbackFormWithScreenshot("[YOU FORM ID HERE]", handler);
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
