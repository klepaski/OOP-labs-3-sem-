using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_1var
{
    class Program
    {
        enum PM_AM : uint
        { PM=1, AM }

        static void Main(string[] args)
        {
            Console.WriteLine((int)char.MaxValue);
            
            string s = "-1230";
            int numVal = Int32.Parse(s);
            Console.WriteLine(numVal);


            char[,,] arr = new char[2, 2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 2; k++)
                    {
                        arr[i, j, k] = 'a';
                        Console.WriteLine($"arr[{i},{j},{k}] = " + arr[i, j, k]);
                    }

            Time time = new Time();
            time.h = 5;
            time.m = 43;
            time.s = 12;
            time.someTime = (PM_AM)1;
            Console.WriteLine(time.ToString());

            Horse horse = new Horse();
            horse.name = "Юнмун";
            Console.WriteLine("Имя лошади - " + horse.name);
            horse.Run();
            

            Console.ReadLine();
        }

       class Time
       {
            public uint h { get; set; }
            public uint m { get; set; }
            public uint s { get; set; }
            public PM_AM someTime;

            public override string ToString()
            {
                string ss = s.ToString();
                string sm = m.ToString();
                string sh = h.ToString();
                string some = someTime.ToString();
                string time = "Сейчас "+ sh + ":" + sm + ":" + ss + " " + some;
                return time;
            }
       }
        interface IRun
        {
            void Run();
        }
        class Mammal
        {
            public string name;
        }
        class Horse : Mammal, IRun
        {
            public Horse() : base() { }
            public void Run()
            {
                Console.WriteLine("Число букв в имени лошади = "
                    + this.name.Length);
            }
        }
    }
}
