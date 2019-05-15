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
    }
}
