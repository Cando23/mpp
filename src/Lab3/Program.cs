using System;
using System.Threading;

namespace Lab3
{
    static class Program
    {
        static readonly Mutex Mutex = new Mutex();
        private static int _x;
     
        static void Main()
        {
            for (var i = 0; i < 4; i++)
            {
                var myThread = new Thread(Count) {Name = $"Поток {i}"};
                myThread.Start();
            }
 
            Console.ReadLine();
        }

        private static void Count()
        {
            Mutex.Lock();
            _x = 1;
            for (var i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                _x++;
                Thread.Sleep(100);
            }
            Mutex.Unlock();
        }
    }
}