using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_4var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ushort.MaxValue);

            string str = "Юля_123_Чистякова";
            string sub_str = "123";
            int index = str.IndexOf(sub_str);
            if (index == -1)
                Console.WriteLine("Подстроки нет в строке");
            else
                Console.WriteLine("Подстрока содержится в строке");


            double[,] arr = new double[2,2];
            Random rand = new Random();

            for (int i=0; i<2; i++)
                for (int j=0; j<2; j++)
                {
                    arr[i,j] = rand.Next(1, 99);
                    Console.Write(arr[i, j] + "  ");
                }

            Date d1 = new Date();
            Date d2 = new Date();
            d1.day = 1;  d1.month = 7;
            d2.day = 8;  d2.month = 6;
            Console.WriteLine("\nd1 эквивалентно d2? - " + d1.Equals(d2));


            Student st = new Student();
            Prepod pr = new Prepod();
            st.minus();
            st.plus();
            pr.plus();

            Console.ReadLine();
        }
        class Date
        {
            private readonly int yy = 1998;
            private int dd;
            private int mm;

            public int day { get => dd; set { dd=value; } }
            public int month { get => mm; set { mm=value; } }
            public int year { get => yy; }

            public override bool Equals(Object obj)
            {
                if (obj == null)
                    return false;
                Date d = obj as Date;
                if (d as Date == null)
                    return false;
                
                return (d.dd == this.dd && d.mm == this.mm);
            }
        }
        interface IGood
        {
            void plus();
        }
        interface IBad
        {
            void minus();
        }
        abstract class People { }
        class Student : People, IGood, IBad
        {
            public void plus() =>
                Console.WriteLine("Ученик складывает.");
            public void minus() =>
                Console.WriteLine("Ученик вычитает.");
        }
        class Prepod : People, IGood
        {
            public void plus() =>
                Console.WriteLine("Преподаватель складывает.");
        }
    }
}
