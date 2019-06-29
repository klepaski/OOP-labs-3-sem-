using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Вариант_5
{
    class Program
    {
        class SuperQueue<T> where T : struct            ///сод станд кол Queue<T>
        {
            Queue<T> q = new Queue<T>();
            public void Add(T value)
            {
                if (q.Count < 3)
                {
                    q.Enqueue(value);
                    Console.WriteLine($"Элемент {value} успешно добавлен");
                    return;
                }
                try
                {
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Лимит элементов превышен");
                }
            }
        }
        class User
        {
            public delegate void d(Window x, Window y);
            public event d move;
            public void Move(Window x, Window y)
            {
                move(x, y);
            }
        }
        class Window
        {
            public void Move()
            {
                Console.WriteLine("Размер экрана изменен");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Первое задание");
            SuperQueue<DateTime> sq = new SuperQueue<DateTime>();
            sq.Add(new DateTime());
            sq.Add(new DateTime());
            sq.Add(new DateTime());
            sq.Add(new DateTime()); ///искл
            Console.WriteLine();


            Console.WriteLine("Второе задание");
            string[] s = { "Proga", "CSIS", "IGIG", "DCP", "OSI" };
            var c = s.Take(3).OrderBy(t => t[0]).OrderByDescending(t => t.Length);
            foreach (string z in c)
                Console.WriteLine(z);
            Console.WriteLine();


            Console.WriteLine("Третье задание");
            Window x = new Window();
            Window y = new Window();
            User u = new User();

            u.move += (Window a, Window b) =>
            {
                a.Move();
                b.Move();
            };
            u.Move(x, y);
        }
    }
}