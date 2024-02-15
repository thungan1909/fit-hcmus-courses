using SuperCarLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

class HelloWorld
{
 
    //Mẫu Object Pool, Prototype
    class CarFactory
    {
        List<Car> _prototypes;
        public CarFactory()
        {
            //Nap dong cac nha xe ma cua hang co ban
            //Nam trong 1 dll rieng
            //_prototypes = new List<Car>()
            //{
            //    new ElectricCar(),
            //    new HybridCar(),
            //    new Carbriolet(),
            //    /new GasolineCar()
            //};
            _prototypes = new List<Car>();

            //Nap danh sach cac tap tin dll
            string exePath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(exePath);
            var fis = new DirectoryInfo(folder).GetFiles("*.dll");
            foreach (var f in fis)  //Lan luot duyet qua cac file dll
            {
                //var domain = AppDomain.CurrentDomain;
                var assembly = Assembly.LoadFile(f.FullName);
                var types = assembly.GetTypes();
                foreach
                    (var t in types)
                        {
                            if (t.IsClass && typeof(Car).IsAssignableFrom(t))
                                {
                                   Car c = (Car)Activator.CreateInstance(t);
                                    _prototypes.Add(c);
                                }
                        }
            }
            //Kiem tra coi co lop nao ke thua tu lop Car khong
            //Tao the hien
            //Dua vao hang mau


        }
        //List<Car> _prototypes;
        //public CarFactory() {
        //    //Configuaration
        //    _prototypes.Add(new ElectricCar());
        //    _prototypes.Add(new HybridCar());
        //    _prototypes.Add(new Carbriolet());
        //    _prototypes.Add(new GasolineCar());
   
        //}
        public Car Create(int choice)
        {
            //Car result = null;
            //switch (choice)
            //{
            //    //Configuaration - Cau hinh
            //    case (int) CarEnum.ElectricCar:
            //        result = new ElectricCar();
            //        break;
            //    case (int) CarEnum.GasolineCar:
            //        result = new GasolineCar();
            //        break;
            //    case (int) CarEnum.Carbriolet:
            //        result = new Carbriolet();
            //        break;
            //    case (int) CarEnum.HybridCar:
            //        result = new HybridCar();
            //        break;
            //}

            //TODO: Kiem tra boundary
            Car result = _prototypes[choice-1].Clone();
    
            return result;
        }

        public void DisplayMenu()
        {
            //Console.WriteLine("1. Electric");
            //Console.WriteLine("2. Gasoline");
            //Console.WriteLine("3. Carbriolet");
            //Console.WriteLine("4. Hybrid");

            for( int i=0; i< _prototypes.Count; i++)
                 {
                        Car car = _prototypes[i];
                        Console.WriteLine($"{i+1}.{car.Name}");
                  }
        }
    }
    enum CarEnum : int{
        ElectricCar = 1 ,
        GasolineCar = 2 ,
        Carbriolet = 3,
        HybridCar =4
}
    static void Main()
    {
        //Hien thi menu
        CarFactory factory = new CarFactory();
        Console.WriteLine("Which car do you want?");
        factory.DisplayMenu();
        //int choice = (int) CarEnum.GasolineCar;
        int choice = int.Parse(Console.ReadLine());
      
        Car c1 = factory.Create(choice);
        c1.Depart();

        Console.ReadLine();
    }

}