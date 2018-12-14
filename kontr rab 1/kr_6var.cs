using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_6var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.UInt64.MaxValue);

            string str = "Картон";
            Console.WriteLine($"Индекс первой буквы 'о' в слове {str} - " + str.IndexOf('о'));

            char[][] arrSt = new char[3][];
            arrSt[0] = new char[1] { 'a' };
            arrSt[1] = new char[2] { 'b', 'c' };
            arrSt[2] = new char[3] { 'd', 'e', 'f' };

            Console.WriteLine("\n");
            for (int i = 0; i < 1; ++i)
                Console.Write(arrSt[0][i] + "  ");
            
            Console.WriteLine();
            for (int i = 0; i < 2; ++i)
                Console.Write(arrSt[1][i] + "  ");
            
            Console.WriteLine();
            for (int i = 0; i < 3; ++i)
                Console.Write(arrSt[2][i] + "  ");



            Button b1 = new Button(100,40);
            Button b2 = new Button(200,36);
            bool res = b1.Equals(b2);
            Console.WriteLine("\nb1 эквивалентно b2? - " + res);
            Button.color = "синий";


            Student st = new Student();
            IThink st1 = st;
            IDo st2 = st;
            st1.Future();
            st2.Future();

            Console.ReadLine();
        }
        sealed class Button
        {
            private int heigh;
            private int width;
            public static string color = "красный";

            public Button (int h, int w)
            {
                this.heigh = h;
                this.width = w;
            }

            public override bool Equals(Object obj)
            {
                if (obj == null)
                    return false;
                Button but = obj as Button;
                if (but as Button == null)
                    return false;
                return (but.heigh == this.heigh && but.width == this.width);
            }
        }
        interface IThink
        {
            void Future();
        }
        interface IDo
        {
            void Future();
        }
        class Student : IThink, IDo
        {
            void IThink.Future() =>
                Console.WriteLine("...");
            void IDo.Future() =>
                Console.WriteLine("12345");
        }
    }
}
