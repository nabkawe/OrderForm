using System;
using System.Windows.Forms;

namespace OrderForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var mutex = new System.Threading.Mutex(false, "Advanced Orders"))
            {
                //bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
                //if (isAnotherInstanceOpen)
                //{
                //    Console.WriteLine("Only one instance of this app is allowed.");
                //    return;
                //}

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(new Orders());
                //mutex.ReleaseMutex();
            }

        }
    }
}
