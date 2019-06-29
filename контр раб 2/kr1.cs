using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer
{
    class Program
    {
        class SuperList<T> : List<T> where T : class
        {
            public static SuperList<T> operator +(SuperList<T> item, T it)
            {
                Console.WriteLine("Добавление " + it);
                if (item.Count >= 3)
                {
                    throw new IndexOutOfRangeException("Элементу " + item + " нет места");
                }
                else
                {
                    item.Add(it);
                }
                return item;
            }
        }

        class Doctor
        {
            public delegate void Command();
            public event Command say_heal;

            public void CommandHeal()
            {
                Console.WriteLine("Врач скомандовал лечиться");
                say_heal?.Invoke();
            }
        }

        class Patient
        {
            public void Heal()
            {
                Console.WriteLine("Доктор лечит");
            }
        }


        static void Main(string[] args)
        {
            try
            {
                SuperList<string> sll = new SuperList<string>();
                sll.Add("abc");
                sll.Add("cсссссcc");
                sll = sll + "hi";
                foreach (string st in sll)
                {
                    Console.WriteLine(st);
                }


                Console.WriteLine("Элемент,равный заданному ");
                Console.WriteLine(sll.First(p => p.Equals("abc")));



                Doctor dr = new Doctor();
                Patient pat = new Patient();

                dr.say_heal += pat.Heal;
                dr.CommandHeal();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}