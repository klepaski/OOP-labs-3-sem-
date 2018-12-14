using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Task 1-a
            Reflector.WriteClassInfo("Lab12.MyType");

            //Task 1-b
            Console.WriteLine("----MyType:");
            Reflector.ClassPublicMethods("Lab12.MyType");

            Console.WriteLine("\n----Reflector:");
            Reflector.ClassPublicMethods("Lab12.Reflector");

            //Task 1-c
            Console.WriteLine();
            Reflector.PropertiesAndFields();

            //Task 1-d
            Console.WriteLine("\n----Interfaces in MyType:");
            Reflector.InterfacesInClass();

            //Task 1-e
            Console.WriteLine("\n----Methods with specified param:");
            Reflector.MethodsByParametres("Lab12.MyType", "Int32 value");

            Console.ReadLine();
        }
    }
}
