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
            _types = assembly.GetTypes();
            _types = _types.OrderBy(type => type.FullName).ToArray();
        }

        private static void OutputSortedMemberTypes()
        {
            foreach (var type in _types)
            {
                var members = type.GetMembers();
                var memberTypes = members.Where(member => 
                    member.MemberType == MemberTypes.Property ||
                    member.MemberType == MemberTypes.Field ||
                    member.MemberType == MemberTypes.NestedType);
                memberTypes = memberTypes.OrderBy(memberType => memberType.Name).ToArray();
                Console.WriteLine(type.FullName);
                foreach (var memberType in memberTypes)
                {
                    Console.WriteLine(memberType.Name);
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Input path to Dll file");
            var path = Console.ReadLine();
            try
            {
                GetTypes(path);
                OutputSortedMemberTypes();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}