using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace CocosJuceFormsApp.iOS
{
    public class Application : UIApplicationDelegate
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");

            CocosJuce.Api.Release();

		}

        
        public override void DidEnterBackground(UIApplication application)
        {
            CocosJuce.Api.Suspend();
        }

        public override void WillEnterForeground(UIApplication application)
        {
            CocosJuce.Api.Resume();
        }
	}
}
