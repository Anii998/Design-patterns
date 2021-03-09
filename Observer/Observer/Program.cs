using System;
using System.Collections.Generic;

namespace GangOfFour.Observer.RealWorld
{

    //Абстрактен клас "Subject - Предмет"
    abstract class Fuels
    {
        private string symbol;
        private double price;
        private List<Carrier> carriers = new List<Carrier>();

        //Конструктор
        public Fuels(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(Carrier restaurant)
        {
            carriers.Add(restaurant);
        }
        public void Detach(Carrier restaurant)
        {
            carriers.Remove(restaurant);
        }
        public void Notify()
        {
            foreach (Carrier restaurant in carriers)
            {
                restaurant.Update(this);
            }

            Console.WriteLine("");

        }

        //Получава или задава цена
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;

                    Notify();
                }
            }
        }

        //Получава символ "лв."
        public string Symbol
        {

            get { return symbol; }

        }
    }

    //Клас "ConcreteSubject - Конкретен предмет"
    class Gasoline : Fuels
    {
        // Конструктор
        public Gasoline(string symbol, double price)

          : base(symbol, price)

        {

        }
    }
    class Diesel : Fuels
    {
        // Конструктор
        public Diesel(string symbol, double price)

          : base(symbol, price)

        {

        }
    }
    class Methane : Fuels
    {
        // Конструктор
        public Methane(string symbol, double price)

          : base(symbol, price)

        {

        }
    }
    // Интерфейс "Observer - Наблюдател"
    interface Carrier
    {
        void Update(Fuels fuels);
    }
    //Клас "ConcreteObserver - Конкретен Наблюдател"
    class Investor : Carrier
    {
        private string _name;
        private Fuels fuels;

        // Конструктор
        public Investor(string name)
        {
            this._name = name;
        }
        public void Update(Fuels fuels)
        {

            Console.WriteLine("Известие за: {0}. Цената на {1} " +

              "е променена на {2:C}", _name, fuels.Symbol, fuels.Price);

            Console.WriteLine("Поръчка от {0} за {1} ", _name, fuels.Symbol);

        }
        // Получава или задава гориво
        public Fuels Fuels
        {
            get { return fuels; }
            set { fuels = value; }
        }
    }

    /// Шаблон Observer
    class MainApp
    {
        //Входни точки в конзолната апликация
        static void Main()
        {
            // Задава горива (бензин, дизел, метан) и ги прекрепя към превозвачите

            Gasoline gasoline = new Gasoline("бензина", 1.20);
            Diesel disele = new Diesel("дизела", 1.80);
            Methane methane = new Methane("метана", 0.90);

            gasoline.Attach(new Investor("Превозвач 1"));

            disele.Attach(new Investor("Превозвач 1"));

            methane.Attach(new Investor("Превозвач 1"));

            gasoline.Attach(new Investor("Превозвач 2"));

            disele.Attach(new Investor("Превозвач 2"));

            methane.Attach(new Investor("Превозвач 2"));

            gasoline.Attach(new Investor("Превозвач 3"));

            disele.Attach(new Investor("Превозвач 3"));

            methane.Attach(new Investor("Превозвач 3"));


            // Промяната на цената
            gasoline.Price = 1.30;
            gasoline.Price = 1.35;

            disele.Price = 1.85;
            disele.Price = 1.90;

            methane.Price = 0.85;
            methane.Price = 0.95;

            Console.ReadKey();

        }
    }
}