using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using System;
using Android.Support.V7.App;
using Usabilla;
using Com.Usabilla.Sdk.Ubform.Sdk.Form;
using Com.Usabilla.Sdk.Ubform.Sdk.Entity;

namespace TestingBindings
{
    public class MyCampaignReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            FeedbackResult feedbackResult = (Com.Usabilla.Sdk.Ubform.Sdk.Entity.FeedbackResult)intent.GetParcelableExtra(FeedbackResult.IntentFeedbackResultCampaign);
            String feedbackInfo = "Rating " + feedbackResult.Rating + "\n";
            feedbackInfo += "Abandoned page " + feedbackResult.AbandonedPageIndex + "\n";
            feedbackInfo += "Is sent " + feedbackResult.IsSent;
            Toast.MakeText(context, feedbackInfo, ToastLength.Long).Show();
        }
    }

    [Activity(Label = "TestingBindings", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity, IUsabillaFormCallback
    {
        private readonly int SCREEN_SIZE_THRESHOLD_FOR_FULL_SCREEN_FORM = 7;
        private readonly String FRAGMENT_TAG = "Sample app fragment";

        private MyPassiveReceiver passiveReceiver;
        private readonly IntentFilter passiveFilter = new IntentFilter(UbConstants.IntentCloseForm);
        private readonly MyCampaignReceiver campaignReceiver = new MyCampaignReceiver();
        private readonly IntentFilter campaignFilter = new IntentFilter(UbConstants.IntentCloseCampaign);

        private class MyPassiveReceiver : BroadcastReceiver
        {
            private readonly MainActivity mainActivity;

            public MyPassiveReceiver(MainActivity mainActivity)
            {
                this.mainActivity = mainActivity;
            }

            public override void OnReceive(Context context, Intent intent)
            {
                mainActivity.RemoveFragment();
            }
        }

        public void FormLoadFail()
        {
            Toast.MakeText(BaseContext, "Form failed to load", ToastLength.Short).Show();
        }

        public void FormLoadSuccess(IFormClient parameter)
        {
            AttachFragment(parameter.Fragment);
        }

        public void MainButtonTextUpdated(string p0)
        {
           // do nothing
        }

        protected override void OnStart()
        {
            base.OnStart();
            Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).RegisterReceiver(passiveReceiver, passiveFilter);
            Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).RegisterReceiver(campaignReceiver, campaignFilter);
        }

        protected override void OnStop()
        {
            base.OnStop();
            Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).UnregisterReceiver(passiveReceiver);
            Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).UnregisterReceiver(campaignReceiver);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            passiveReceiver = new MyPassiveReceiver(this);

            Button buttonPassive = FindViewById<Button>(Resource.Id.button_passive);
            Button buttonCampaign = FindViewById<Button>(Resource.Id.button_campaign);
            Button buttonReset = FindViewById<Button>(Resource.Id.button_reset);
            EditText eventText = FindViewById<EditText>(Resource.Id.event_field);

            buttonPassive.Click += (sender, e) => {
                Usabilla.Usabilla.Instance.LoadFeedbackForm("INSERT FORM ID", this);
            };
            buttonCampaign.Click += (sender, e) => {
                Usabilla.Usabilla.Instance.SendEvent(BaseContext, eventText.Text);
            };
            buttonReset.Click += (sender, e) => {
                Usabilla.Usabilla.Instance.ResetCampaignData(BaseContext);
            };
            Usabilla.Usabilla.Instance.Initialize(BaseContext, "INSERT APP ID");
            Usabilla.Usabilla.Instance.UpdateFragmentManager(SupportFragmentManager);

            var fragment = SupportFragmentManager.FindFragmentByTag(FRAGMENT_TAG);
            if (fragment != null)
            {
                AttachFragment((Android.Support.V4.App.DialogFragment) fragment);
            }
        }

        private Double GetScreenSizeInInches()
        {
            var metrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(metrics);
            var wi = (double)metrics.WidthPixels / metrics.Xdpi;
            var di = (double)metrics.HeightPixels / metrics.Ydpi;
            var x = Math.Pow(wi, 2.0);
            var y = Math.Pow(di, 2.0);
            return Math.Sqrt(x + y);
        }

        private void AttachFragment(Android.Support.V4.App.DialogFragment fragment)
        {
            var screenSize = GetScreenSizeInInches();
            if (screenSize > SCREEN_SIZE_THRESHOLD_FOR_FULL_SCREEN_FORM)
            {
                fragment.Show(SupportFragmentManager, FRAGMENT_TAG);
                return;
            }
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.activity_frame, fragment, FRAGMENT_TAG).Commit();
        }

        public void RemoveFragment()
        {
            var fragment = SupportFragmentManager.FindFragmentByTag(FRAGMENT_TAG);
            if (fragment != null)
            {
                var screenSize = GetScreenSizeInInches();
                if (screenSize > SCREEN_SIZE_THRESHOLD_FOR_FULL_SCREEN_FORM)
                {
                    ((Android.Support.V4.App.DialogFragment)fragment).Dismiss();
                    return;
                }
                SupportFragmentManager.BeginTransaction().Remove(fragment).Commit();
            }
        }
    }
}