using System;
using System.Threading.Tasks;

namespace AsyncPractice1
{
    
    interface IMyAsyncInterface
    {
        Task<int> GetValueAsync();
    }

    class MySynchronousImplementation : IMyAsyncInterface
    {
        //Caching: avoid result hit garbage-collection
        private static readonly Task<int> zeroTask = Task.FromResult(0);

        public Task<int> GetValueAsync()
        {
            // already com‐pleted with the specified value
            return Task.FromResult(13);
        }
        
        public static Task<int> GetValueAsyncCached()
        {
            //use cache variable.
            return zeroTask;
        }

        static Task<T> NotImplementedAsync<T>()
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetException(new NotImplementedException());
            return tcs.Task;
        }

        
    }
    
}