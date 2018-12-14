using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_3var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Decimal.MaxValue);

            Console.WriteLine("Введите две строки: ");
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            int result = String.Compare(s1, s2);

            if (result == 0)
                Console.WriteLine("Строки {0} и {1} идентичны", s1, s2);
            else
                Console.WriteLine("Строки {0} и {1} разные", s1, s2);


            string[] arr = new string[3];
            arr[0] = "один";
            arr[1] = "два";
            arr[2] = "три";
            for (int i = arr.Length; i < 0; i--)
            {
                Console.Write(arr[i] + "  ");
            }

            Month m = new Month();
            Console.WriteLine("\nОбращение к элементам массива по индексу:");
            Console.WriteLine(m[0]);
            Console.WriteLine(m[7]);
            Console.WriteLine(m[13]);

            Student st = new Student();
            st.name = "Никита";
            IDo inter_st = st;
            st.coding();
            inter_st.coding();

            Console.ReadLine();

        }
        class Month
        {
            private string[] months;
            private const int size = 12;

            public Month()
            {
                months = new string[size];
                this.months[0] = "янв";
                this.months[1] = "фев";
                this.months[2] = "март";
                this.months[3] = "апр";
                this.months[4] = "май";
                this.months[5] = "июн";
                this.months[6] = "июл";
                this.months[7] = "авг";
                this.months[8] = "сен";
                this.months[9] = "окт";
                this.months[10] = "ноя";
                this.months[11] = "дек";
            }
            public string this[int index]
            {
                get
                {
                    if (index >= 00 && index < size)
                        return $"Индексу [{index}] соответствует элемент {months[index]}.";
                    else
                        return $"Индекс [{index}] является недопустимым.";
                }
            }
        }
        interface IDo
        {
            void coding();
        }
        abstract class Programmer
        {
            public abstract void coding();
        }
        class Student : Programmer, IDo
        {
            public string name { get; set; }
            public override void coding() =>
                Console.WriteLine("Я программирую (абс.класс)");
            void IDo.coding() =>
                Console.WriteLine("Я программирую (интерфейс)");
        }
    }
}
