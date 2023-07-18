using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
           
        List<int> numbers = Enumerable.Range(1, 10).ToList();

        Parallel.ForEach(numbers, (number) =>
        {
            Console.WriteLine($"Processing number in Parallel.ForEach: {number}, Thread ID: {Task.CurrentId}");
            // Perform some processing on the number
        });

        Console.WriteLine("-----------------------------------");

        var query = numbers.AsParallel()
                           .Where(n => n % 2 == 0)
                           .Select(n =>
                           {
                               Console.WriteLine($"Processing number in AsParallel: {n}, Thread ID: {Task.CurrentId}");
                               return n * n;
                           });

        foreach (var result in query)
        {
            Console.WriteLine($"Result: {result}");
        }

        Console.WriteLine("-----------------------------------");

        Parallel.Invoke(
            () => DoSomething("Task 1"),
            () => DoSomething("Task 2"),
            () => DoSomething("Task 3"),
            () => DoSomething("Task 4")
        );

        Console.WriteLine("All tasks completed");
    }

    static void DoSomething(string taskName)
    {
        Console.WriteLine($"Task '{taskName}' is running on thread ID {Task.CurrentId}");
        // Perform some task-specific operations
    }
}
