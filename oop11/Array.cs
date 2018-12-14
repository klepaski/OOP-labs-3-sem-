using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP11
{
    partial class Arr
    {
        private static int count = 0;
        private int[] arr;
        private int size;
        private string nameArr = "WHOUTNAME";
        private static string[] namesArr;
        public int[] GetArrRef => arr;

        
        public Arr(int[] arg)
        {
            count++;
            arr = arg;
            size = arg.Length;
            if (count != 0)
            {
                string[] tempArr = new string[count - 1];
                for (int i = 0; i < count - 1; ++i)
                    tempArr[i] = namesArr[i];
                namesArr = new string[count];
                namesArr[count - 1] = nameArr;
                for (int i = 0; i < count - 1; ++i)
                    namesArr[i] = tempArr[i];
            }
            else
            {
                namesArr = new string[count];
                namesArr[count - 1] = nameArr;
            }
        }
        
       
        public int SumElem()
        {
            int sum = default(int);
            for (int i = 0; i < size; i++)
                sum = sum + arr[i];
            return sum;
        }
        

        public void Get()
        {
            foreach (int i in arr)
                Console.Write(i + ",  ");
            Console.WriteLine();
        }
    }
}