using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Using tasks to perform work in parallel
        Task task1 = Task.Run(() => PerformTask("Task 1"));
        Task task2 = Task.Run(() => PerformTask("Task 2"));

        Task.WaitAll(task1, task2);

        // Using Parallel.For to process a loop in parallel
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Parallel.For(0, numbers.Length, i =>
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Processed {numbers[i]}");
            Thread.Sleep(1000);
        });

        // Using lock to synchronize access to a shared resource
        int sharedValue = 0;
        object lockObject = new object();

        Parallel.For(0, 10, i =>
        {
            // Locking to ensure thread-safe access to sharedValue
            lock (lockObject)
            {
                sharedValue++;
            }
        });

        Console.WriteLine("Final shared value: " + sharedValue);

        Console.ReadLine();
    }

    static void PerformTask(string taskName)
    {
        Console.WriteLine($"Starting {taskName} on Thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000);
        Console.WriteLine($"Completed {taskName} on Thread {Thread.CurrentThread.ManagedThreadId}");
    }
}
