using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp61
{
    class Program
    {
        static void Main(string[] args)
        {
            CPhanSo ps1 = new CPhanSo();
            CPhanSo ps2 = new CPhanSo(1,2);
            ps1.TuSo = ps2.MauSo * 5;
            Console.WriteLine(ps1.TuSo.ToString() + "/" + ps1.MauSo.ToString());
        }
    }
}
