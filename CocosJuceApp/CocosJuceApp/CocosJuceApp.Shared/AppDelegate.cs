using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using CocosSharp;
using CocosDenshion;

namespace CocosJuceApp.Shared
{

    public class AppDelegate : CCApplicationDelegate
    {

        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.ContentRootDirectory = "Content";
            var windowSize = mainWindow.WindowSizeInPixels;

#if __ANDROID__
            var desiredWidth = 480f;
            var desiredHeight = 800f;
#elif WINDOWS
            var desiredWidth = 480f;
            var desiredHeight = 800f;
#elif __IOS__
            var desiredWidth = 640.0f;
            var desiredHeight = 960.0f;
#endif

            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            CCScene.SetDefaultDesignResolution(desiredWidth, desiredHeight, CCSceneResolutionPolicy.ShowAll);

            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)

#if __IOS__
            CCSprite.DefaultTexelToContentSizeRatio = 0.8f;
#elif __ANDROID__
            CCSprite.DefaultTexelToContentSizeRatio = 0.9f;
#else
            CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
#endif
            if (desiredWidth < windowSize.Width)
            {
                application.ContentSearchPaths.Add("hd");
                //CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            }
            else
            {
                application.ContentSearchPaths.Add("ld");
                //CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            }

            var scene = new CCScene(mainWindow);
            var introLayer = new IntroLayer();

            scene.AddChild(introLayer);

            mainWindow.RunWithScene(scene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }

        public Action BackButtonWasPressed { get; set; }

    }
}