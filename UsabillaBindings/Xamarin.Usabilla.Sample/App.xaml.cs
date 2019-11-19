using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Usabilla;
namespace Xamarin.Usabilla.Sample
{
    public partial class App : Application
    {
        private const string AppId = "[YOUR APP ID HERE]";

        public App()
        {
            InitializeComponent();
            UsabillaXamarin.Instance.DebugEnabled = true;
            UsabillaXamarin.Instance.Initialize(AppId);
            MainPage = new MainPage();
        
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
