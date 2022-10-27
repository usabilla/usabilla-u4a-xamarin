using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Usabilla;
namespace Xamarin.Usabilla.Sample
{
    public partial class App : Application
    {
        //private const string AppId = "[APP ID HERE]";
        private const string AppId = "9a2fa46d-301a-4485-94bc-cae6d0697348";
        public App()
        {
            InitializeComponent();
            UsabillaXamarin.Instance.DebugEnabled = true;
            UsabillaXamarin.Instance.Initialize(AppId);
            MainPage = new SplashPage();
        
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
