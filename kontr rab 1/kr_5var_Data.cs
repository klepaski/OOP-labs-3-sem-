using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_5var
{
    //2.
    partial class Date
    {
        public override int GetHashCode()
        {
            return day + month + year;
        }
    }
}
