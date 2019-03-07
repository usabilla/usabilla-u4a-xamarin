using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Support.V7.App;
using Usabilla;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;
using Com.Usabilla.Sdk.Ubform.DI;

namespace TestingBindings
{
    [Activity(Label = "TestingBindings", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity, IUsabillaFormCallback
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Usabilla.Usabilla.Instance.Initialize(BaseContext, "71f49b32-c65d-4565-b923-3b176d053122");
            Usabilla.Usabilla.Instance.LoadFeedbackForm("59787ce6022bf728fc184e4f", this);

        }

        void IUsabillaFormCallback.FormLoadFail()
        {

        }

        void IUsabillaFormCallback.FormLoadSuccess(IFormClient p0)
        {
            p0.Fragment.Show(SupportFragmentManager, "FORM");
        }

        void IUsabillaFormCallback.MainButtonTextUpdated(string p0)
        {

        }
    }
}