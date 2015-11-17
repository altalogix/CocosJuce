using System;
using System.Runtime.InteropServices;
using System.Text;

#if __ANDROID__
  using Org.Json;
  using Android.Runtime;
#endif

namespace CocosJuce
{
    public class Api
    { 
        [DllImport(Lib.Name, EntryPoint = "cocosjuce_start_test_tone")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool StartTestTone(double frequency, float amplitude);  

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_stop_test_tone")]
        [return: MarshalAs(UnmanagedType.I1)] 
        public static extern bool StopTestTone();

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_suspend")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool Suspend();

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_resume")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool Resume();

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_release")]
        public static extern void Release(); 
         
    }
     
    internal static class Lib
    {
#if __ANDROID__
        public const string Name = "libCocosJuceSharedLib";
#elif __IOS__
        public const string Name = "__Internal";
#else  
        public const string Name = "CocosJuceSharedLib.dll";
#endif
    }
     
} 

 
// //////////////////////////////////////////////////////////////////////////////////
//
// Notes


// //////////////////////////////////////////////////////////////////////////////////
//
//
// Android 
// =======
//
// Include libCocosJuceSharedLib.so shared libs in the project with folder structure
//   Android ProjectDir
//     libs
//       armeabi
//         libCocosJuceSharedLib.so
//       armeabi-v7a
//         libCocosJuceSharedLib.so
//       x86
//         libCocosJuceSharedLib.so
//
//   with properties
//     -Build Action=AndroidNativeLibrary 
//     -Copy To Output Directory=Do not copy
//
// The libs will be linked dynamically with the binary executable at runtime
//
// also, do not forget to include the file CocosJuce.java into the project
// with properties
//     -Build Action=AndroidJavaSource
//     -Copy To Output Directory=Do not copy
// this is a declaration for some java initialization code embedded in libCocosJuceSharedLib.so
//
// note: in your library code, you need to mark your exported functions as follows:
//
//  in the .h file :  
//
//     extern "C" 
//     {
//       void MyFunc();
//     }
//
// in the .cpp file:
//
//       void MyFunc() { /* put implementation here */ }
//


// //////////////////////////////////////////////////////////////////////////////////
//
// iOS
// ===
//
// iOS Builds need additional mtouch arguments for linking the static libs:
//
//    iPhone build (armv7, arm64)
//      -cxx -gcc_flags "-L${ProjectDir}/libs/iPhone -lCocosJuceSharedLib -force_load ${ProjectDir}/libs/iPhone/libCocosJuceSharedLib.a -framework CoreMIDI -framework Accelerate"
//
//     iPhoneSimulator build (i386)
//      -cxx  -gcc_flags "-L${ProjectDir}/libs/iPhoneSimulator -lCocosJuceSharedLib -force_load ${ProjectDir}/libs/iPhoneSimulator/libCocosJuceSharedLib.a -framework CoreMIDI -framework Accelerate"
//
//
// Make sure you have a folder structure for static libs:
//
//   IOS ProjectDir
//     libs
//       iPhone
//         libCocosJuceSharedLib.a
//       iPhoneSimulator
//         libCocosJuceSharedLib.a
//
// with properties
//   -Build Action=None
//   -Copy To Output Directory=Copy always (apparently needed for Xamarin to copy the lib to the remote build machine during build)
//
// The libs will be linked statically with the binary executable
//
// As an alternative to mtouch arguments, there are also C# attributes that theoretically could be used.
// However following C# attributes do not seem to work / are not sufficient to link the libraries:
//
//   [assembly: LinkWith ("libCocosJuceSharedLib.a", LinkTarget = LinkTarget.ArmV7 , ForceLoad = true, IsCxx = true)]
//
//
// note: in your library code, you need to mark your exported functions as follows:
//
//  in the .h file :  
//
//     extern "C" 
//     {
//       __attribute__((visibility("default"))) void MyFunc();
//     }
//
// in the .cpp file:
//
//       __attribute__((visibility("default"))) void MyFunc() { /* put implementation here */ }
//




// //////////////////////////////////////////////////////////////////////////////////
//
// win32 (DX)
// ==========
//
// Include CocosJuceSharedLib.dll in the project at the root level, with
//   -Build Action=Content 
//   -Copy To Output Directory=Copy if newer
//
// This makes sure the dll is copied to the execution directory at build time.
// When deployed this dll should be distributed as well.
//
//
// note: in your library code, you need to mark your exported functions as follows:
//
//  in the .h file :  
//
//     extern "C" 
//     {
//       __declspec(dllexport) void MyFunc();
//     }
//
// in the .cpp file:
//
//       __declspec(dllexport) void MyFunc() { /* put implementation here */ }
//
// in case of doubt, check your library exports as follows:
//  
//    nm -g MyLib.a | grep MyFunc
//
//    if all is well this should produce something like
//   .... T _MyFunc
//
//
// WinRT Store Apps: Important!!!
// ==============================
// make sure the VC++ redistributable runtime dlls for store apps are accessible or in the same dir as CocosJuceSharedLib.dll
//   release builds VS2013:
//     msvcp120_app.dll
//     msvcr120_app.dll
//   debug builds VS2013:
//     msvcp120d_app.dll
//     msvcr120d_app.dll
// you can find them at c:\program files\windowsapps\Microsoft.VCLibs.120.00.Debug_12.0.21005.1_x86__<something>
//
// please note: WinRT support will only work with C++ libraries that are using a limited WinRT win32 API subset.
//              This will not yet work with libraries that link to Juce, as Juce itself is currently not yet WinRT compatible

