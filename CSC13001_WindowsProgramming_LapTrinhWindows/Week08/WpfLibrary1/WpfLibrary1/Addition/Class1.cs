using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addition
{
    public class Addition : IContract
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}
