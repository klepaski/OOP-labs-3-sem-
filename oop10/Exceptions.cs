using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop7
{
    class IndexException : Exception
    {
        public IndexException(string msg) : base(msg) { }
    }

    class BudgetException : Exception
    {
        public BudgetException(string msg) : base(msg) { }
    }

    class MaxException : Exception
    {
        public MaxException(string msg) : base(msg) { }
    }
}