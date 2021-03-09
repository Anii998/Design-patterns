using System;

namespace Library_Adapter
{

    // Target класа
    // Дефинира конкретният клас, изпозлван от Client
    class Library
    {
        protected string id;
        protected string book;
        protected string author;
        protected int year;
        protected string genre;

        //Конструктор
        public Library(string id)
        {
            this.id = id;
        }
        public virtual void Display()
        {
            Console.WriteLine(" {0} ------ ", id);
        }
    }
    //Адаптер клас
    //адаптира интерфейса на Adaptee към интерфейса на Target
    class Book : Library
    {
        private DataBook bank;

        //Конструктор
        public Book(string name) : base(name)
        {
        }
        public override void Display()
        {
            //Adaptee
            //Дефинира съществуващ интерфейс, нуждаещ се от адаптиране
            bank = new DataBook();

            book = bank.GetBook(id);
            author = bank.GetAuthor(id);
            year = bank.GetYear(id, " ");
            genre = bank.GetGenre(id);


            base.Display();

            Console.WriteLine("Книга: {0}", book);
            Console.WriteLine("Автор: {0}", author);
            Console.WriteLine("Година: {0}", year);
            Console.WriteLine("Жанр: {0}", genre);

        }
    }
    //Adaptee клас
    class DataBook
    {
        //Базата данни
        //Взима име на книгата
        public string GetBook(string element)
        {

            switch (element.ToLower())
            {
                case "книга 1": return "Алиса в страната на чудесата";
                case "книга 2": return "Хари Потър и философският камък";
                case "книга 3": return "Под Игото";
                default: return "-";
            }
        }
        //Взима автор на книгата
        public string GetAuthor(string element)
        {

            switch (element.ToLower())
            {
                case "книга 1": return "Луис Карол";
                case "книга 2": return "Джоан Роулинг";
                case "книга 3": return "Иван Вазов";
                default: return "-";
            }
        }
        //Взима година на книгата
        public int GetYear(string element, string year)
        {
            switch (element)
            {
                case "книга 1": return 1865;
                case "книга 2": return 1997;
                case "книга 3": return 1893;
                default: return 0;

            }
        }
        //Взима жанр на книгата
        public string GetGenre(string element)
        {
            switch (element.ToLower())
            {
                case "книга 1": return "Детска литература";
                case "книга 2": return "Фентъзи";
                case "книга 3": return "Исторически";
                default: return "-";
            }
        }
    }
    //Шаблонът Adapter
    class Program
    {
        //Входни точки 
        static void Main()
        {
            Book book1 = new Book("книга 1");
            book1.Display();

            Book book2 = new Book("книга 2");
            book2.Display();

            Book book3 = new Book("книга 3");
            book3.Display();

            Console.ReadKey();
        }
    }
}
