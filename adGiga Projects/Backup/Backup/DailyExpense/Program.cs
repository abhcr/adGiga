using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ShopKeeper
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    if (DateTime.Now >= (new DateTime(2010, 1, 1, 0, 0, 0)))
                    {
                        MessageBox.Show("Good Luck!");
                    }
                    Application.Run(new Main());
                }
                else
                {
                    Application.DoEvents();
                    // send our Win32 message to make the currently running instance
                    // jump on top of all the other windows
                    NativeMethods.PostMessage(
                        (IntPtr)NativeMethods.HWND_BROADCAST,
                        NativeMethods.WM_SHOWME,
                        IntPtr.Zero,
                        IntPtr.Zero);
                }
            }
            catch (Exception ex)
            {
                (new ErrorForm()).ShowError("Error Msg:"+ Environment.NewLine + ex.Message + Environment.NewLine + "Stack trace:" +  ex.StackTrace);
                Application.Exit();
            }
        }
    }
}
