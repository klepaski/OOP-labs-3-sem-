using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Programmer
    {
        public delegate void Language(List<string> list, string message);
        public event Language Rename;
        public event Language NewProperty;


        public void Edit(List<string> list, string m)
        {
            Console.Write("\n\nВведите номер объекта (1 - 5), который хотите изменить: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите новый объект: ");
            string name = Console.ReadLine();

            list[number - 1] = name;
            Rename?.Invoke(list, "Изменено.\n");
        }



        public void Upload(List<string> list, string m)
        {
            Console.Write("\nВведите объект, который хотите добавить: ");
            string name = Console.ReadLine();
            list.Add(name);
            NewProperty?.Invoke(list, "Добавлено.\n");
        }
    }
}