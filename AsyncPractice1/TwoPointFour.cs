using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncPractice1
{
    public class TwoPointFour
    {
        public async Task waintAllComplete()
        {
//            Task task1 = Task.Delay(TimeSpan.FromSeconds(1));
//            Task task2 = Task.Delay(TimeSpan.FromSeconds(2));
//            Task task3 = Task.Delay(TimeSpan.FromSeconds(1));
//            await Task.WhenAll(task1, task2, task3);

            Task task4 = Task.FromResult(3);
            Task task5 = Task.FromResult(5);
            Task task6 = Task.FromResult(7);

            //int[] results = await Task.WhenAll(task4, task5, task6);
        }

        static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
        {
            var httpClient = new HttpClient();
            
            // Define what we're going to do for each URL.
            var downloads = urls.Select(url => httpClient.GetStringAsync(url));
        
            // Note that no tasks have actually started yet because the sequence is not evaluated.
            // Start all URLs downloading simultaneously.
            Task<string>[] downloadTasks = downloads.ToArray();
            
            // Now the tasks have all started.
            // Asynchronously wait for all downloads to complete.
            string[] htmlPages = await Task.WhenAll(downloadTasks);
            return string.Concat(htmlPages);
        }

        /// <summary>
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        // This method now prints "1", "2", and "3".
        public static async Task ProcessTasksAsync()
        {
            // Create a sequence of tasks.
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(3);
            Task<int> taskC = DelayAndReturnAsync(1);
            var tasks = new[] { taskA, taskB, taskC };
            var processingTasks = tasks.Select(async t =>
            {
                var result = await t;
                Trace.WriteLine(result);
            }).ToArray();
            // Await all processing to complete
            await Task.WhenAll(processingTasks);
        }

    }
}