using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop3
{
    class IntVector
    {
        //ПОЛЯ
        static readonly string IntVectorInfo;           ///опр. в конструкторе
        private const int max_size = 50;                ///поле-константа
        private int[] IntArray;
        private int size;

        /*__________________________________________________________________________________*/
        
        //СВОЙСТВА
        public string INFO                  ///get
        {
            get { return IntVectorInfo; }
        }
        public int SIZE                     ///get set
        {
            get { return size; }
            set
            {
                if (size > max_size)
                    Console.WriteLine("Неверный размер");
                else size = value;
            }
        }

        /*__________________________________________________________________________________*/

        //КОНСТРУКТОРЫ
        static IntVector()                              ///статич. (закрыт, без парам, нельзя вызвать явно)
        {
            IntVectorInfo = "Массив целых значений";
        }

        public IntVector(int size = 0)                  ///с парам по умолч. (созд. массив)
        {
            this.size = size;
            if (size > 0)
                IntArray = new int[size];
            else
                IntArray = new int[] { };
        }
        
        private IntVector()                             ///без парам. (бесполезен, пока есть верхний)
        {
            IntArray = new int[] { };
        }

        /*__________________________________________________________________________________*/

        //МЕТОДЫ
        public void SumScalar(ref int scalar)           ///поэлементное сложение со скаляром (ref по ссылке)
        {
            foreach (int item in IntArray)
            {
                int itemm = item + scalar;
                Console.Write("{0} ", itemm);
            }
            Console.WriteLine();
        }
        
        public static void Information()                ///static вывод информации о классе
        {
            Console.WriteLine(IntVectorInfo);
        }


        public void Zapol()                             ///заполнение массива
        {
            Random rand = new Random();
            for (int i = 0; i < IntArray.Length; i++)
            {
                IntArray[i] = rand.Next(1,99);
            }
        }

        public void ShowIntArray()                      ///вывод массива на экран
        {
            foreach (int item in IntArray)
                Console.Write("{0} ", item);

            Console.WriteLine();
        }

        public int SumElem()                            ///сумма элементов массива
        {
            int sum = 0;
            foreach (int item in IntArray)
                sum += item;
            return sum;
        }

        public bool Chet()                              ///все элементы четные?
        {
            foreach(int item in IntArray)
            {
                if (item % 2 == 0)
                    continue;
                else return false;
            }
            return true;
        }

        /*__________________________________________________________________________________*/

        //ИНДЕКСАТОР
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < IntArray.Length)      ///по индексу обращ к элементу
                {
                    return $"Индексу [{index}] соответствует элемент {IntArray[index]}.";
                }
                else
                {
                    return $"Индекс [{index}] является недопустимым.";
                }
            }
        }

        /*__________________________________________________________________________________*/

        //Переопределение операций 
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            IntVector m = obj as IntVector; ///возвр. null, если объект нельзя привести к типу IntVector
            if (m as IntVector == null)
                return false;
            return m.size == this.size;
        }


        public override int GetHashCode()
        {
            int unitCode;
            if (size == 5)
                unitCode = 1;
            else unitCode = 2;
            return unitCode;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Задайте размер массива: ");
            int size = int.Parse(Console.ReadLine());

            IntVector array = new IntVector(size);   // Инициализация одномерного массива
            array.Zapol();                           // Заполнение массива
            Console.WriteLine("\nИсходный массив:");
            array.ShowIntArray();                    // Вывод на экран исходных элементов массива



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nУвеличение элементов массива на скаляр:");
            Console.ResetColor();
            Console.Write("Введите скаляр: ");
            int scalar = int.Parse(Console.ReadLine());
            Console.WriteLine($"Полученный массив: ");
            array.SumScalar(ref scalar);             // Элементы массива увеличенные на скаляр


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nОбращение к элементам массива по индексу:");
            Console.ResetColor();
            Console.WriteLine(array[-1]);            // Обращение к элементам массива по индексу
            Console.WriteLine(array[0]);
            Console.WriteLine(array[2]);
            Console.WriteLine(array[7]);


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nИнформация о данном классе:");
            Console.ResetColor();
            IntVector.Information();


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nПереопределение методов класса Object:");
            Console.ResetColor();
            IntVector m1 = new IntVector(5);
            IntVector m2 = new IntVector(5);
            IntVector m3 = new IntVector(4);
            m1.Zapol();
            m2.Zapol();
            m3.Zapol();
            Console.Write("m1: "); m1.ShowIntArray();
            Console.Write("m2: "); m2.ShowIntArray();
            Console.Write("m3: "); m3.ShowIntArray();

            
            Console.WriteLine("\nm1 эквивалентно m2? - " + m1.Equals(m2));   //true
            Console.WriteLine("m1 эквивалентно m3? - "+ m1.Equals(m3));   //false
            Console.WriteLine("Хэш-код m1 - "+ m1.GetHashCode());    //1
            Console.WriteLine("Хэш-код m3 - "+ m3.GetHashCode());    //2
            Console.WriteLine("Тип данных m1 - "+ m1.GetType());



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nМассив с наибольшей суммой элементов:");
            Console.ResetColor();
            IntVector x1 = new IntVector(6);
            IntVector x2 = new IntVector(8);
            IntVector x3 = new IntVector(7);
            x1.Zapol();
            x2.Zapol();
            x3.Zapol();
            Console.Write("x1: "); x1.ShowIntArray();
            Console.Write("x2: "); x2.ShowIntArray();
            Console.Write("x3: "); x3.ShowIntArray();

            IntVector[] vectors = new IntVector[3];         ///массив объектов
            vectors[0] = x1;
            vectors[1] = x2;
            vectors[2] = x3;

            int max_sum = 0;
            IntVector max = new IntVector();
            for (int i = 0; i < vectors.Length; i++)        ///max сумма элементов
            {
                if (max_sum < vectors[i].SumElem())
                {
                    max_sum = vectors[i].SumElem();
                    max = vectors[i];
                }
            }
            Console.WriteLine("Массив с наибольшей суммой элементов: ");
            max.ShowIntArray();
            Console.WriteLine($"Его сумма = {max_sum}");




            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nМассив только с четными элементами:");
            Console.ResetColor();
            int flag = 0;
            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Chet())
                {
                    Console.WriteLine("Массив с четными элементами: ");
                    vectors[i].ShowIntArray();
                    flag++;
                }
            }
            if (flag == 0)
                Console.WriteLine("Нет массивов с четными элементами");


            


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nАнонимный тип:");
            Console.ResetColor();
            var anon = new { SIZE = 5 };
            Console.WriteLine("Свойства anon:      " + anon.SIZE);
            Console.WriteLine("Тип данных anon:    " + anon.GetType());
            Console.WriteLine("Вывод anon:         " + anon);

            Console.ReadKey();
        }
    }
}