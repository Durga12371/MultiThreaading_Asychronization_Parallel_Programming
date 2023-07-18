using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting the process...");

        // Call the asynchronous method.
        int result = await ProcessDataAsync();

        // Use the result of the asynchronous operation.
        Console.WriteLine($"The result is: {result}");

        Console.WriteLine("Process completed.");
    }

    static async Task<int> ProcessDataAsync()
    {
        // Simulate a time-consuming calculation by introducing a delay.
        await Task.Delay(3000); // Delay of 3 seconds (3000 milliseconds).

        // Perform the calculation (e.g., adding two numbers).
        int number1 = 10;
        int number2 = 20;
        int result = number1 + number2;

        return result;
    }
}
