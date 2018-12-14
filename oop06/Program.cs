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
            Tennis ten = new Tennis();
            ten.ChooseRocket(Tennis.enumRocket.x);

            Gym gym = new Gym();
            Playground[] arrPlaygrounds = {new Tennis(), new Basketball(), new Beams(10), new Bench(), new Mats()};
            foreach (var i in arrPlaygrounds)
            {
                gym.Add(i);
            }
            gym.Show();
            gym.Remove(2);
            gym.Remove(6);///f
            gym.Show();


            
            /*________________________________________________________*/

            СontrollerGym cg = new СontrollerGym(30000);///бюджет
            Console.WriteLine("Количество снарядов:   |   Цена (каждый 12 руб):");
            cg.Add(new Shells(100));
            cg.Add(new Shells(90));
            cg.Add(new Shells(80));
            cg.Add(new Shells(166));
            cg.Add(new Shells(45));
            cg.Show();

            Console.WriteLine("_________________________________________________");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nПосле сортировки:");
            Console.ResetColor();
            cg.Sort();
            cg.Show();

            Console.WriteLine("_________________________________________________");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nВ диапазоне цены 500-1000:");
            Console.ResetColor();
            cg.СhoiceRange(500, 1000);
            cg.Show();

            

            Console.ReadLine();
        }
    }
}