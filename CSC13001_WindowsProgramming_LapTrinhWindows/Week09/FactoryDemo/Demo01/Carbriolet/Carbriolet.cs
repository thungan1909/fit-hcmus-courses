using SuperCarLib;
using System;

namespace Carbriolet
{
    class Carbriolet : Car
    {

        public string Name { get => "Carbriolet"; }
        public void Depart()
        {

            Console.WriteLine("Remove the hood");
            Console.WriteLine("Check gasoline level");
            Console.WriteLine("Carbriolet is starting");

        }
        public Car Clone()
        {
            return new Carbriolet();
        }
    }
}
