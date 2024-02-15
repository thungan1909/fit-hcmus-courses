using SuperCarLib;
using System;

namespace HybridCar
{
    class HybridCar : Car
    {
        public string Name { get => "HybridCar"; }
        public void Depart()
        {

            Console.WriteLine("Check battery level");
            Console.WriteLine("HybridCar is starting");

        }
        public Car Clone()
        {
            return new HybridCar();
        }
    }
}
