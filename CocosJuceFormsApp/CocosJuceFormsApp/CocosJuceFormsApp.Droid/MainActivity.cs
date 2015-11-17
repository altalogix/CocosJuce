using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CocosJuceApp.Droid;

namespace CocosJuceFormsApp.Droid
{
	[Activity (Label = "CocosJuceFormsApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
        private JuceActivity _juceActivity;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            var packageName = this.PackageName;
            var appInfo = PackageManager.GetApplicationInfo(packageName, PackageInfoFlags.Activities);

            _juceActivity = new JuceActivity();

            _juceActivity.LaunchApp(appInfo.PublicSourceDir, appInfo.DataDir);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new CocosJuceFormsApp.App ());
		}

	    protected override void OnDestroy()
	    {
            CocosJuce.Api.Release();

            _juceActivity.QuitApp();

	        base.OnDestroy();
	    }

        protected override void OnPause()
        {
            CocosJuce.Api.Suspend();

            _juceActivity.SuspendApp();

            base.OnPause();
        }

        protected override void OnResume()
        {
            CocosJuce.Api.Resume();

            _juceActivity.ResumeApp();

            base.OnResume();
        }

	    public override void OnBackPressed()
	    {
            MoveTaskToBack(true);
	    }
	}
}

