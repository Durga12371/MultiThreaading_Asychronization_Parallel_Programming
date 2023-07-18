using System;
using System.Threading;

namespace ThreadSpinner
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting program...");

            // Create a thread spinner
            var spinner = new ThreadSpinner();

            // Start the spinner
            spinner.Start();

            // Simulate some work
            Thread.Sleep(3000);

            // Signal the spinner to stop
            spinner.Stop();

            Console.WriteLine("Program complete.");
        }
    }

    class ThreadSpinner
    {
        private bool spinning;
        private Thread spinnerThread;

        public void Start()
        {
            if (spinning)
                return;

            spinning = true;
            spinnerThread = new Thread(Spin);
            spinnerThread.Start();
        }

        public void Stop()
        {
            spinning = false;
            spinnerThread.Join();
        }

        private void Spin()
        {
            while (spinning)
            {
                Console.Write("-");
                Thread.Sleep(200);
                Console.Write("\\");
                Thread.Sleep(200);
                Console.Write("|");
                Thread.Sleep(200);
                Console.Write("/");
                Thread.Sleep(200);
                Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);
            }
        }
    }
}
