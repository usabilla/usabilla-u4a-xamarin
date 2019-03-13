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
    public class MyPassiveReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            ((MainActivity)context).RemoveFragment();
        }
    }

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
        readonly int SCREEN_SIZE_THRESHOLD_FOR_FULL_SCREEN_FORM = 7;
        readonly String FRAGMENT_TAG = "Sample app fragment";

        readonly MyPassiveReceiver passiveReceiver = new MyPassiveReceiver();
        readonly IntentFilter passiveFilter = new IntentFilter(UbConstants.IntentCloseForm);
        readonly MyCampaignReceiver campaignReceiver = new MyCampaignReceiver();
        readonly IntentFilter campaignFilter = new IntentFilter(UbConstants.IntentCloseCampaign);

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
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            base.OnStart();
            RegisterReceiver(passiveReceiver, passiveFilter);
            RegisterReceiver(campaignReceiver, campaignFilter);
        }

        protected override void OnStop()
        {
            base.OnStop();
            UnregisterReceiver(passiveReceiver);
            UnregisterReceiver(campaignReceiver);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Button buttonPassive = FindViewById<Button>(Resource.Id.button_passive);
            Button buttonCampaign = FindViewById<Button>(Resource.Id.button_campaign);
            Button buttonReset = FindViewById<Button>(Resource.Id.button_reset);
            EditText eventText = FindViewById<EditText>(Resource.Id.event_field);

            buttonPassive.Click += (sender, e) => {
                Usabilla.Usabilla.Instance.LoadFeedbackForm("59787ce6022bf728fc184e4f", this);
            };
            buttonCampaign.Click += (sender, e) => {
                Usabilla.Usabilla.Instance.SendEvent(BaseContext, eventText.Text);
            };
            buttonReset.Click += (sender, e) => {
                Usabilla.Usabilla.Instance.ResetCampaignData(BaseContext);
            };

            Usabilla.Usabilla.Instance.Initialize(BaseContext, "71f49b32-c65d-4565-b923-3b176d053122");

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