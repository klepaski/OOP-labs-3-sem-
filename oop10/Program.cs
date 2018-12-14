using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using oop5;
using System.Collections.Specialized;

namespace oop10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Созд. необобщ. коллекцию ArrayList
            а) заполн. 5 целыми числами
            б) добав. строку
            в) добав объект Student
            г) удал задан эл-т
            д) вывод кол-во эл и коллекцию на консоль
            е) поиск значения в коллекции
            */
            ArrayList arrayList = new ArrayList();

            arrayList.AddRange(new int[] { 1, 2, 3, 4, 5 });
            arrayList.Add("Строка");
            arrayList.Add(new Tennis());
            arrayList.Remove(5);

            ShowArrList(arrayList);

            Console.WriteLine($"Индекс '1' - {arrayList.IndexOf(1)}");
            Console.WriteLine($"Индекс 'Строка' - {arrayList.IndexOf("Строка")}");
            Console.WriteLine($"Индекс '4' - {arrayList.IndexOf(4)}\n\n\n");



            /*Созд. обобщ. коллекцию Stack<T>
            заполн. д-мы типа double
            а) вывести
            б) удал эл-ты
            */
            Stack<double> stack = new Stack<double>();
            double[] arrDb = new double[] { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7 };
            for (int i = arrDb.Length-1; i >-1; i--)
                stack.Push(arrDb[i]);

            ShowStack(stack);
            
            StackRemove(ref stack, 2.2);
            StackRemove(ref stack, 1);
            ShowStack(stack);
            Console.WriteLine("\n\n\n");


            /*Cозд. коллекцию LinkedList<T>
            заполн. ее д-ми из первой коллекции
            д) вывести
            е) поиск задан значения
            */
            LinkedList<double> linkedList = new LinkedList<double>();
            for (; stack.Count != 0;)
                linkedList.AddLast(stack.Pop());

            ShowLinkedList(linkedList);
            Console.WriteLine("linkedList Find '3.3'");
            Console.WriteLine(linkedList.Find(3.3).Value);
            Console.WriteLine("linkedList Find '1.1'");
            Console.WriteLine(linkedList.Find(1.1).Value + "\n\n\n");



            /*аналогично для своего тд*/
            Stack<Shells> sh_stack = new Stack<Shells>();
            for (int i = 0; i < 5; i++)
            {
                sh_stack.Push(new Shells(i));
            }
            foreach (Shells item in sh_stack)
            {
                Console.Write(item.Price + "  ");
            }
            Console.WriteLine();
            
            
            LinkedList<Shells> sh_list = new LinkedList<Shells>();
            for (; sh_stack.Count != 0;)
            {
                sh_list.AddLast(sh_stack.Pop());
            }
            foreach (Shells item in sh_list)
            {
                Console.Write(item.Price + "  ");
            }
            Console.WriteLine();



            /*Cозд. объект наблюдаемой кол ObservableCollection<T>
            созд. метод и зарег его на событие CollectionChange
            демонстр с удалением эл-тов
            Т - мой класс
            */

            ObservableCollection<Shells> obs = new ObservableCollection<Shells>();
            obs.CollectionChanged += Obs_CollectionChanged;///метод справа рег. на событие слева
            Shells sh = new Shells(30);
            obs.Add(new Shells(10));
            obs.Add(sh);
            obs.Add(new Shells(20));
            obs.Remove(sh);
            foreach (Shells i in obs)
            {
                Console.WriteLine(i.Price);
            }
            Console.ReadLine();
        }

        //--------------------COLLECTION--CHANGE-----------------------

        private static void Obs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)///принм. инфу об изменениях кол
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Элемент добавлен ");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Элемент удален ");
            }
            else
            {
                Console.WriteLine("Нет добавленных/удаленных элементов");
            }
        }

        //--------------------REMOVE-----------------------

        static void StackRemove(ref Stack<double> stack, double num)
        {
            Stack<double> tempStack = new Stack<double>();
            int k = 0;
            for (; stack.Count != 0;)
            {
                if (stack.Peek() == num)
                {
                    k++;
                    stack.Pop();
                    Console.WriteLine($"Элемент {num} удален");
                }
                else tempStack.Push(stack.Pop());
            }
            if (k == 0)
                Console.WriteLine($"Элемент {num} не найден");
            stack = tempStack;
        }

        //--------------------SHOW--------------------------
        
        static void ShowStack(Stack<double> stack)
        {
            foreach (object i in stack)
                Console.Write(i + "   ");
            Console.WriteLine();
        }

        static void ShowLinkedList(LinkedList<double> linList)
        {
            foreach (object i in linList)
                Console.Write(i + "   ");
            Console.WriteLine();
        }

        static void ShowArrList(ArrayList arrayList)
        {
            foreach (object i in arrayList)
                Console.Write(i + "   ");
            Console.WriteLine();
            Console.WriteLine("Количество элементов: " + arrayList.Count);
        }
    }
}