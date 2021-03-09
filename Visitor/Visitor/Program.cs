using System;
using System.Collections.Generic;

namespace GangOfFour.Visitor.RealWorld
{
    //Интерфейс 'Visitor'
    abstract class Visitor

    {
        private string _name;

        public abstract void Visit(Element element);

        public Visitor(string name)
        {
            this._name = name;
        }
    }
    ///Конкретен гост
    class Guest : Visitor
    {
        private string name;
        public Guest(string name) : base(name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }


        public override void Visit(Element element)

        {

            Host student = element as Host;

            Console.WriteLine(" При {0} e дошла на гости {1}", student.Name, this.Name);


            student.Money += 20.40;

            Console.WriteLine("{2} дава пари на {0} и сега има {1:C} ",

               student.Name,

              student.Money, this.Name);

        }

    }
    ///Конкретен гост 2
    class Guest2 : Visitor

    {
        private string name;
        public Guest2(string name) : base(name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public override void Visit(Element element)

        {

            Host student = element as Host;

            Console.WriteLine("При {0} e е дошла на гости {1}", student.Name, this.Name);

            // Provide 3 extra vacation days

            student.Candies += 1;

            Console.WriteLine("{0} получава от {2} кутия шоколадови бонбони и сега тя има {1} кутии",

               student.Name,

              student.Candies, this.Name);

        }

    }
    //Конкретен гост 3
    class Guest3 : Visitor

    {
        private string name;
        public Guest3(string name) : base(name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public override void Visit(Element element)

        {

            Host student = element as Host;

            Console.WriteLine("При {0} e дошла на гости {1}", student.Name, this.Name);



            student.Present = "подарък";

            Console.WriteLine("{0} получава от {2} {1} ",

               student.Name,

              student.Present, this.Name);

        }

    }
    /// Абстрактен клас Елемент
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);

    }

    ///Клас с конкретен елемент
    class Host : Element

    {

        private string _name;

        private double _money;

        private int candies;

        private string present;


        // Конструктор

        public Host(string name, double money,

          int candies, string present)

        {

            this._name = name;

            this._money = money;

            this.candies = candies;

            this.present = present;
        }



        // Задава или взима име

        public string Name

        {

            get { return _name; }

            set { _name = value; }

        }



        // Задава или взима парите

        public double Money

        {

            get { return _money; }

            set { _money = value; }

        }



        //Задава или взима бонбони

        public int Candies

        {

            get { return candies; }

            set { candies = value; }

        }

        public string Present
        {
            get { return present; }

            set { present = value; }
        }


        public override void Accept(Visitor visitor)

        {

            visitor.Visit(this);

        }

    }

    // Класът ObjectStructure
    class Hosts
    {
        private List<Host> hosts = new List<Host>();

        public void Attach(Host student)

        {

            hosts.Add(student);

        }

        public void Detach(Host student)

        {

            hosts.Remove(student);

        }



        public void Accept(Visitor visitor)

        {

            foreach (Host s in hosts)

            {

                s.Accept(visitor);

            }

            Console.WriteLine();

        }

    }

    class Kremena : Host

    {

        // Конструктор

        public Kremena()

          : base("Кремена", 110.60, 0, "No")

        {

        }

    }



    class Plamena : Host

    {

        // Конструктор

        public Plamena()

          : base("Пламена", 6.80, 1, "No")

        {

        }

    }



    class Monika : Host

    {

        // Конструктор

        public Monika()

          : base("Моника", 40.30, 2, "No")

        {

        }

    }
    //Шаблона Visitor
    class MainApp

    {
        //Входни точки в конзолата
        static void Main()

        {

            //Взима данни на домакините

            Hosts s = new Hosts();

            s.Attach(new Kremena());

            s.Attach(new Plamena());

            s.Attach(new Monika());



            //Домакините са посетени от:

            s.Accept(new Guest("Илияна"));

            s.Accept(new Guest2("Ивелина"));

            s.Accept(new Guest3("Ваня"));

            Console.ReadKey();

        }

    }

}


