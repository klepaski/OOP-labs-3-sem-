using System;
using System.Runtime.Serialization;

namespace oop14
{
    [DataContract]
    [Serializable]
    public class Cartoon : Film
    {
        public Cartoon() { }
        [DataMember]
        public int Year { get; set; }

        public Cartoon(string name, int year)
        {
            Name = name;
            Year = year;
        }
        
        public override string ToString()
        {
            return $"Мультфильм {Name}";
        }
    }
}