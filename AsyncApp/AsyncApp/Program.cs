﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncApp
{
    class Program
    {
        private const string URL = "https://docs.microsoft.com/en-us/dotnet/csharp/csharp";

        static void Main(string[] args)
        {
            DoSynchronousWork();
            var someTask = DoSomethingAsync();
            DoSynchronousWorkAfterAwait();
            someTask.Wait(); 
            Console.ReadLine();
        }
        public static void DoSynchronousWork()
        {
            
            Console.WriteLine("1. Doing some work synchronously");
        }

        static async Task DoSomethingAsync() 
        {
            Console.WriteLine("2. Async task has started...");
            await GetStringAsync(); 
        }

        static async Task GetStringAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
                string result = await httpClient.GetStringAsync(URL); 

                
                Console.WriteLine("4. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5. The length of http Get for {URL}");
                Console.WriteLine($"6. {result.Length} character");
            }
        }

        static void DoSynchronousWorkAfterAwait()
        {
            
            Console.WriteLine("7. While waiting for the async task to finish, we can do some unrelated work...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
