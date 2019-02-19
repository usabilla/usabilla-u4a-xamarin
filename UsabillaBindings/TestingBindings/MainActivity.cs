using Android.App;
using Android.Widget;
using Android.OS;

namespace TestingBindings
{
    [Activity(Label = "TestingBindings", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var t = Com.Usabilla.Sdk.Ubform.Bus.Bus.Instance;//.Instance.Initialize(ApplicationContext, "");
            var sometext = "asdasd";
        }
    }
}

