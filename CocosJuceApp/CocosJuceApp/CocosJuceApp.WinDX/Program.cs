using System;
using System.Diagnostics;
using CocosJuceApp.Shared;
using Microsoft.Xna.Framework;

using CocosSharp;

namespace CocosJuceApp.WinDX
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CCApplication application = new CCApplication(false, new CCSize(480f, 800f));
            application.ApplicationDelegate = new AppDelegate();

            application.StartGame();
        }
    }


}

