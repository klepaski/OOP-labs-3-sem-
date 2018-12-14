using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_8var
{
    enum months
    { jan = 1, feb, mar, apr, may, jun, jul, aug, sept, oct, nov, dec }


    class Program
    {
       static void Main(string[] args)
       {
            Console.WriteLine((int)months.jan);
            Console.WriteLine((int)months.feb);
            Console.WriteLine((int)months.mar);
            Console.WriteLine((int)months.apr);
            Console.WriteLine((int)months.may);
            Console.WriteLine((int)months.jun);
            Console.WriteLine((int)months.jul);
            Console.WriteLine((int)months.aug);
            Console.WriteLine((int)months.sept);
            Console.WriteLine((int)months.oct);
            Console.WriteLine((int)months.nov);
            Console.WriteLine((int)months.dec);

            string str = "123.345.678";
            string[] words = str.Split(new char[] { '.' });        ///разделение строки на слова
            foreach (string s in words) Console.WriteLine(s);

            int[] arr = new int[3] { 12, 24, 36 };
            string a0 = arr[0].ToString();
            string a1 = arr[1].ToString();
            string a2 = arr[2].ToString();
            Console.WriteLine(a0 + a1 + a2);


            Computer c1 = new Computer();
            Computer c2 = new Computer();
            c1.number = 3;
            c2.number = 4;
            IComparable cc1 = c1;
            int i = cc1.CompareTo(c2);


            Case cc = new Case();
            IGood cc2 = cc;
            cc.Fine();
            cc2.Fine();

            Console.ReadLine();
       }
        class Computer : IComparable
        {
            public static readonly int op = 512;
            public static int freq = 4;
            public int number;

            int IComparable.CompareTo(Object obj)
            {
                Computer c = obj as Computer;
                if (c.number == this.number)
                {
                    Console.WriteLine("Объекты равны");
                    return 0;
                }
                if (c.number > this.number)
                {
                    Console.WriteLine($"{c.number} больше чем {this.number}");
                    return 1;
                }
                else
                {
                    Console.WriteLine($"{c.number} меньше чем {this.number}");
                    return -1;
                }
            }
        }
        interface IGood
        {
            void Fine();
        }
        abstract class Something : IGood
        {
            public abstract void ItsOk();
            public void Fine() =>
                Console.WriteLine("Я в порядке (abstract class)");
            void IGood.Fine() =>
                Console.WriteLine("Я в порядке (interface)");

        }
        class Case : Something
        {
            public override void ItsOk() =>
                Console.WriteLine("Все хорошо.");
        }
    }
}
