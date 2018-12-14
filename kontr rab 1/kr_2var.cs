using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_2var
{
    class Program
    {
        enum PM_AM : uint
        { PM = 1, AM }

        static void Main(string[] args)
        {
            Console.WriteLine(double.MinValue);

            Console.WriteLine("Введите две строки");
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            string s = s1 + s2;
            Console.WriteLine("Объединение этих строк - " + s);


           
            int[][] arrSt = new int[2][];
            arrSt[0] = new int[3];
            arrSt[1] = new int[5];

            Random rand = new Random();
            for (int i = 0; i < 3; ++i)
            {
                arrSt[0][i] = rand.Next(1,99);
                Console.Write(arrSt[0][i] + "  ");
            }
            Console.WriteLine();

            for (int i = 0; i < 5; ++i)
            {
                arrSt[1][i] = rand.Next(1,99);
                Console.Write(arrSt[1][i] + "  ");
            }


            Time t1 = new Time();
            Time t2 = new Time();
            t1.Minutes = 45;
            t2.Minutes = 23;
            t1.Seconds = 12;
            t2.Seconds = 2;
            if (t1 == t2) Console.WriteLine("\nt1 равно t2");
            if (t1 > t2) Console.WriteLine("\nt1 больше t2");


            Student st = new Student();
            Prepod prep = new Prepod();
            IStudy inter_prep = prep;
            st.study();
            prep.study();
            inter_prep.study();
            
            
            Console.ReadLine();
        }

        class Time
        {
            private const int hh = 4;
            public int Minutes { get; set; }
            public int Seconds { get; set; }
            public int Hours { get => hh; }

            //перегрузить операции == и < для объектов Time
            public static bool operator !=(Time a, Time b)
            {
                if (a.Minutes != b.Minutes || (a.Seconds != b.Seconds))
                    return true;
                else return false;
            }
            public static bool operator==(Time a, Time b)
            {
                if (a != b) return false;
                else return true;
            }
            public static bool operator >(Time a, Time b)
            {
                if (a.Minutes > b.Minutes || ((a.Minutes == b.Minutes) && (a.Seconds > b.Seconds)))
                    return true;
                else return false;
            }
            public static bool operator <(Time a, Time b)
            {
                if (b > a) return true;
                else return false;
            }
        }
        interface IStudy
        {
            void study();
        }
        class Student : IStudy
        {
            public void study() =>
                Console.WriteLine("Учусь.");
        }
        class Prepod : Student, IStudy
        {
            void IStudy.study() =>
                Console.WriteLine("Учу.");
        }
    }
}