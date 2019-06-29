using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kr3
{
    class Program
    {
        ///1. Созд. обощ. класс, наслед. от колл LinkedList<T>
        /// переопр. удаление эл-та (нет - искл)

        class SuperLinkedList<T> : LinkedList<T>
        {
            public new void Remove(T item)
            {
                Console.WriteLine("Удаление " + item);
                if (!Contains(item))
                    throw new Exception("Элемента " + item + " нет в списке");
                base.Remove(item);
            }
        }

        ///3. Когда дрессер говорит UP (соб), 
        /// все лошади на дыбы (реакция)

        class Dressir
        {
            public delegate void Up();
            public event Up say_up;

            public void CommandUP()
            {
                Console.WriteLine("Дрессировщик дал команду UP!");
                say_up?.Invoke();
            }
        }

        class Horse
        {
            string name;
            public Horse(string Name)
            {
                name = Name;
            }

            public void Up()
            {
                Console.WriteLine($"Лошадь {name} встаёт на дыбы!");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                SuperLinkedList<string> sll = new SuperLinkedList<string>();        ///1. Демонстр для string с выводом и обраб искл.
                sll.AddLast("abc");
                sll.AddFirst("cсссссcc");
                foreach (string st in sll)
                {
                    Console.WriteLine(st);
                }
                // sll.Remove("dddd"); //вызывает исключение 


                
                var c = sll.Where(p => p.Length < 6);                                ///2. LINQ : выбрать эл-ты с длиной строк < шесть
                Console.WriteLine("Элементы с длиной меньше 6:");
                foreach (string st in c)
                {
                    Console.WriteLine(st);
                }


                Dressir dr = new Dressir();                                          ///3. один дрессер, 3 лошади.
                Dressir.Up command;

                Horse h1 = new Horse("Pavel");
                Horse h2 = new Horse("Kirill");
                Horse h3 = new Horse("Lesya");
                
                dr.say_up += h1.Up;
                dr.say_up += h2.Up;
                dr.say_up += h3.Up;

                command = dr.CommandUP;
                command();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}