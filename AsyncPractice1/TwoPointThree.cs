using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AsyncPractice1
{
    /*
     You need to respond to progress while an asynchronous operation is executing.
     */
    public class TwoPointThree
    {

        private static bool done = false;

        //double is the type to report
        public static async Task MyMethodAsync(IProgress<double> progress = null)
        {
            double percentComplete = 0;
            while (!done)
            {
//                ...
                if (progress != null)
                    progress.Report(percentComplete);  //Report() maybe asynchronous. 
            }
        }
         
        static async Task CallMyMethodAsync()
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
            {
//                ...
            };
            //call method
            await MyMethodAsync(progress);
        }


    }
}