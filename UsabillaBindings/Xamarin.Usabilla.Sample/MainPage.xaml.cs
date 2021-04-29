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
            NavigationPage.SetHasNavigationBar(this,false);
        }

        private void formCompletionHandler(IXUFormCompletionResult res)
        {
            System.Diagnostics.Debug.WriteLine("Result of showForm : {0}", res);
        }

        void OnSendEventClicked(object sender, EventArgs args)
        {
            Action<IXUFormCompletionResult> handler = formCompletionHandler;
            EventName.Unfocus();
            UsabillaXamarin.Instance.SendEvent(eventText, handler);
        }

        void OnResetClicked(object sender, EventArgs args)
        {
            UsabillaXamarin.Instance.Reset();
        }

        void Entry_Changed(object sender, EventArgs e)
        {
            eventText = ((Entry)sender).Text;
        }

        private void OnLoadFormButtonClicked(object sender, EventArgs e)
        {
            Action<IXUFormCompletionResult> handler = formCompletionHandler;
            UsabillaXamarin.Instance.ShowFeedbackFormWithScreenshot("[FORM ID HERE]", handler);
        }
    }
}
