using System;

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
        public static DynamicList<bool> List;
       
        static void Main(string[] args)
        {
            List = new DynamicList<bool>
            {
             true
            };
            List.RemoveAt(5);
            Output();
            List[0] = false;
            Output();
            List.Remove(true);
            Output();
            List.Add(true);
            List.RemoveAt(4);
            Output();
            Console.WriteLine(List[0].ToString());
            List.Clear();
            Output();
        }
    }
}