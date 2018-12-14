using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop4
{
    public static class ListExtension
    {
        public static void СropList(this List obj, int size)       //Усечение строки до заданной длины
        {
            Node i = obj.GetHead;
            while (i != null)
            {
                i.Date = i.Date.Substring(0, size);
                i = i.NextNode;
            }
        }


        public static void MaxString(this List obj)             //Поиск максимального
        {
            string[] arrStr = new string[1];
            int maxStr = 0;             ///длина макс строки
            Node i = obj.GetHead;
            string max = "";

            while (i != null)
            {
                if (i.Date.Length > maxStr)
                {
                    max = i.Date;
                    maxStr = i.Date.Length;
                }
                i = i.NextNode;
            }
            Console.WriteLine(max);
        }
    }

}