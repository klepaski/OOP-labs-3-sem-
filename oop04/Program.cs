using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Security.Cryptography;


namespace oop4
{
    public class Node
    {
        private Node next;
        private string info;

        public Node NextNode    ///Конструктор
        {
            get => next;
        }

        public Node SetNextNode(Node _nextNode) => next = _nextNode;

        public string Date
        {
            get => info;
            set => info = value;
        }
    }

    public class List
    {
        //Создатель
        public class Owner
        {
            public Owner(string Name, string Organ) ///конструктор (добав сотрудника)
            {
                Id++;
                name = Name;
                organ = Organ;
            }
            public void ShowInfo()                  ///метод вывод информации
            {
                Console.WriteLine($"Id:             {Id}");
                Console.WriteLine($"Имя:            {name}");
                Console.WriteLine($"Организация:    {organ}\n");
            }
            private static int Id = 0;
            private string name;
            private string organ;
        }


        //Дата создания
        public class Date
        {
            public Date()                   ///конструктор (уст. дату)
            {
                time = DateTime.Now;
            }
            public void ShowDate()          ///метод вывод даты
            {
                Console.WriteLine(time);
            }
            private DateTime time;
        }

        private Node tail = null;
        private Node head = null;

        public Owner _owner { get; set; }
        public Date _date { get; set; }
        public int Lenght { get; private set; }

        public List()                       ///конструктор списка
        {
            head = null;
            tail = null;
            Lenght = 0;
        }

        public Node GetHead => head;
        public void Add(string _date)
        {
            if (head == null)               ///если список пуст
            {
                head = new Node();          ///новый эл-т списка
                head.Date = _date;          ///в него дату
                tail = head;                ///хвост = голова
                head.SetNextNode(null);     ///за head следует 
            }
            else
            {
                Node tempNode = new Node();     ///новый эл-т списка
                tempNode.Date = _date;          ///в него дату
                tail.SetNextNode(tempNode);     ///его следущим за tail
                tail = tempNode;                ///и в сам tail
                tempNode.SetNextNode(null);     ///за tail null
            }
            Lenght++;
        }



        public string GetByIndex(int i)         //Элемент списка по индексу
        {
            Node node = head;
            for (int index = 0; index < i; ++index)
            {
                node = node.NextNode;
            }
            return node.Date;
        }



        public void Show()                      //Вывод списка
        {
            Node i = head;
            while (i != null)
            {
                Console.Write(i.Date + " ");
                i = i.NextNode;
            }
            Console.WriteLine();
        }



        public void Remove(string _date)                //Удалить эл-т по дате
        {
            Node i = head;
            Node iNext = head.NextNode;
            if (i.Date == _date)                        ///если в списке один эл-т
            {
                head = i.NextNode;                      ///в head - следующий за ним
                Console.WriteLine($" {_date} удален");
                Lenght--;
                return;
            }
            while (iNext != null)
            {
                if (iNext.Date == _date)
                {
                    i.SetNextNode(iNext.NextNode);
                    Console.WriteLine($" {_date} удален");
                    Lenght--;
                    return;
                }
                i = i.NextNode;
                iNext = iNext.NextNode;
            }
            Console.WriteLine($" {_date} не найден");
        }


        /*___________________________________________________________________*/

        //ПЕРЕГРУЗКА ОПЕРАЦИЙ

        public static List operator +(List obj1, List obj2)     ///Объединить списки
        {
            List newList = new List();
            for (int i = 0; i < obj1.Lenght; ++i)
            {
                newList.Add(obj1.GetByIndex(i));
            }
            for (int i = 0; i < obj2.Lenght; ++i)
            {
                newList.Add(obj2.GetByIndex(i));
            }
            return newList;
        }
        
        public static List operator !(List obj1)                ///Инверсия элементов
        {
            List listNew = new List();
            for (int i = obj1.Lenght - 1; i >= 0; i--)
            {
                listNew.Add(obj1.GetByIndex(i));
            }
            return listNew;
        }

        public static bool operator !=(List obj1, List obj2)
        {
            if (obj1.Lenght != obj2.Lenght) return true;
            Node i1 = obj1.GetHead;
            Node i2 = obj2.GetHead;
            while (i1 != null)
            {
                if (i1.Date != i2.Date) return true;
                i1 = i1.NextNode;
                i2 = i2.NextNode;
            }
            return false;
        }

        public static bool operator ==(List obj1, List obj2)    ///Равенство списков
        {
            if (obj1 != obj2) return false;
            else return true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Лист 1:");
            Console.ResetColor();
            List list = new List();
            list.Add("Юлия");
            list.Add("Чистякова");
            list.Add("программист");
            list.Show();
            list.Remove("Чистякова");
            list.Remove("5 группа");
            list.Show();

            

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nЛист 2:");
            Console.ResetColor();
            List list2 = new List();
            list2.Add("Студентка");
            list2.Show();

            

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nЛист 3 (объединение лист1 и лист2):");
            Console.ResetColor();
            List list3 = list + list2;
            list3.Show();



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nСтрока max длины в Лист 3:");
            Console.ResetColor();
            list3.MaxString();



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nЛист 4 (инверсия листа3):");
            Console.ResetColor();
            list3 = !list3;
            list3.Show();

            

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nЛист 3 усечен до 4 символов:");
            Console.ResetColor();
            list3.СropList(4);
            list3.Show();



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nЛист 4 и Лист 5 равны?");
            Console.ResetColor();
            List list4 = new List();
            List list5 = new List();
            list4.Add("12345");
            list5.Add("12345");
            list4.Show();
            list5.Show();
            if (list5 == list4) Console.WriteLine("Да, равны.");
            if (list5 != list4) Console.WriteLine("Нет, не равны.");



            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nOwners:");
            Console.ResetColor();
            list4._owner = new List.Owner("Иван", "Google");
            list5._owner = new List.Owner("Михаил", "Microsoft");
            list4._owner.ShowInfo();
            list5._owner.ShowInfo();


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nDates:");
            Console.ResetColor();
            list5._date = new List.Date();
            list5._date.ShowDate();

            Console.ReadLine();
        }
    }
}