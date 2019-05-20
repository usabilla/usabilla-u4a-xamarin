using System;
using Xamarin.Forms;

namespace Xamarin.Usabilla.Sample
{
    public partial class MainPage : ContentPage
    {

        private string eventText = "";

        public MainPage()
        {
            InitializeComponent();

            UbImage.Source = ImageSource.FromResource("Xamarin.Usabilla.Sample.logo.png");
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
    }
}
