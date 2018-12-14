using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Programmer.Language Language;
            Programmer programmer = new Programmer();

            List<string> LP = new List<string> { "JS", "C#", "Java", "C++", "Ruby" };
            foreach(string item in LP)
            {
                Console.Write(item + "\t");
            }
            
            programmer.Rename += (list, message) =>
            {
                Console.WriteLine(message);
                foreach (string item in list)
                {
                    Console.Write(item + "\t");
                }
            };
            
            programmer.NewProperty += (list, message) =>
            {
                Console.WriteLine(message);
                foreach (string item in list)
                {
                    Console.Write(item + "\t");
                }
            };

            Language = programmer.Edit;
            Language += programmer.Upload;
            Language(LP, "");
            Console.WriteLine();


            Console.WriteLine("\n\n\n--------------Работа со строками--------------\n");

            Func<string, string> A;
            string str = "J! u.    l,, i A";

            Console.WriteLine($"Исходная строка:        {str}");
            A = StringHandler.RemoveS;
            Console.WriteLine($"Без знаков препинания:  {str = A(str)}");
            A = StringHandler.RemoveSpase;
            Console.WriteLine($"Без пробелов:           {str = A(str)}");
            A = StringHandler.Upper;
            Console.WriteLine($"Заглавными буквами:     {str = A(str)}");
            A = StringHandler.Lower;
            Console.WriteLine($"Строчными буквами:      {str = A(str)}");
            A = StringHandler.AddToString;

            Console.WriteLine($"С добавлением символа:  {str = A(str)}");

            Console.ReadKey();
        }
    }
}