using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using oop5;


namespace oop8
{
    partial class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<string> obj1 = new CollectionType<string>();
                IGeneric<string> a;
                obj1.Add("bye ");
                obj1.Add("adyos ");
                obj1.Add("sayonara ");
                a = obj1;
                a.Show();
                obj1.SaveInFile();

                Console.WriteLine();
                CollectionType<Playground> plGr = new CollectionType<Playground>();
                plGr.Add(new Basketball());
                plGr.Add(new Bench());
                plGr.Add(new Tennis());

                Playground beam = new Beams(12);
                plGr.Add(beam);
                plGr.Show();

                Console.WriteLine();
                plGr.Delete(beam);
                plGr.Show();
                plGr.SaveInFile();

                CollectionType<Playground> pl2 = new CollectionType<Playground>();
                LoadFromFile(ref pl2);
                Console.WriteLine("\nЭлементы файла file2.txt:");
                pl2.Show();
            }

            catch (CollectionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nFINALLY");
            }
            Console.ReadLine();
        }
    }
}