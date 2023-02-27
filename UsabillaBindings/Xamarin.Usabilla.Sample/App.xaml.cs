using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Usabilla;
namespace Xamarin.Usabilla.Sample
{
    public partial class App : Application
    {
        private const string AppId = "[APP ID HERE]";        
        public App()
        {
            InitializeComponent();
            Action<IXUFormCompletionResult> handler = formCompletionHandler;
            UsabillaXamarin.Instance.DebugEnabled = true;
            UsabillaXamarin.Instance.Initialize(AppId, formCompletionHandler);
            MainPage = new SplashPage();
        }

        private void formCompletionHandler(IXUFormCompletionResult res)
        {
            System.Diagnostics.Debug.WriteLine("Result of showForm : {0}", res.isFormSucceeded);
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
