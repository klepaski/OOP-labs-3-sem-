using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Вариант_7
{
    class Program
    {
        class SuperDic<T, R>
        {
            Dictionary<T, R> d = new Dictionary<T, R>();
            public void Push(T key, R value)
            {
                d.Add(key, value);
            }

            public R Search(T key)                                      /// метод поиска эл-та по ключу
            {
                R value;
                if (d.TryGetValue(key, out value)) return value;
                try
                {
                    throw new Exception($"Ключ {key} не содержится");   ///нет эл-та - исключение
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return value;
            }
        }



        delegate void Del(string s);
        static void Output(string s)
        {
            Console.Write(s + " ");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Первое задание");
            SuperDic<int, string> sd = new SuperDic<int, string>();
            sd.Push(0, "JuliaJulia");
            Console.WriteLine("Ключ 0: Значение - " + sd.Search(0));
            sd.Search(1); ///искл



            Console.WriteLine("\n\nВторое задание");
            string[] s1 = { "Брест", "Минск", "Аляска" };
            string[] s2 = { "Китай", "Рим", "Гродно" };
            var j = s1.Union(s2);
            Console.WriteLine("Количество элементов: " + j.Count());



            Console.WriteLine("\n\nТретье задание");
            Del d = Output;
            d("25");
            d("March");
            d("1917");
            Console.WriteLine();
            d("25");
            d("December");
            d("2019");

            Console.ReadLine();
        }
    }
}