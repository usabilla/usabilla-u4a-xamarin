using Android.App;
using Android.Content;
using Android.OS;
using V4 = Android.Support.V4;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;
using Android.Graphics;

namespace Xamarin.Usabilla
{
    [Activity(Label = "PassiveFeedbackActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class PassiveFeedbackActivity : AndroidX.AppCompat.App.AppCompatActivity, UsabillaAndroid.IUsabillaFormCallback
    {
        private const string EXTRA_FORMID = "extra_form_id";
        private const string EXTRA_SCREENSHOT = "extra_screenshot";
        private const string FRAGMENT_TAG = "passive_feedback_activity";
        private readonly IntentFilter passiveFilter = new IntentFilter(UsabillaAndroid.UbConstants.IntentCloseForm);
        private PassiveFormCloseReceiver passiveReceiver;

        private class PassiveFormCloseReceiver : BroadcastReceiver
        {
            private readonly PassiveFeedbackActivity activity;

            public PassiveFormCloseReceiver(PassiveFeedbackActivity activity)
            {
                this.activity = activity;
            }

            public override void OnReceive(Context context, Intent intent)
            {
                activity.Finish();
            }
        }

        public static void start(Context context, string formId, bool withScreenshot)
        {
            Intent intent = new Intent(context, typeof(PassiveFeedbackActivity));
            intent.PutExtra(EXTRA_FORMID, formId);
            intent.PutExtra(EXTRA_SCREENSHOT, withScreenshot);
            intent.AddFlags(ActivityFlags.SingleTop | ActivityFlags.NewTask);
            context.StartActivity(intent);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_passive);

            passiveReceiver = new PassiveFormCloseReceiver(this);

            if (savedInstanceState == null)
            {
                if (Intent.GetBooleanExtra(EXTRA_SCREENSHOT, false))
                {
                    Bitmap screenshot = UsabillaAndroid.Usabilla.Instance.TakeScreenshot(UsabillaXamarin.Instance.Activity);
                    UsabillaAndroid.Usabilla.Instance.LoadFeedbackForm(Intent.GetStringExtra(EXTRA_FORMID), screenshot, this);
                    return;
                }

                UsabillaAndroid.Usabilla.Instance.LoadFeedbackForm(Intent.GetStringExtra(EXTRA_FORMID), this);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            AndroidX.LocalBroadcastManager.Content.LocalBroadcastManager.GetInstance(this).RegisterReceiver(passiveReceiver, passiveFilter);
        }

        protected override void OnStop()
        {
            base.OnStop();
            AndroidX.LocalBroadcastManager.Content.LocalBroadcastManager.GetInstance(this).UnregisterReceiver(passiveReceiver);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (IsFinishing) {
                UsabillaXamarin.Instance.FormCallback = null;
            }
        }

        public void FormLoadFail()
        {
            UsabillaXamarin.Instance.FormCallback(XUFormLoadResult.FormDidFailLoading);
            Finish();
        }

        public void FormLoadSuccess(IFormClient parameter)
        {
            if (!IsDestroyed)
            {
                UsabillaXamarin.Instance.FormCallback(XUFormLoadResult.FormDidSucceedLoading);
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.container, parameter.Fragment, FRAGMENT_TAG).Commit();
                return;
            }
            UsabillaXamarin.Instance.FormCallback(XUFormLoadResult.FormDidFailLoading);
        }

        public void MainButtonTextUpdated(string p0)
        {
            // do nothing
        }
    }
}
