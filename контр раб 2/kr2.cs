using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КР2
{
    class Program
    {
        static void Main(string[] args)
        {   //1 задание
            SuperHashSet<Student> hashSet = new SuperHashSet<Student>();
            hashSet.Add(new Student("Vitaliy"));
            hashSet.Add(new Student("Evgeniy")); 
            hashSet.Show();


            hashSet.Task2(new Student("Vitaliy"));//2 задание 
                                                  //Всегда 1 так как повторяшки выкидываем
                                                  //нах это задание -_-

            Button b1 = new Button("Кнопка №1");
            Button b2 = new Button("Кнопка №2");
            User user = new User("Vitaliy");
            user.Click += b2.OnClick;
            user.Click += b1.OnClick;
            user.CommandClick();
            Console.ReadKey();
        }
    }

    class SuperHashSet<T> where T : class
    {
        private HashSet<T> hashSet = new HashSet<T>();

        public void Add(T obj)
        {
            hashSet.Add(obj);
        }

        public void Show()
        {
            foreach (var n in hashSet)
            {
                Console.WriteLine(" - " + n.ToString());
            }
        }

        //Задание 2
        public void Task2(T obj)
        {
            foreach (var n in hashSet.Where(n => n.Equals(obj)).Select(n => n))//Сравниваем по хэш коду имени(Класс Student)Переопределили стандартные методы GetHashCode, Equals
            {
                Console.WriteLine(n.ToString());
            }
            int count = hashSet.Where(n => n.Equals(obj)).Select(n => n).Count();
            Console.WriteLine($"Количество таких объектов в HashSet {count}");
        }

    }

    class Student
    {
        private string name;

        public string Name { get; }
        public Student(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Студент: {this.name}";
        }



        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }

    class Button
    {
        private string nameOfButton;
        public Button(string nameOfButton)
        {
            this.nameOfButton = nameOfButton;
        }

        public void OnClick(object sender, EventArgs e)
        {
            Console.WriteLine($"Кнопку {this.nameOfButton} нажали.");
        }

    }

    class User
    {
        public event EventHandler Click;
        private string name;
        public User(string name)
        {
            this.name = name;
        }

        public void CommandClick()
        {
            Console.WriteLine($" - {this.name} нажал на кнопку");
            Click?.Invoke(this, null);
        }
    }
}
