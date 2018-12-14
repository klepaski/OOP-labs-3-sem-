using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n********* Б Р У С Ь Я *********");
            Console.ResetColor();
            Playground brus = new Beams(10);
            brus.GetExp();
            brus.DoExercise();
            brus.DoExercise();
            brus.Relax(10);
            brus.GetExp();

            if (brus is Playground)
            {
                Console.WriteLine($"{brus} is Playground ");    ///true
            }
            
            

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n********* С К А М Е Й К А *********");
            Console.ResetColor();
            Playground skam = new Bench();
            skam.DoExercise();
            skam.Relax(30);
            if (skam is Beams)
            {
                Console.WriteLine($"{skam} is Beams ");         ///false
            }



            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n********* М А Т Ы *********");
            Console.ResetColor();
            Playground mat = new Mats();
            mat.DoExercise();
            mat.Relax(2);



            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n********* Б А С К Е Т Б О Л *********");
            Console.ResetColor();
            Basketball bask = new Basketball();
            IBacketBall bask_ball = bask;

            bask.Take_Invent();
            bask.DoExercise();
            bask.Play();
            bask.Throw();
            bask.Back_Invent();
            bask.GetExp();
            
            if (bask_ball as Beams != null)
            {
                Console.WriteLine($"{bask_ball} as Beams ");        ///false
            }
            if (bask_ball as Playground != null)
            {
                Console.WriteLine($"{bask_ball} as Playground ");   ///true
            }





            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n********* Т Е Н Н И С *********");
            Console.ResetColor();

            Tennis ten = new Tennis();
            ITennisBall ten_ball = ten;
            ten.DoExercise();           ///а.к.
            ten_ball.DoExercise();      ///интер.

            Console.WriteLine($"'ten':  To string()   - {ten.ToString()}");         ///тенис
            Console.WriteLine($"        GetHashCode() - {ten.GetHashCode()} ");     ///861
            if (ten.Equals(ten_ball))
                Console.WriteLine("        Equal() to ten_ball");       ///true
            else
                Console.WriteLine("        Not Equal() to ten_ball");






            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n********* МАССИВ ССЫЛОК НА ОБЪЕКТЫ КЛАССОВ *********");
            Console.ResetColor();

            Playground[] arrPl = { skam, mat, brus, bask, ten };
            Printer printer = new Printer();
            
            foreach (var i in arrPl)
            {
                printer.iAmPrinting(i);
            }
            ///скамейка, маты, брусья, баскетбол, теннис
            Console.ReadLine();
        }
    }
}