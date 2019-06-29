using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr6
{
    class Program
    {
        class SuperList<T>
        {
            List<T> l = new List<T>();
            public void Push(T value)
            {
                l.Add(value);
            }
            public T Search(T value)
            {

                if (l.Contains(value)) return value;
                try
                {
                    throw new Exception($"Значение {value} не содержится");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return value;
            }
        }
        class Match
        {
            public delegate void d(Fan x, Fan y);
            public event d goal;
            public void Goal(Fan x, Fan y)
            {
                goal(x, y);
            }
        }
        class Fan
        {
            public void Goal()
            {
                Console.WriteLine("Goal!!!!");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Первое задание");
            SuperList<string> sl = new SuperList<string>();
            sl.Push("first");
            if (sl.Search("first") == "first") Console.WriteLine("Значение first содержится");
            sl.Search("second");
            Console.WriteLine();


            Console.WriteLine("Второе задание");
            string[] s = { "Osipovichi", "Obshchaga", "BSTU" };
            var j = s.Where(i => i[0] == 'B' && i.Length == 4);
            foreach (string z in j)
            {
                Console.WriteLine(z);
            }
            Console.WriteLine();


            Console.WriteLine("Третье задание");
            Fan x = new Fan();
            Fan y = new Fan();
            Match m = new Match();

            m.goal += (Fan a, Fan b) =>
            {
                a.Goal();
                b.Goal();
            };
            m.Goal(x, y);
        }
    }
}
