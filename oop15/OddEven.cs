using System;
using System.Threading;
using System.IO;

namespace oop15
{
    static class OddEven
    {
        public static void DoItConsistently()
        {
            Object locker = new Object();
            
            Thread Nech_Thread = new Thread(new ThreadStart(Print_Nech));
            Thread Ch_Thread = new Thread(new ThreadStart(Print_Ch));
            Nech_Thread.Start();
            Ch_Thread.Start();

            void Print_Nech()
            {
                lock (locker)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i + " неч");
                            Thread.Sleep(250);
                        }
                    }
                }
            }

            void Print_Ch()
            {
                lock (locker)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i + " чет");
                            Thread.Sleep(500);
                        }
                    }
                }
            }
        }




        public static void DoItOneByOne()
        {
            Mutex mutex = new Mutex();///организ. критич секцию для неск запросов

            Thread Nech_Thread = new Thread(new ThreadStart(Print_Nech));
            Thread Ch_Thread = new Thread(new ThreadStart(Print_Ch));
            Nech_Thread.Start();
            Ch_Thread.Start();

            void Print_Nech()
            {
                for (int i = 0; i < 10; i++)
                {
                    mutex.WaitOne();///вход в крит. секцию

                    if (i % 2 != 0)
                    {
                        Console.WriteLine(i + " неч");
                        Thread.Sleep(250);
                    }
                    mutex.ReleaseMutex();///выход из нее
                }
            }

            void Print_Ch()
            {
                for (int i = 0; i < 10; i++)
                {
                    mutex.WaitOne();

                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i + " чет");
                        Thread.Sleep(500);
                    }
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}