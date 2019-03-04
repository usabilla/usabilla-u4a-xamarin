using Android.App;
using Android.Widget;
using Android.OS;
using Com.Usabilla.Sdk.Ubform;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;
using System;

namespace TestingBindings
{
    [Activity(Label = "TestingBindings", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Usabilla.Instance.Initialize(BaseContext);
            Usabilla.Instance.LoadFeedbackForm("59787ce6022bf728fc184e4f", new FormCallback { ParentActivity = this });
        }
    }

    public class FormCallback : Java.Lang.Object, IUsabillaFormCallback
    {
        public Activity ParentActivity { get; set; }

        public void FormLoadFail()
        {

        }

        public void FormLoadSuccess(IFormClient p0)
        {
            //var fragmentTransaction = ParentActivity.FragmentManager.BeginTransaction();
            //fragmentTransaction.Add(p0, "usabilla_fomr");
        }

        public void MainButtonTextUpdated(string p0)
        {

        }
    }
}

