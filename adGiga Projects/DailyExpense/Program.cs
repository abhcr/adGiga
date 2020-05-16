using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using SoftwareLocker;

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
            //try
            //{
                if (mutex.WaitOne(TimeSpan.Zero, true)) //<<< make multi instances possible
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //if (DateTime.Now < (new DateTime(2015, 1, 1, 0, 0, 0)))
                    //{
                        TrialMaker t = new TrialMaker("UDE", Application.StartupPath + "\\RegFile.reg",
                           Application.StartupPath + "\\Con" + "figW32.d" + "ll",
                           "mail@unimation.in\nPhone: +91 422 2533603\nMobile: +91 9790101300",
                           10+10+5, 100+50, "A1" + "9F2");

                        byte[] Monkey = { 53, 23, 21, 33, 55, 11, 5, 12,
                        56, 67, 90, 76, 253, 10, 3, 62,
                        99, 54, 95, 23, 199, 43, 212, 32};
                        t.TripleDESKey = Monkey;

                        TrialMaker.RunTypes RT = t.ShowDialog();
                        if (RT == TrialMaker.RunTypes.Full)
                        {
                            MessageBox.Show("Good Luck!"); 
                            Application.Run(new Main());
                        }
                        else if (RT == TrialMaker.RunTypes.Trial)
                        {
                            MessageBox.Show("Trial Period", "Trial", MessageBoxButtons.OK);
                            Application.Run(new Main());
                        }
                        else
                        {
                            MessageBox.Show("Contact abhijith.cr@gmail.com", "License Expired", MessageBoxButtons.OK);
                        }

                    //}
                    //else
                    //{
                    //}
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
    }
}
