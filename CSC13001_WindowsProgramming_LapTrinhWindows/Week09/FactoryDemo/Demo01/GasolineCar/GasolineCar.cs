using SuperCarLib;
using System;

namespace GasolineCar
{
    class GasolineCar : Car
    {
        public string Name { get => "GasolineCar"; }
        public void Depart()
        {

            Console.WriteLine("Check battery level");
            Console.WriteLine("GasolineCar is starting");
        }
        public Car Clone()
        {
            return new GasolineCar();
        }
    }
}
