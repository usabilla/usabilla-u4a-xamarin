using Android.App;
using Android.Content;
using Android.OS;
using V4 = Android.Support.V4;
using Android.Support.V7.App;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;

namespace Xamarin.Usabilla
{
    [Activity(Label = "PassiveFeedbackActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class PassiveFeedbackActivity : AppCompatActivity, UsabillaAndroid.IUsabillaFormCallback,
        IDialogInterfaceOnDismissListener
    {
        private const string EXTRA_FORMID = "extra_form_id";
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
                activity.DismissForm();
            }
        }

        public static void start(Context context, string formId)
        {
            Intent intent = new Intent(context, typeof(PassiveFeedbackActivity));
            intent.PutExtra(EXTRA_FORMID, formId);
            intent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(intent);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_passive);

            passiveReceiver = new PassiveFormCloseReceiver(this);

            UsabillaAndroid.Usabilla.Instance.LoadFeedbackForm(Intent.GetStringExtra(EXTRA_FORMID), this);
        }

        protected override void OnStart()
        {
            base.OnStart();
            V4.Content.LocalBroadcastManager.GetInstance(this).RegisterReceiver(passiveReceiver, passiveFilter);
        }

        protected override void OnStop()
        {
            base.OnStop();
            V4.Content.LocalBroadcastManager.GetInstance(this).UnregisterReceiver(passiveReceiver);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UsabillaXamarin.Instance.FormCallback = null;
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

        // Finishes the activity but waits for the dialog to be dismissed before finishing
        private void DismissForm()
        {
            // Make sure the dialog is shown before doing anything else
            SupportFragmentManager.ExecutePendingTransactions();

            V4.App.Fragment currentFragment = SupportFragmentManager.Fragments[SupportFragmentManager.Fragments.Count - 1];
            if (!(currentFragment is V4.App.DialogFragment))
            {
                Finish();
                return;
            }

            V4.App.DialogFragment dialogFragment = (V4.App.DialogFragment)currentFragment;

            dialogFragment.Dialog.SetOnDismissListener(this);
        }

        public void OnDismiss(IDialogInterface dialog)
        {
            Finish();
        }
    }
}
