using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab4
{
    static class Program
    {
        private static Type[] _types;

        private static void GetTypes(string path)
        {
            var assembly = Assembly.LoadFrom(path ?? throw new InvalidOperationException());
            _types = assembly.GetExportedTypes();
            _types = _types.OrderBy(type => type.FullName).ToArray();
        }

        private static void OutputExportedTypes()
        {
            foreach (var type in _types)
            {
                Console.WriteLine(type.FullName);
            }
        }

        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }
            var path = args[0];
            path = path.Replace("\"","/");
            try
            {
                GetTypes(path);
                OutputExportedTypes();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}