using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    class Program
    {
        static void Main(string[] args)
        {
            MyObject ps = new MyObject();
            MyObject sv = new MyObject("Sinh viên");
            ps["Tử số"] = 5;
            ps["Mẫu số"] = 9;
            Console.WriteLine(ps["Tử số"].ToString() + "/" +
                ps["Mẫu số"].ToString());
        }
    }
}
