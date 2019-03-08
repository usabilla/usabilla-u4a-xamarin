using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Support.V7.App;
using Usabilla;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;


namespace TestingBindings
{
    [Activity(Label = "TestingBindings", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity, IUsabillaFormCallback
    {
        public void FormLoadFail()
        {
            throw new NotImplementedException();
        }

        public void FormLoadSuccess(IFormClient parameter)
        {
            parameter.Fragment.Show(SupportFragmentManager, "FORM");
        }

        public void MainButtonTextUpdated(string p0)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Usabilla.Usabilla.Instance.Initialize(BaseContext, "71f49b32-c65d-4565-b923-3b176d053122");
            Usabilla.Usabilla.Instance.LoadFeedbackForm("59787ce6022bf728fc184e4f", this);


        }

    }
}