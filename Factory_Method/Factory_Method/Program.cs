using System;
using System.Collections.Generic;

namespace AutoDealership
{
    // Абстрактен клас 'Product'
    //Дефинира интерфейса на обектите,
    //създавани от моетода фабрика
    abstract class Vehicle
    {
    }
    //Клас за конкретна марка 'BMW' - (ConcreteProduct)
    //Имплементира интерфейса Product
    class BMW : Vehicle
    {
    }
    //Клас за конкретна марка 'Mercedes'  - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Mercedes : Vehicle
    {
    }
    //Клас за конкретна марка 'Audi'  - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Audi : Vehicle
    {
    }
    //Клас за конкретна марка 'Toyota'  - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Toyota : Vehicle
    {
    }
    // Клас за конкретна марка 'Volkswagen' - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Volkswagen : Vehicle
    {
    }
    //Клас за конкретна марка 'Mazda' - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Mazda : Vehicle
    {
    }
    //Клас за конкретна марка 'Suzuki' - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Suzuki : Vehicle
    {
    }
    //Клас за конкретна марка 'Ford' - (ConcreteProduct)
    //Имплементира интерфейса Product
    class Ford : Vehicle
    {
    }
    //Абстрактен клас - 'Creator'
    abstract class Dealer
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        //Конструктурът извиква абстрактиния метод фабрика
        public Dealer()
        {

            this.CreateVehicles();

        }

        public List<Vehicle> Vehicles
        {

            get { return vehicles; }

        }
        //Метод Фабрика
        public abstract void CreateVehicles();

    }
    //Клас за стари модели - 'ConcreteCreator'
    //предефинира метода фабрика, така, че да върне
    //инстанция на съответния ConcreteProduct.
    class Old : Dealer
    {
        // Имплементация на Модел Фабрика
        public override void CreateVehicles()
        {

            Vehicles.Add(new BMW());

            Vehicles.Add(new Mazda());

            Vehicles.Add(new Audi());

            Vehicles.Add(new Toyota());

        }

    }

    ///Клас за нови модели - 'ConcreteCreator'
    class New : Dealer
    {
        // Имплементация на Метод Фабрика
        public override void CreateVehicles()
        {

            Vehicles.Add(new Mercedes());

            Vehicles.Add(new Volkswagen());

            Vehicles.Add(new Suzuki());

            Vehicles.Add(new Ford());

        }

    }
    ///Factory Method Design Pattern
    class MainApp

    {
        /// Входни точки в конзолата
        static void Main()

        {
            // Забележка: Конструктори извикват Метод Фабрика
            Dealer[] dealers = new Dealer[2];


            dealers[0] = new Old();
            dealers[1] = new New();

            // Показва марките коли
            foreach (Dealer dealer in dealers)
            {
                Console.WriteLine("\n" + dealer.GetType().Name);

                foreach (Vehicle vehicle in dealer.Vehicles)
                {

                    Console.WriteLine("♦ " + vehicle.GetType().Name);

                }

            }
            // Изчаква потребителя
            Console.ReadKey();
        }

    }

}