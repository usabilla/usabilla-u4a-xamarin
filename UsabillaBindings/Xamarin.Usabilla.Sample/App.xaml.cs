using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Usabilla;
namespace Xamarin.Usabilla.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UsabillaXamarin.Instance.Initialize(null);
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
