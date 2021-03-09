using System;

namespace GangOfFour.Memento.RealWorld
{
    // Клас 'Originator' 
    // изпозлва спомена, за да възстанови вътрешното си състояние
    class SalesProspect
    {
        private string product;
        private string count;
        private double price;

        // Получава или задава име на продукт
        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                Console.WriteLine("Продукт:  " + product);
            }
        }

        // Получава или задава брой
        public string Count
        {
            get { return count; }
            set
            {
                count = value;
                Console.WriteLine("Количество: " + count);
            }
        }

        // Получава или задава цена
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                Console.WriteLine("Цена: " + price);
            }
        }

        // Съхраняване
        public Memento SaveMemento()
        {
            Console.WriteLine("\nРедактиране на състоянието --\n");
            return new Memento(product, count, price);
        }

        // Възстановяване
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nВъзстановяване на състояние --\n");
            this.Product = memento.Product;
            this.Count = memento.Count;
            this.Price = memento.Price;
        }
    }

   
    //Клас 'Memento- Спомен' 
  
    class Memento
    {
        private string product;
        private string count;
        private double price;

        // Конструктор
        public Memento(string product, string count, double price)
        {
            this.product = product;
            this.count = count;
            this.price = price;
        }

        // Получава или задава име на продукт
        public string Product
        {
            get { return product; }
            set { product = value; }
        }

        // Получава или задава брой
        public string Count
        {
            get { return count; }
            set { count = value; }
        }

        // Получава или задава цена
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }

   
    // Клас 'Caretaker'
    // отговорен за съхраняването на спомена

    class ProspectMemory
    {
        private Memento _memento;

        // Свойства
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
     // Шаблон Memento-Спомен
    class MainApp
    {
    
        // Входни точки в конзолата
        static void Main()
        {
            SalesProspect s = new SalesProspect();
            s.Product = "Шоколад";
            s.Count = "4 броя";
            s.Price = 4.80;

            // Съхранява вътрешното състояние
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Промяната на състоянието
            s.Product = "Торта";
            s.Count = "3 броя";
            s.Price = 25.80;

            // Възстановява запазеното състояние
            s.RestoreMemento(m.Memento);

            // Изчакване на потребителя
            Console.ReadKey();
        }
    }

}
