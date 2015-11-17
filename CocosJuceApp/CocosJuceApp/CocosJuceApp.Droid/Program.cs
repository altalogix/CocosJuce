using Android.Content.PM;
using Android.App;
using Android.OS;
using Microsoft.Xna.Framework;
using CocosSharp;
using CocosJuceApp.Shared;

namespace CocosJuceApp.Droid
{

    [Activity(Label = "CocosJuceApp.Droid"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Portrait
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
    public class Program : AndroidGameActivity
    {

        private JuceActivity _juceActivity;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            CCApplication application = new CCApplication();
            var appDelegate = new AppDelegate();
            appDelegate.BackButtonWasPressed = BackButtonWasPressed;
            application.ApplicationDelegate = appDelegate;

			this.SetContentView(application.AndroidContentView);
          
            var packageName = this.PackageName;
            var appInfo = PackageManager.GetApplicationInfo(packageName, PackageInfoFlags.Activities);

            _juceActivity = new JuceActivity();

            _juceActivity.LaunchApp(appInfo.PublicSourceDir, appInfo.DataDir);
	            
            application.StartGame();

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

        void BackButtonWasPressed()
        {
            MoveTaskToBack(true);
        }


    }


}

