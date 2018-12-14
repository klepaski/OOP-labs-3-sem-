using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace oop15
{
    class Program
    {        
        static void Main(string[] args)
        {
            ///1. Опр и выведите на консоль все запущенные процессы:
            ///id, имя, приоритет...

            var allProcesses = Process.GetProcesses();
            Console.Write("{0,-10}", "ID:");
            Console.Write("{0,-40}", "Process Name:");
            Console.Write("{0,-10}", "Priority:\n");
            foreach (var process in allProcesses)
            {
                Console.Write("{0,-10}", $"{process.Id}");
                Console.Write("{0,-40}", $"{process.ProcessName}");
                Console.Write("{0,-10}", $"{process.BasePriority}");
                Console.WriteLine();
            }



            
            ///2. Исслед. тек. домен приложения:
            /// имя, детали конфигурации, все сборки загруженные в домен
            
            var thisAppDomain = Thread.GetDomain();

            Console.WriteLine($"\n\n\nName:  {thisAppDomain.FriendlyName}");
            Console.WriteLine($"Setup Information:  {thisAppDomain.SetupInformation.ToString()}");
            Console.WriteLine("Assemblies:");

            foreach (var item in thisAppDomain.GetAssemblies())
            {
                Console.WriteLine("    " + item.FullName.ToString());
            }




            ///3. Созд. в отд потоке след задачу расчета и записи чисел от 1 до n
            ///вызов методы упр потоком (запуск, приостановка, возобновление...)
            ///вывод инфу о потоке: имя, приоритет, id...

            Thread NumbersThread = new Thread(new ParameterizedThreadStart(WriteNums));
            NumbersThread.Start(7);

            Thread.Sleep(2000);
            NumbersThread.Suspend();

            Console.WriteLine("\n--------------------");
            Console.WriteLine("Приоритет:   " + NumbersThread.Priority);
            Thread.Sleep(100);
            Console.WriteLine("Имя потока:  " + NumbersThread.Name);
            Thread.Sleep(100);
            Console.WriteLine("ID потока:   " + NumbersThread.ManagedThreadId);
            Console.WriteLine("---------------------");
            Thread.Sleep(1000);

            NumbersThread.Resume();
            Thread.Sleep(2000);


            void WriteNums(object number)     //Method for another thread
            {
                int num = (int)number;
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            }

            


            ///4. созд 2 потока:
            /// исп. средства синхронизации орган. работу потоков: 
            /// вывод сначала чет, потом нечет 
            /// послед. вывод 1 чет 1 нечет
            
            Console.WriteLine("СНАЧАЛА НЕЧЕТНЫЕ, ПОТОМ ЧЕТНЫЕ:");
            OddEven.DoItConsistently();
            Thread.Sleep(4000);

            Console.WriteLine("\nОДНО НЕЧЕТНОЕ, ОДНО ЧЕТНОЕ:");
            OddEven.DoItOneByOne();
            Thread.Sleep(4000);




            ///5. реализ. задачу на основе класса Timer

            TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);
            Timer timer = new Timer(timerCallback, null, 0, 1000);
            Thread.Sleep(5000);

            void WhatTimeIsIt(object obj)
            {
                Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            }

            Console.ReadLine();
            Console.ReadLine();
        }
    }
}