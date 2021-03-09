using System;
using System.Collections.Generic;

namespace RandomMenuBuilder
{
    class Cook
    {
        public void Construct(MenuBuilder menuBuilder)
        {
            menuBuilder.BuildBurger("пилешки", "телешки", "свински");
            menuBuilder.BuildDrink("кока-кола", "спрайт", "Вода");
            menuBuilder.BuildFrenchFrises("малки", "средни", "големи");
            menuBuilder.BuildToy("кола", "кукла", "конструктор");

        }
    }
    abstract class MenuBuilder
    {
        public abstract void BuildBurger(string chiken, string beef, string pork);
        public abstract void BuildDrink(string cola, string sprite, string water);
        public abstract void BuildFrenchFrises(string M, string L, string XL);
        public abstract void BuildToy(string car, string doll, string lego);
        public abstract Menu GetResult();
    }

    class RandomMenu : MenuBuilder
    {
        private Menu menu = new Menu();
        private Random random = new Random();
        public override void BuildBurger(string chiken, string beef, string pork)
        {
            int count = random.Next(0, 20);
            string burger = " ";
            string[] burgers = new string[3] { "пилешки", "телешки", "свински" };

            int newRandom = random.Next(0, 3);
            burger = burgers[newRandom];
            if (count == 0) { burger = ""; }

            if (burger == chiken)
            {
                double price = 1.80 * count;
                menu.Add("Бургер: " + burger + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }
            else if (burger == beef)
            {
                double price = 2.80 * count;
                menu.Add("Бургер: " + burger + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }
            else
            {
                double price = 2.20 * count;
                menu.Add("Бургер: " + burger + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

            }

        }

        public override void BuildDrink(string cola, string sprite, string water)
        {
            int count = random.Next(0, 20);
            string drink = " ";
            string[] drinks = new string[3] { "кока-кола", "спрайт", "вода" };

            int newRandom = random.Next(0, 3);
            drink = drinks[newRandom];
            if (count == 0) { drink = ""; }
            if (drink == cola || drink == sprite)
            {
                double price = 1.20 * count;
                menu.Add("Напитка:" + drink + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }
            else
            {
                double price = 0.80 * count;
                menu.Add("Напитка:" + drink + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

            }


        }
        public override void BuildFrenchFrises(string M, string L, string XL)
        {
            int count = random.Next(0, 20);
            string frenchFrise = " ";
            string[] frenchFrises = new string[3] { "малки", "средни", "големи" };

            int newRandom = random.Next(0, 3);
            frenchFrise = frenchFrises[newRandom];
            if (count == 0) { frenchFrise = ""; }

            if (frenchFrise == M)
            {
                double price = 1.20 * count;
                menu.Add("Картофки:" + frenchFrise + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

            }
            else if (frenchFrise == L)
            {
                double price = 1.40 * count;
                menu.Add("Картофки:" + frenchFrise + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }
            else
            {
                double price = 2.00 * count;
                menu.Add("Kартофки:" + frenchFrise + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }

        }
        public override void BuildToy(string car, string doll, string lego)
        {
            int count = random.Next(0, 20);
            string toy = " ";
            string[] toys = new string[3] { "кола", "кукла", "конструктор" };

            int newRandom = random.Next(0, 2);
            toy = toys[newRandom];
            if (toy == car)
            {
                double price = 0.50 * count;
                menu.Add("Играчка:" + toy + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }
            else if (toy == doll)
            {
                double price = 0.60 * count;
                menu.Add("Играчка:" + toy + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }
            else
            {
                double price = 0.80 * count;
                menu.Add("Играчка:" + toy + " --- " + count + "бр. --- " + String.Format("{0:C}", price));
            }

        }

        public override Menu GetResult()
        {
            return menu;

        }

    }
    class ManualMenu : MenuBuilder
    {
        private Menu menu = new Menu();
        public override void BuildBurger(string chiken, string beef, string pork)
        {

            Console.WriteLine("Пилешки, телешки или свински бургер?");

            string wish = Console.ReadLine();


            if (wish.Equals("пилешки"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 1.80 * count;

                menu.Add("Вие избрахте ---- Бургер: " + wish + "  --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }

            }
            else if (wish.Equals("телешки"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 2.80 * count;

                menu.Add("Вие избрахте ---- Бургер:" + wish + "  --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else if (wish.Equals("свински"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 2.20 * count;

                menu.Add("Вие избрахте ---- Бургер: " + wish + "  --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                throw new Exception("Не съществува!");
            }

        }

        public override void BuildFrenchFrises(string M, string L, string XL)
        {
            Console.WriteLine("Малки, средни или големи картофки?");

            string wish = Console.ReadLine();
            if (wish.Equals("малки"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 1.20 * count;

                menu.Add("Вие избрахте ---- Картофки: " + wish + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else if (wish.Equals("средни"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 1.40 * count;

                menu.Add("Вие избрахте ---- Картофки: " + wish + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }

            }
            else if (wish.Equals("големи"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 2.00 * count;

                menu.Add("Вие избрахте ---- Картофки: " + wish + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }

            }
            else
            {
                throw new Exception("Не съществува!");
            }
        }

        public override void BuildDrink(string cola, string sprite, string water)
        {
            Console.WriteLine("Кока-кола, спрайт или вода");

            string wish = Console.ReadLine();
            if (wish.Equals("кока-кола") || wish.Equals("спрайт"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 1.20 * count;

                menu.Add("Вие избрахте ---- Напитка: " + wish + "  --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else if (wish.Equals("вода"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 1.20 * count;

                menu.Add("Вие избрахте ---- Напитка: " + wish + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                throw new Exception("Не съществува!");
            }
        }

        public override void BuildToy(string car, string doll, string lego)
        {
            Console.WriteLine("Кукла, кола или конструктор");
            string wish = Console.ReadLine();
            if (wish.Equals("кукла"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 0.60 * count;

                menu.Add("Вие избрахте ---- Играчка: " + wish + "  --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else if (wish.Equals("кола"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 0.50 * count;

                menu.Add("Вие избрахте ---- Играчка: " + wish + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else if (wish.Equals("конструктор"))
            {
                Console.WriteLine("Колко броя?");
                int count = int.Parse(Console.ReadLine());
                double price = 0.80 * count;

                menu.Add("Вие избрахте ---- Играчка: " + wish + " --- " + count + "бр. --- " + String.Format("{0:C}", price));

                while (count < 1 || count > 20)
                {
                    Console.WriteLine("Невалиден брой");
                    count = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                throw new Exception("Не съществува!");
            }
        }
        public override Menu GetResult()
        {
            return menu;
        }
    }
    class Menu
    {
        private List<string> menuParts = new List<string>();
        public void Add(string part)
        {
            menuParts.Add(part);
        }

        public void GetInfo()
        {
            double totalPrice = 0;

            Console.WriteLine("\n------- Меню ---------");

            foreach (string part in menuParts)
            {
                Console.WriteLine(part);
                int pFrom = part.LastIndexOf("--- ") + "--- ".Length;
                int pTo = part.LastIndexOf("лв.");
                totalPrice += Convert.ToDouble(part.Substring(pFrom, pTo - pFrom));
            }

            Console.WriteLine("\n------- Обща цена ---------");
            Console.WriteLine("         " + String.Format("{0:C}", totalPrice));

        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Автоматично генериране на меню или собствено?");

            Cook cooker = new Cook();

            MenuBuilder builderMenu;

            string wish = Console.ReadLine();
            if (wish.Equals("автоматично"))
            {

                builderMenu = new RandomMenu();

            }

            else if (wish.Equals("собствено"))
            {


                builderMenu = new ManualMenu();

            }
            else
            {
                throw new Exception("Не съществува!");
            }



            cooker.Construct(builderMenu);

            Menu menu = builderMenu.GetResult();


            menu.GetInfo();



        }
    }
}
