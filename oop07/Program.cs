using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using oop5;
using oop7;


namespace oop7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Gym gym = new Gym();
                gym.Add(new Tennis());
                gym.Add(new Basketball());
                //gym.Remove(4); //index  1
                

                СontrollerGym contr_gym = new СontrollerGym(1000);
                contr_gym.Add(new Shells(50));
                //contr_gym.Add(new Shells(40)); //budget 2

                
                Shells sh = new Shells(32);
                //sh.Amount = 2000; //max 3 

                
                Gym gym2 = null;
                //gym2.Add(new Beams(1));
                Debug.Assert(gym2 != null, "Ссылка на объект не указывает на экземпляр объекта");
                

                int b, a = 2, c = 0;
                //b = a / c;
            }

            catch (IndexException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (BudgetException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MaxException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Переход к finally.");
            }

            Console.ReadLine();
        }
    }
}