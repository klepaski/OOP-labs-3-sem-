using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_9var
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 56;
            int b = 24;
            string c = (a + b).ToString();
            Console.WriteLine(c);

            string str = "Happy summer!";
            string end = str.Substring(str.Length-1,1);
            str = str + end;
            Console.WriteLine(str);

            string[,] arr = new string[2, 3] { { "one", "two", "three" }, { "four", "five", "six" } };
            int sum = 0;
            for (int i=0; i<2; i++)
                for (int j=0; j<3; j++)
                {
                    Console.Write(arr[i, j] + "  ");
                    sum += arr[i, j].Length;
                }
            Console.WriteLine("\nОбщее число букв в массиве = " + sum);

            Point p1 = new Point();
            Point p2 = new Point();
            p1.x = 8;   p1.y = 9;
            p2.x = 7;   p2.y = 6;
            int res = p1.CompareTo(p2);
            if (res == 0)
                Console.WriteLine("p1 = p2");
            if (res == 1)
                Console.WriteLine("p2 > p1");
            if (res == -1)
                Console.WriteLine("p2 < p1");


            Bank bank = new Bank();
            Cassa cassa = new Cassa();
            Console.WriteLine("Count от Bank = " + bank.Count(100));
            Console.WriteLine("Count от Cassa = " + cassa.Count(100));

            Console.ReadLine();
        }
        class Point : IComparable
        {
            public int x;
            public int y;

            public int CompareTo(Object obj)
            {
                Point p = obj as Point;
                if (p.x == this.x && p.y == this.y)
                    return 0;
                if (p.x + p.y > this.x + this.y)
                    return 1;
                else return -1;
            }
        }
        interface IBank
        {
            double Count(int sum);
        }
        class Bank : IBank
        {
            public double Count (int sum)
            {
                return (sum * 0.9);
            }
        }
        class Cassa : Bank, IBank
        {
            new public double Count(int sum)
            {
                return (0.1 * base.Count(sum));
            }
        }
    }
}
