using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace AsyncPractice1
{
    public class TwoPointOne
    {
       public async Task DoSomethingAsync()
        {
            var val = 13;
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            val *= 2;
            
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            Console.WriteLine(val);
        }

        //2.1
        public static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        //Implement: Exponential backoff
        public static async Task<string> DownloadStringWithRetries(string uri)
        {
            using (var client = new HttpClient())
            {
                // Retry after 1 second, then after 2 seconds, then 4.
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i != 3; ++i)
                {
                    try {
                        return await client.GetStringAsync(uri);
                    } 
                    catch {
                    }
                    await Task.Delay(nextDelay);
                    
                    //double delay
                    nextDelay = nextDelay + nextDelay;
                }
            
                //!! Try one last time, allowing the error to propogate.
                return await client.GetStringAsync(uri);
            }
        }

        // return  null if the service does not respond within three seconds
        public static async Task<string> DownloadStringWithTimeout(string uri)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(uri);
                var timeoutTask = Task.Delay(3000);
                //either task finish early
                var completedTask = await Task.WhenAny(downloadTask, timeoutTask);
                //timeout happens
                if (completedTask == timeoutTask)
                    return null;
                return await downloadTask;
            }
        }

        //2.2

    }
}
