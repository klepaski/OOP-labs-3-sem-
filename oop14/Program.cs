using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;


namespace oop14
{
    class Program
    {
        static void Main(string[] args)
        {
            //********************************** B I N A R Y *********************************************
            Console.WriteLine("Binary");
            
            BinaryFormatter binFormatter = new BinaryFormatter();                                   ///сериализ.
            using (FileStream stream = new FileStream("cartoon.dat", FileMode.OpenOrCreate))
            {
                Cartoon TomAndJerry = new Cartoon("Том и Джерри", 1940);
                binFormatter.Serialize(stream, TomAndJerry);
            }

           
            using (FileStream stream = new FileStream("cartoon.dat", FileMode.OpenOrCreate))        ///десериал.
            {
                Cartoon someCartoon = (Cartoon)binFormatter.Deserialize(stream);
                Console.WriteLine($"Десериализован: \"{someCartoon.Name}\", год: {someCartoon.Year}\n");
            }




            //************************************* S O A P ********************************************
            Console.WriteLine("SOAP");
            SoapFormatter soapFormatter = new SoapFormatter();

            using (FileStream stream = new FileStream("cartoon.soap", FileMode.OpenOrCreate))       ///сериал.
            {
                Cartoon Simpsons = new Cartoon("Симпсоны", 1989);
                soapFormatter.Serialize(stream, Simpsons);
            }
            

            using (FileStream stream = new FileStream("cartoon.soap", FileMode.OpenOrCreate))        ///десериал.
            {
                Cartoon someCartoon = (Cartoon)soapFormatter.Deserialize(stream);
                Console.WriteLine($"Десериализован: \"{someCartoon.Name}\", год: {someCartoon.Year}\n");
            }



            
            //*************************************** X M L **********************************************
            XmlSerializer serializer = new XmlSerializer(typeof(Cartoon));
            Console.WriteLine("XML");

            using (FileStream stream = new FileStream("cartoon.xml", FileMode.OpenOrCreate))            ///сериализ.
            {
                Cartoon ScoobyDoo = new Cartoon("СКУБИ ДУ", 1988);
                serializer.Serialize(stream, ScoobyDoo);
            }

           
            using (FileStream stream = new FileStream("cartoon.xml", FileMode.OpenOrCreate))            ///десериал.
            {
                Cartoon someCartoon = (Cartoon)serializer.Deserialize(stream);
                Console.WriteLine($"Десериализован: \"{someCartoon.Name}\", год: {someCartoon.Year}\n");
            }




            //************************************** J S O N *********************************************
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Cartoon));
            Console.WriteLine("JSON");

           
            using (FileStream stream = new FileStream("cartoon.json", FileMode.OpenOrCreate))               ///сериал.
            {
                Cartoon KingOfTheHill = new Cartoon("Король Лев", 1956);
                jsonSerializer.WriteObject(stream, KingOfTheHill);
            }
            

            using (FileStream stream = new FileStream("cartoon.json", FileMode.OpenOrCreate))               ///десериал.
            {
                Cartoon someCartoon = (Cartoon)jsonSerializer.ReadObject(stream);
                Console.WriteLine($"Десериализован: \"{someCartoon.Name}\", год: {someCartoon.Year}\n");
            }



            //********************************** К О Л Л Е К Ц И Я ****************************************
            XmlSerializer top3Serializer = new XmlSerializer(typeof(List<Cartoon>));
            List<Cartoon> top3 = new List<Cartoon>();
            top3.Add(new Cartoon("Сейлор Мун ", 1948));
            top3.Add(new Cartoon("Губка Боб ", 2004));
            top3.Add(new Cartoon("Арнольд ", 1989));

            using (FileStream topStream = new FileStream("top3.xml", FileMode.Create))
            {
                top3Serializer.Serialize(topStream, top3);
            }

            using (FileStream topStream = new FileStream("top3.xml", FileMode.OpenOrCreate))
            {
                List<Cartoon> someCartoons = (List<Cartoon>)top3Serializer.Deserialize(topStream);

                foreach (var item in someCartoons)
                {
                    Console.WriteLine(item.Name + ": " + item.Year);
                }
            }




            //******************************** X - P A T H ************************************
            Console.WriteLine("\nXPath");

            XmlDocument document = new XmlDocument();
            document.Load("top3.xml");

            XmlNode xmlRoot = document.SelectSingleNode("ArrayOfCartoon");
            XmlNodeList nodeCartoons = xmlRoot.SelectNodes("Cartoon");


            Console.WriteLine("Full info about top3 cartoons:");
            XmlNodeList allCartoons = xmlRoot.SelectNodes("*");

            foreach (XmlNode item in allCartoons)
            {
                Console.WriteLine(item.InnerText);
            }



            
            //************************** L I N Q    T O    X M L ********************************
            Console.WriteLine("\nLINQ to XML:");

            XDocument Children = new XDocument();               //Create document
            XElement root = new XElement("Дети");               //Create root

            XElement child;                                     //Create album element
            XElement name;                                      //Create name element
            XAttribute year;                                    //Create year attribute

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Юля";
            year = new XAttribute("year", "1998");
            child.Add(name);
            child.Add(year);
            root.Add(child);

            child = new XElement("child");
            name = new XElement("name");
            name.Value = "Наташа";
            year = new XAttribute("year", "1995");
            child.Add(name);
            child.Add(year);
            root.Add(child);
            
            Children.Add(root);
            Children.Save("Children.xml");           //Save file

            

            Console.WriteLine("Введите год для поиска: ");
            string yearXML = Console.ReadLine();
            var allAlbums = root.Elements("child");

            foreach (var item in allAlbums)
            {
                if (item.Attribute("year").Value == yearXML)
                {
                    Console.WriteLine(item.Value);
                }
            }
            Console.ReadLine();
        }
    }
}