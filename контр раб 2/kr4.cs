using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        class SuperStack<T> : Stack<T>
        {
            public static bool operator ==(SuperStack<T> p1, SuperStack<T> p2)
            {
                if (p1.Count == 0 || p2.Count == 0)
                    throw new InsufficientExecutionStackException();
                return p1.Count == p2.Count;
            }

            public static bool operator !=(SuperStack<T> p1, SuperStack<T> p2)
            {
                return p1.Count != p2.Count;
            }
        }

        class User
        {
            public void PickUp()
            {
                Console.WriteLine("User picked up phone");
            }
        }

        class Phone
        {
            public event Action Ringing;
            public void Ring()
            {
                Console.WriteLine("Phone ringing...");
                Ringing();
            }
        }


        static void Main(string[] args)
        {
            // Task 1
            int fInt = 5;
            try
            {
                int exInt = fInt / 0;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Thrown {e.GetType().FullName}");
                Console.WriteLine(e.StackTrace);
            }
            // Task 2
            string[] stringArray = { "January", "February", "March", "April", "May", "June", "June", "February" };
            int size = stringArray.Where(t => t == "June").Count();
            Console.WriteLine($"Size: {size}");
            // Task 3
            Phone phone = new Phone();
            User user = new User();
            phone.Ringing += user.PickUp;
            // executing
            phone.Ring();

            Console.ReadLine();
        }
    }
}