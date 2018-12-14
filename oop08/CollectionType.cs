using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using oop5;

namespace oop8
{
    public class Node<T>
    {
        public T Date { get; set; }
        public Node<T> NextNode { get; set; }
    }

    

    partial class CollectionType<T> : IGeneric<T> where T : class                      //ОБОБЩЕННЫЙ КЛАСС
    {
        public override string ToString() => "CollectionType";
        private Node<T> tail = null;
        private Node<T> head = null;
        public Node<T> GetHead => head;

        public int Lenght { get; private set; }

        public CollectionType()             ///к-р по умолч
        {
            head = null;
            tail = null;
            Lenght = 0;
        }

        public void Add(T dt)               ///Добавить элемент в список
        {
            if (head == null)
            {
                head = new Node<T>();
                head.Date = dt;
                tail = head;
                head.NextNode = null;
            }
            else
            {
                Node<T> tempNode = new Node<T>();
                tempNode.Date = dt;
                tail.NextNode = tempNode;
                tail = tempNode;
                tempNode.NextNode = null;
            }
            Lenght++;
        }

        public void Show()                  ///Показать список
        {
            Node<T> i = head;
            while (i != null)
            {
                Console.WriteLine(i.Date);
                i = i.NextNode;
            }
        }

        public void Delete(T dt)            ///Удалить элемент из списка
        {
            Node<T> i = head;
            Node<T> iNext = head.NextNode;
            if (dt.Equals(i.Date))
            {
                head = i.NextNode;
                Console.WriteLine($" {dt} удален");
                Lenght--;
                return;
            }
            while (iNext != null)
            {
                if (iNext.Date.Equals(dt))
                {
                    i.NextNode = iNext.NextNode;
                    Console.WriteLine($" {dt} удален");
                    Lenght--;
                    return;
                }
                i = i.NextNode;
                iNext = iNext.NextNode;
            }
            throw new Exception($"{dt} не был найден");
        }
    }


    class CollectionException : Exception
    {
        public CollectionException(string msg) : base(msg) => Console.WriteLine(msg);
    }
}