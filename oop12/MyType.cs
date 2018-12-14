using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class MyType : ICloneable
    {
        int field1;
        public bool field2;
        public string name;

        public int Property { get => field1; set => field1 = value; }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }

        private string GetName(string name)
        {
            return name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
