using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VoluMIDI
{
    static class Program
    {
        public static bool running = true;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupForm());
            running = false;
        }
    }
}
