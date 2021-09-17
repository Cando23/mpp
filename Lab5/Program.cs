using System;
using System.Threading;
namespace Lab5
{
   static class Program
    {
        static void Main(string[] args)
        {
            TaskQueue.TaskDelegate[] array =  {Display, Factorial, Cycle};
            Parallel.WaitAll(array);
        }
        static void Display()
        {
            Console.WriteLine($"Выполняется поток {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Cycle()
        {
            int result = 1;
 
            for (int i = 1; i <= 10000; i++)
            {
                result += i;
            }
            Console.WriteLine($"Выполняется поток {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Результат {result} потока {Thread.CurrentThread.ManagedThreadId}");
     
        }
        static void Factorial()
        {
            int result = 1;
 
            for (int i = 1; i <= 10; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется поток {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Результат {result} потока {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}