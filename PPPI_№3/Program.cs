using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingAndAsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---:Multithreading and Asynchronous Demo:---");

            // Call the methods that demonstrate multithreading
            ThreadDemo();
            ThreadDemo1();
            ThreadDemo2();
            ThreadDemo3();

            // Call the methods that demonstrate asynchronous programming
            AsyncDemo().Wait();
            AsyncDemo1().Wait();
            AsyncDemo2().Wait();
            AsyncDemo3().Wait();

            ThreadPoolDemo();

            Console.ReadLine();
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Child Thread: {i}");
            }
        }

        // Methods that demonstrates working with the Thread class
        static void ThreadDemo()
        {
            Console.WriteLine("ThreadDemo started.");
            Thread t = new Thread(PrintNumbers);
            t.Start();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Main Thread: {i}");
            }
            Console.WriteLine("ThreadDemo completed.");
        }

        static void ThreadDemo1()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine("Thread 1 is starting...");
                Thread.Sleep(2000);
                Console.WriteLine("Thread 1 is ending...");
            });

            t.Start();
        }

        static void ThreadDemo2()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine("Thread 2 is starting...");
                Thread.Sleep(4000);
                Console.WriteLine("Thread 2 is ending...");
            });

            t.Start();
        }

        static void ThreadDemo3()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine("Thread 3 is starting...");
                Thread.Sleep(1000);
                Console.WriteLine("Thread 3 is ending...");
            });

            t.Start();
        }

        // Methods that demonstrates working with the Async - Await class
        static async Task AsyncDemo()
        {
            Console.WriteLine("AsyncAwaitDemo started.");
            Console.WriteLine($"Result from MethodOne: {await MethodOneAsync()}");
            Console.WriteLine($"Result from MethodTwo: {await MethodTwoAsync()}");
            Console.WriteLine($"Result from MethodThree: {await MethodThreeAsync()}");
            Console.WriteLine("AsyncAwaitDemo completed.");
        }

        static async Task<int> MethodOneAsync()
        {
            await Task.Delay(1000);
            return 1;
        }

        static async Task<int> MethodTwoAsync()
        {
            await Task.Delay(2000);
            return 2;
        }

        static async Task<int> MethodThreeAsync()
        {
            await Task.Delay(3000);
            return 3;
        }

        static async Task AsyncDemo1()
        {
            Console.WriteLine("AsyncDemo1 is starting...");
            await Task.Delay(3000);
            Console.WriteLine("AsyncDemo1 is ending...");
        }

        static async Task AsyncDemo2()
        {
            Console.WriteLine("AsyncDemo2 is starting...");
            await Task.Delay(5000);
            Console.WriteLine("AsyncDemo2 is ending...");
        }

        static async Task AsyncDemo3()
        {
            Console.WriteLine("AsyncDemo3 is starting...");
            await Task.Delay(2000);
            Console.WriteLine("AsyncDemo3 is ending...");
        }

        static void PrintMessage(object message)
        {
            Console.WriteLine(message);
        }

        static void ThreadPoolDemo()
        {
            Console.WriteLine("ThreadPoolDemo started.");
            ThreadPool.QueueUserWorkItem(PrintMessage, "Hello from the Thread Pool!");
            Console.WriteLine("ThreadPoolDemo completed.");
        }
    }
}