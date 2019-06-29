using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NotCorrectTypeException : Exception
    {
        public NotCorrectTypeException(string Message) : base()
        {

        }
    }

    public class Point
    {
        public delegate void dclear();
        public delegate int dsum();

        public int x;
        public int y;

        public void Clear()
        {
            this.x = 0;
            this.y = 0;
        }

        public int GetSum()
        {
            return this.x + this.y;
        }

        public void useDelegates()
        {
            dclear clear = Clear;
            dsum sum = GetSum;

            Console.WriteLine(sum());
            clear();
            Console.WriteLine(sum());
        }
    }

    public class SuperCollection<T>
    {
        List<string> data;

        public bool Add<T>(T element)
        {
            Type strtype = typeof(string);
            string sElement = element as string;
            if (sElement != null)
            {
                data.Add(sElement);
                return true;
            }
            else
            {
                throw new NotCorrectTypeException("Введите данные с другим типом");
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SuperCollection<int> s = new SuperCollection<int>();

            try
            {
                s.Add(11);
                s.Add("11");
                s.Add(123.123);
            }
            catch (NotCorrectTypeException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            int[] arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arr[i] = i;
            }
            arr[5] = 0;
            arr[6] = 0;
            arr[13] = 0;

            arr[2] = -13;
            arr[16] = -1;
            arr[10] = -2;

            var Get0 = from t in arr where t == 0 select t;
            var GetNegative = from t in arr where t < 0 select t;

            foreach (var x in Get0)
            {
                Console.WriteLine(x);
            }
            foreach (var x in GetNegative)
            {
                Console.WriteLine(x);
            }

            Point p = new Point();
            p.x = 1;
            p.y = 2;

            p.useDelegates();

            Console.ReadLine();
        }
    }
}
