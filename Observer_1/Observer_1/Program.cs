using System;
using System.Collections.Generic;

namespace GangOfFour.Observer.RealWorld
{

    //Абстрактен клас "Subject - Предмет"
    abstract class Vegetables
    {
        private string symbol;
        private double price;
        private List<Restaurant> restaurants = new List<Restaurant>();

        //Конструктор
        public Vegetables(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
        }
        public void Detach(Restaurant restaurant)
        {
            restaurants.Remove(restaurant);
        }
        public void Notify()
        {
            foreach (Restaurant restaurant in restaurants)
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
    class Tomato : Vegetables
    {
        // Конструктор
        public Tomato(string symbol, double price)

          : base(symbol, price)

        {

        }
    }
    class Pottato : Vegetables
    {
        // Конструктор
        public Pottato(string symbol, double price)

          : base(symbol, price)

        {

        }
    }
    class Onion : Vegetables
    {
        // Конструктор
        public Onion(string symbol, double price)

          : base(symbol, price)

        {

        }
    }
    // Интерфейс "Observer - Наблюдател"
    interface Restaurant
    {
        void Update(Vegetables vegetables);
    }
    //Клас "ConcreteObserver - Конкретен Наблюдател"
    class Investor : Restaurant
    {
        private string _name;
        private Vegetables vegetables;

        // Конструктор
        public Investor(string name)
        {
            this._name = name;
        }
        public void Update(Vegetables vegetables)
        {

            Console.WriteLine("Известие за: {0}. Цената на {1} " +

              "е променена на {2:C}", _name, vegetables.Symbol, vegetables.Price);

        }
        // Получава или задава зеленчук
        public Vegetables Vegetables
        {
            get { return vegetables; }
            set { vegetables = value; }
        }
    }

    /// Шаблон Observer
    class MainApp
    {
        //Входни точки в конзолната апликация
        static void Main()
        {
            // Задава зеленчуци (домати, картофи, лук) и ги прекрепя към ресторантите

            Tomato tomato = new Tomato("доматите", 1.80);
            Pottato pottato = new Pottato("картофите", 0.33);
            Onion onion = new Onion("лукът", 0.20);

            tomato.Attach(new Investor("Механа 'Под лозата'"));

            pottato.Attach(new Investor("Механа 'Под лозата'"));

            onion.Attach(new Investor("Механа 'Под лозата'"));

            tomato.Attach(new Investor("Пицария 'Темпо'"));

            pottato.Attach(new Investor("Пицария 'Темпо'"));

            onion.Attach(new Investor("Пицария 'Темпо'"));

            tomato.Attach(new Investor("Ресторант 'Зодиак'"));

            pottato.Attach(new Investor("Ресторант 'Зодиак'"));

            onion.Attach(new Investor("Ресторант 'Зодиак'"));


            // Промяната на цената
            tomato.Price = 1.75;
            tomato.Price = 1.95;

            pottato.Price = 0.40;
            pottato.Price = 0.43;

            onion.Price = 0.30;
            onion.Price = 0.25;

            Console.ReadKey();

        }
    }
}