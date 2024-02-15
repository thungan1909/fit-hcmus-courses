using SuperCarLib;
using System;

namespace FlyingCar
{
    class FlyingCar : Car
    {

        public string Name { get => "FlyingCar"; }
        public void Depart()
        {
            Console.WriteLine("Check gasoline level");
            Console.WriteLine("Check wind direction");
            Console.WriteLine("Flying is starting");

        }
        public Car Clone()
        {
            return new FlyingCar();
        }
    }
}
