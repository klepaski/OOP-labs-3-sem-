using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_5var
{
    class Program
    {
        static void Main(string[] args)
        {
            //1А.
            Console.WriteLine(System.Single.MaxValue);


            //1Б.
            string str = "Программирование";
            Console.WriteLine(str.Substring(4, 1));


            //1С.
            List<string> names = new List<string>() { "Юля", "Аня", "Наташа", "Нина" };
            foreach (string s in names)
                Console.Write(s + ", ");


            //2. Создать два объекта типа Date и сравнить их по хэш-коду
            Date d1 = new Date();
            Date d2 = new Date();
            d1.day = 12;        d1.month = 10;      d1.year = 2000;
            d2.day = 14;        d2.month = 12;      d2.year = 1996;

            Console.WriteLine($"\n\nПервая дата - {d1.day}.{d1.month}.{d1.year} год");
            Console.WriteLine($"Вторая дата - {d2.day}.{d2.month}.{d2.year} год");

            if (d1.GetHashCode() == d2.GetHashCode())
                Console.WriteLine("Хэш-коды дат равны.");
            else
                Console.WriteLine("Хэш-коды дат не равны.");


            //3. Проверить работу метода Checker
            People people = new People();
            Orator.Checker(people);



            Console.ReadLine();
        }
    }
    //2.
    partial class Date
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }


    //3.
    interface ICan
    {
        void speak();
    }
    class People : ICan
    {
        public void speak() =>
            Console.WriteLine("Я могу говорить.");
    }
    static class Orator
    {
        public static void Checker(People people)
        {
            if (people is ICan)
            {
                Console.WriteLine("\nICan поддерживается People");
                people.speak();
            }
            else
                Console.WriteLine("\nICan не поддерживается People");
        }
    }

}
