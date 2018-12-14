using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace oop5
{
    struct Rocket
    {
        public int size;
        public string color;
        public int state;

        public int State                        ///св-во
        {
            get => state;
            set => state = (value <= 100) ? value : 100;
        }

        public Rocket(int Size, string Color)   ///к-р
        {
            color = Color;
            size = Size;
            state = 100;
        }
    }



    partial class Tennis
    {
        private Rocket objRocket;
        private Rocket xRocket = new Rocket(1, "black");
        private Rocket xLRocket = new Rocket(2, "green");
        private Rocket xLLRocket = new Rocket(3, "red");

        public enum enumRocket      ///6-добавить перечисление
        {
            x=1, xL, xLL
        }

        public void ChooseRocket(enumRocket num)    ///метод выбора ракетки (по номеру)
        {
            switch (num)
            {
                case enumRocket.x:                  ///1
                    objRocket = xRocket;
                    Console.WriteLine("Вы выбрали черную ракетку, размер 1.");
                    break;
                case enumRocket.xL:                 ///2
                    objRocket = xLRocket;
                    Console.WriteLine("Вы выбрали зеленую ракетку, размер 2.");
                    break;
                case enumRocket.xLL:                ///3
                    objRocket = xLLRocket;
                    Console.WriteLine("Вы выбрали красную ракетку, размер 3.");
                    break;
                default:
                    Console.WriteLine("Такой ракетки нет. Пусть будет 1-xRocket");
                    objRocket = xRocket;
                    break;
            }
        }
    }


    /*_______________________________________________________*/

    //КЛАСС-КОНТЕЙНЕР
    ///хран. разные типы объектов в виде списка
    class Gym
    {
        private readonly List<Playground> ListPlayGround;

        public List<Playground> GetList     ///св-во
        {
            get => ListPlayGround;
        }

        public Gym()                        ///к-р
        {
            ListPlayGround = new List<Playground>();
        }

        public Gym(Playground obj)          ///к-р
        {
            ListPlayGround.Add(obj);
        }

        public void Add(Playground obj)     ///метод
        {
            ListPlayGround.Add(obj);
        }

        public bool Remove(int index)
        {
            if (ListPlayGround.Count < index)
                return false;
            Console.WriteLine($"элемент [{index}] удален.");
            ListPlayGround.RemoveAt(index);
            return true;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-------Элементы списка--------");

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var i in ListPlayGround)
            {
                Console.WriteLine(i);
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }



    /*_______________________________________________________*/

    //КЛАСС-КОНТРОЛЛЕР
    ///реализует запросы, управляет объектом-Контейнером
    class СontrollerGym : IEnumerable
    {
        private List<Shells> ListShell;
        private int budget;

        public СontrollerGym(int bg)        ///к-р
        {
            Console.WriteLine($"Ваш бюджет = {bg}");
            budget = bg;
            ListShell = new List<Shells>();
        }
        
        public void Sort()                  ///метод
        {
            ListShell.Sort();
        }

        public void СhoiceRange(int a, int b)           ///метод(снаряды в пределах $)
        {
            var tempList = from shell in ListShell
                           where a < shell.Price &&
                                 b > shell.Price
                           select shell;
            ListShell = tempList.ToList();
        }

        public void Show()
        {
            foreach (var i in ListShell)
            {
                Console.Write("{0,-9}", " ");
                Console.Write("{0,-14}", i.Amount);
                Console.Write("|");
                Console.Write("{0,-9}", " ");
                Console.Write(i.Price + "\n");
            }
        }

        public void Add(Shells obj)
        {
            if (budget > obj.Price)
            {
                ListShell.Add(obj);
                budget -= obj.Price;
            }
            else
                Console.WriteLine($"Недостаточно бюджета \n Бюджет: {budget} - Цена: {obj.Price}\n");
        }

        public IEnumerator GetEnumerator()
        {
            return ListShell.GetEnumerator();
        }
    }



    class Shells : IComparable, ICloneable
    {
        private int price;
        private int amount;
        private const int max = 1000;

        public int CompareTo(object obj)
        {
            Shells shells = (Shells)obj;
            if (Price > shells.Price) return 1;
            if (Price < shells.Price) return -1;
            return 0;
        }

        public object Clone() => MemberwiseClone();

        public Shells(int am)
        {
            amount = am;
            price = amount * 12;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }
       
        public int Amount
        {
            get => amount;
            set => amount = value <= max ? value : max;
        }
    }
}