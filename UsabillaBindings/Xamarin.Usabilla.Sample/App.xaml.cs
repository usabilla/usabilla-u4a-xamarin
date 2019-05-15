using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Usabilla;
namespace Xamarin.Usabilla.Sample
{
    public partial class App : Application
    {
        private const string AppId = "7fb7ffdd-c2fa-49b9-bee5-218c12466df7";

        public App()
        {
            InitializeComponent();
            UsabillaXamarin.Instance.Initialize(AppId);
            UsabillaXamarin.Instance.DebugEnabled = true;
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
