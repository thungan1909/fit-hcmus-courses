using SuperCarLib;
using System;

namespace ElectricCar
{
    class ElectricCar : Car
    {
        public string Name { get => "ElectricCar"; }
        public void Depart()
        {

            Console.WriteLine("Check battery level");
            Console.WriteLine("ElectricCar is starting");

        }
        public Car Clone()
        {
            return new ElectricCar();
        }
    }
}
