using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP11
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Созд. массив string 12 месяцев
            Запросы:
            - длина = n
            - летние/зимние
            - по алфавиту
            - подсчет мес. с буквой "u", длина>=4
            */
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var selectedMonthN = from m in month
                                 where m.Length == 7
                                 select m;
                                Console.WriteLine("Месяцы длинной 7:");
                                foreach (string str in selectedMonthN)
                                    Console.Write(str + ",  ");


            var selectedMonthWinSum = from m in month
                                      where Array.IndexOf(month, m) < 2 ||
                                      Array.IndexOf(month, m) > 4 && Array.IndexOf(month, m) < 8 ||
                                      Array.IndexOf(month, m) == 11
                                      select m;
                                    Console.WriteLine("\n\nЗимние и летние месяцы:");
                                    foreach (string str in selectedMonthWinSum)
                                        Console.Write(str + ",  ");


            var selectedMonthAlfa = from m in month
                                    orderby m
                                    select m;
                                    Console.WriteLine("\n\nМесяцы по алфавиту:");
                                    foreach (string str in selectedMonthAlfa)
                                        Console.Write(str + ",  ");


            var selectedMonthU4 = from m in month
                                  where m.Contains('u') && m.Length > 3
                                  select m;
                                Console.WriteLine("\n\nМесяцы с буквой 'u', длина >= 4:");
                                foreach (string str in selectedMonthU4)
                                    Console.Write(str + ",  ");






            Console.WriteLine("\n"+ new String('-', 50));
            List<Arr> arrInts = new List<Arr>();
            
            int[] arr1 = { 10, 20, 30, 40, 50, 60, 17, 18, 12 };
            int[] arr2 = { 20, 12, 14, 16, 18, 20 };
            int[] arr3 = { 11, 13, 15, 17, 19 };
            int[] arr4 = { 20, 16, 70, 16, 18, 20 };

            int[][] bigArr = { arr1, arr2, arr3, arr4 };
            Arr[] arrInt3 = { new Arr(arr1), new Arr(arr2), new Arr(arr3), new Arr(arr4) };

            // max sum

            var SumMax = arrInt3.Max(arr => arr.SumElem());
            var ArrayMax = arrInt3
                .Where(arr => arr.SumElem() == SumMax)
                .Select(arr => arr);

            Console.WriteLine("\n\n\nМассив с max суммой эл-тов: ");
            foreach (Arr arr in ArrayMax)
            {
                arr.Get();
            }


            //// нечет элем

            var UnEvenArr = from i in bigArr
                            where i.All(num => num % 2 == 1)
                            select i;

            Console.WriteLine("\n\n\nМассив с нечет эл-тами: ");
            foreach (var i in UnEvenArr)
            {
                foreach (var i2 in i)
                    Console.Write(i2 + ",  ");
                Console.WriteLine();
            }

            

            //// упоряд по первому эл-ту
            
            var OrderedArr = arrInt3.OrderBy
                (arr => arr.GetArrRef[0])
                .Select(arr => arr);

            Console.WriteLine("\n\n\nМассив, упоряд. по певому эл-ту: ");
            foreach (Arr arr in OrderedArr)
                arr.Get();



            //// кол массивов с зад знач
            
            int value = 12;
            var AmountArr = (from arr in arrInt3
                             let array = arr.GetArrRef
                             from i in array
                             where i == value
                             select arr
                            ).ToArray();
            foreach (Arr arr in AmountArr)
                arr.Get();
            
            Console.WriteLine("\n\nКол-во массивов с числом 12: {0}", AmountArr.Length);
            Console.ReadLine();
        }
    }
}