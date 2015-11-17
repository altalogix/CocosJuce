using System;
using Android.App;
using Android.Runtime;


namespace CocosJuceApp.Droid
{


    [Register("com/yourcompany/cocosjucesharedlib/JuceActivity", DoNotGenerateAcw = true)]
    public partial class JuceActivity : Activity
    {

        private static readonly IntPtr ClassRef = JNIEnv.FindClass("com/yourcompany/cocosjucesharedlib/JuceActivity");
        private static IntPtr launchAppMethodId;
        private static IntPtr quitAppMethodId;
        private static IntPtr suspendAppMethodId;
        private static IntPtr resumeAppMethodId;

        public void LaunchApp(String appFile, String appDataDir)
        {
            if (launchAppMethodId == IntPtr.Zero)
            {
                launchAppMethodId = JNIEnv.GetMethodID(ClassRef, "launchApp", "(Ljava/lang/String;Ljava/lang/String;)V");
            }
            using (var jAppFile = new Java.Lang.String(appFile))
            using (var jAppDataDir = new Java.Lang.String(appDataDir))
            {
                JNIEnv.CallVoidMethod(Handle, launchAppMethodId, new JValue(jAppFile), new JValue(jAppDataDir));                
            }
        }

        public void QuitApp()
        {
            if (quitAppMethodId == IntPtr.Zero)
            {
                quitAppMethodId = JNIEnv.GetMethodID(ClassRef, "quitApp", "()V");
            }
            JNIEnv.CallVoidMethod(Handle, quitAppMethodId);                            
        }

        public void SuspendApp()
        {
            if (suspendAppMethodId == IntPtr.Zero)
            {
                suspendAppMethodId = JNIEnv.GetMethodID(ClassRef, "suspendApp", "()V");
            }
            JNIEnv.CallVoidMethod(Handle, suspendAppMethodId);
        }

        public void ResumeApp()
        {
            if (resumeAppMethodId == IntPtr.Zero)
            {
                resumeAppMethodId = JNIEnv.GetMethodID(ClassRef, "resumeApp", "()V");
            }
            JNIEnv.CallVoidMethod(Handle, resumeAppMethodId);
        }
    }

}

