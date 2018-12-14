using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Lab12
{
    public class Reflector
    {
        public static void WriteClassInfo(string className)              ///вывод содержимое класса в текст. файл
        {
            Type type = Type.GetType(className);
            StreamWriter file = new StreamWriter("D:/ClassInfo.txt");

            foreach (var item in type.GetMembers())
            {
                file.WriteLine(item.Name);
            }
            file.Close();
        }


        public static void ClassPublicMethods(string className)         ///извлекает все общедоступ. методы класса
        {
            Type type = Type.GetType(className);

            foreach (var item in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                Console.WriteLine(item);
            }
        }


        public static void PropertiesAndFields()                        ///получ. инфу о полях и свойствах класса
        {
            Type type = typeof(MyType);

            Console.WriteLine("----Fields of MyType:");
            foreach (var item in type.GetFields())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n----Properties of MyType:");
            foreach (var item in type.GetProperties())
            {
                Console.WriteLine(item);
            }
        }


        public static void InterfacesInClass()                            ///получ. все реализованные классом интерфейсы
        {
            Type type = typeof(MyType);

            foreach (var item in type.GetInterfaces())
            {
                Console.WriteLine(item);
            }
        }

        
        public static void MethodsByParametres(string className, string param)  ///вывод имен методов, кот. содержат зад. тип параметра
        {
            Type type = Type.GetType(className);

            foreach (var item in type.GetMethods())
            {
                foreach (var par in item.GetParameters())
                {
                    if (par.ToString() == param)
                    {
                        Console.WriteLine(par);
                    }
                }
            }
        }
    }
}
