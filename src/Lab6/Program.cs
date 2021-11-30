using System;
using System.Collections;

namespace Lab6
{
    class Program
    {
        static void Output()
        {
            foreach (var i in List)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine(new string('-', 30));
        }
        public static DynamicList<int> List;
       
        static void Main(string[] args)
        {
            List = new DynamicList<int>();
            List.Add(4);
            Output();
            List.Remove(4);
            Output();
        }
    }
}