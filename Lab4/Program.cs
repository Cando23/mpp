using System;
using System.Linq;
using System.Reflection;

namespace Lab4
{
    class Program
    {
        private static Type[] _types;
        static void GetTypes(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path ?? throw new InvalidOperationException());
            _types = assembly.GetTypes();
            _types = _types.OrderBy(type => type.FullName).ToArray();
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Input path to Dll file");
            string path = Console.ReadLine();
            try
            {
                GetTypes(path);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}