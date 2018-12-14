using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            ///1а. определите пер-ные примитивных типов
            bool b = true;
            byte bb = 255;          ///1 (0,255)
            sbyte sbb = 127;        ///1 (-128,127)
            short sh = 102;         ///2
            ushort ush = 103;       ///4
            int ii = 10;            ///4
            uint uii = 10U;         ///4
            long l = 60L;           ///8
            ulong ul = 60UL;        ///8
            float f = 3;            ///4
            double d = 456;         ///8
            char ch = 'A';          ///2
            decimal dm = 2.12m;
            Console.WriteLine("b = {0}, bb = {1}, sbb = {2}, sh = {3}, ush = {4}", b, bb, sbb, sh, ush);
            Console.WriteLine("i = {0}, ui = {1}, l = {2}, ul = {3}", ii, uii, l, ul);
            Console.WriteLine("f = {0}, d = {1}, ch = {2}, dm = {3}", f, d, ch, dm);

            int num = 123;          ///неявное
            long bignum = num;
            double dd = 1234.7;     ///явное
            int idd;
            idd = (int)dd;

            Object o = ii;          ///упаковка
            int x = (int)o;         ///распаковка

            var ff = 0.34F;         ///неявно типиз.
            Console.WriteLine(ff);
            
            Nullable<int> x1 = 324;
            Console.WriteLine(x1+"\n___________________________________________________\n\n");




            ///2а. Объявите строковые литералы. Сравните их.
            string t = "hello";
            string p = "word";
            int result = String.Compare(t, p);

            if (result == 0)
                Console.WriteLine("Строки {0} и {1} идентичны", t, p);
            else
                Console.WriteLine("Строки {0} и {1} разные", t, p);



            //2b. Создайте 3 строки на осн. String
            String str1 = "он пирог";
            String str2 = " съел";
            String str3;
            String str4 = "Всем привет и пока";

            Console.WriteLine(str1 + str2);                         ///сцепление
            str3 = str4;                                            ///копирование
            Console.WriteLine(str3);
            Console.WriteLine(str4.Substring(5, 6));                ///выделение подстроки
            string[] words = str4.Split(new char[] { ' ' });        ///разделение строки на слова
            foreach (string s in words) Console.WriteLine(s);
            str1 = str1.Substring(0, 2) + str2 + str1.Remove(0, 2); ///вставка подстроки в заданную позицию
            Console.WriteLine(str1);
            str4 = str4.Remove(4, 9);                               ///удаление заданной подстроки
            Console.WriteLine(str4+"\n");



            //2с. Создайте пустую и null-строку
            string str5 = "";
            string str6 = null;

            if (String.IsNullOrEmpty(str5))
                Console.WriteLine("Str5 пустая или null");
            else
                Console.WriteLine("не null");


            if (String.IsNullOrEmpty(str6))
                Console.WriteLine("Str6 пустая или null\n");
            else
                Console.WriteLine("не null\n");




            //2d. Создайте строку на основе StringBuilder
            StringBuilder sb = new StringBuilder(" идет она");
            sb.Remove(6, 3);            ///удалите опр. позиции
            sb.Insert(0, "Костя");      ///добавить символы в начало
            sb.Append("в школу");       ///и конец строки
            Console.WriteLine(sb+ "\n___________________________________________________\n\n");




            //3a. Создайте целый двумерный массив
            int[,] arr = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            ///вывод в виде матрицы
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                    Console.Write(arr[i, j] + "  ");
                Console.WriteLine();
            }


            //3b. Создайте одномерный массив строк
            string[] strArr = { "ван", "ту", "фри", "фор" };
            for (int i = 0; i < 4; ++i)
                Console.Write(strArr[i] + " ");             ///вывод массива
            Console.WriteLine("\nДлина: " + strArr.Length); ///длина массива
            
            string temp = strArr[0];            ///поменяйте произвольный эл-т
            strArr[0] = strArr[2];
            strArr[2] = temp;

            for (int i = 0; i < 4; ++i)
                Console.Write(strArr[i] + " ");


           
            ///3с. Ступенчатый массив вещ. чисел
            int[][] arrSt = new int[3][];
            arrSt[0] = new int[2];
            arrSt[1] = new int[3];
            arrSt[2] = new int[4];

            Console.WriteLine("\n");
            for (int i = 0; i < 2; ++i)
            {
                arrSt[0][i] = i + 3;
                Console.Write(arrSt[0][i] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < 3; ++i)
            {
                arrSt[1][i] = i + 8;
                Console.Write(arrSt[1][i] + "  ");
            }
            Console.WriteLine();
            for (int i = 0; i < 4; ++i)
            {
                arrSt[2][i] = i + 2;
                Console.Write(arrSt[2][i] + "  ");
            }


            ///3d. Неявно типиз. пер-ные для хранения массива и строки
            var mas = new int[] { 1, 2, 3, 4 };
            var strrr = "\nЮля юля юля";
            Console.WriteLine(strrr + "\n___________________________________________________\n\n");



            ///4а. Задайте кортеж из 5 элементов
            (int, string, char, string, ulong) tpl = (20, "Женя", 'м', "Попов", 546);
            Console.WriteLine("возраст:   " + tpl.Item1);
            Console.WriteLine("имя:       " + tpl.Item2);
            Console.WriteLine("пол:       " + tpl.Item3);
            Console.WriteLine("фамилия:   " + tpl.Item4);
            Console.WriteLine("число:     " + tpl.Item5);
            ///вывести частично
            Console.Write(tpl.Item1 + " " + tpl.Item3 + " " + tpl.Item4);
            ///распаковка
            (var rr, var qq) = ("123", 456);
            Console.WriteLine($"{rr}{qq}"+ "\n___________________________________________________\n\n");

            /*
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            if (left == right)
                Console.WriteLine("Кортежи равны.")
            else Console.WriteLine("Кортежи неравны.");
            */



            ///5a.
            void func(int[] a, string s)
            {
                int max;
                int min;
                int sum;
                char tempi;
                max = a.Max<int>();
                min = a.Min<int>();
                sum = a.Sum();
                tempi = s[0];
                var T = Tuple.Create(max, min, sum, tempi);
                Console.WriteLine(T);
            }
            string sr = "Hello!";
            int[] ar = new int[5] { 1, 2, 3, 4, 5 };
            func(ar, sr);


            Console.ReadLine();

        }
    }
}