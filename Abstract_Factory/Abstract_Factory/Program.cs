using System;

//Клас Choose Factory избира между Japanese factory и European factory
class ChooseFactory
{
    public string GetFactory(string toyotafactory)
    {
        switch (toyotafactory)
        {
            case "Japanese factory":
                {
                    ToyotaFactory myToyota = new JapanFactory();
                    var prius = myToyota.CreateModel();
                    prius.Print();
                    break;
                }
            case "European factory":
                {
                    ToyotaFactory myToyota = new EuropaFactory();
                    var corolla = myToyota.CreateModel();
                    corolla.Print();
                    break;
                }
            default:
                Console.WriteLine("This factory does not exists");
                break;
        }
        return toyotafactory;
    }
}
//Клас който създава ConctereProduct- 'CorollaToyota'
//Дефинира продукт, който да бъде създаден от конкретна фабрика - 'Toyota'
class CorollaToyota : Toyota
{
    public override string Name
    {
        get { return "Toyota Corolla"; }
    }

    public override string Model
    {
        get { return "Corolla"; }
    }

    public override string EngineType
    {
        get { return "Fuel"; }
    }

    public override string Color
    {
        get { return "Grey"; }
    }

    public override void Print()
    {
        Console.WriteLine("The name of my car is: {0}", Name);
        Console.WriteLine("The model is: {0}", Model);
        Console.WriteLine("The engine type is: {0}", EngineType);
        Console.WriteLine("The color is: {0}", Color);
    }
}
//ConcreteFactory - имплементира операциите за създаване на конкретни продукти 
//EuropaFactory
class EuropaFactory : ToyotaFactory
{
    public override Toyota CreateModel()
    {
        return new CorollaToyota();
    }
}
//ConcreteFactory - имплементира операциите за създаване на конкретни продукти 
//JapanFactory

class JapanFactory : ToyotaFactory
{
    public override Toyota CreateModel()
    {
        return new PriusToyota();
    }
}

//Клас който създава ConctereProduct- 'PriusToyota'
//Дефинира продукт, който да бъде създаден от конкретна фабрика - 'Toyota'
class PriusToyota : Toyota
{
    public override string Name
    {
        get { return "Toyota Prius"; }
    }
    public override string Model
    {
        get { return "Prius"; }
    }
    public override string EngineType
    {
        get { return "Electrical"; }
    }
    public override string Color
    {
        get { return "White"; }
    }

    public override void Print()
    {
        Console.WriteLine("The name of my car is: {0}", Name);
        Console.WriteLine("The model is: {0}", Model);
        Console.WriteLine("The engine type is: {0}", EngineType);
        Console.WriteLine("The color is: {0}", Color);
    }
}
//AbstractProduct - декларира интерфейс за клас продукти
abstract class Toyota
{
    public abstract string Name { get; }
    public abstract string Model { get; }
    public abstract string EngineType { get; }
    public abstract string Color { get; }

    public abstract void Print();
}
//AbstractFactory - декларира интерфейс с методи за създаване на абстрактни продукти
abstract class ToyotaFactory
{
    public abstract Toyota CreateModel();
}
//Abstract Factory Design Pattern
class Program
{    //Входни точки в конзолата
    static void Main(string[] args)
    {
        Console.WriteLine("Please choose a Toyota factory:");
        string choice = Console.ReadLine();

        //Създава и стартира избрания межу Japanese Factory и European Factory
        ChooseFactory factory = new ChooseFactory();
        factory.GetFactory(choice);

        Console.WriteLine();

    }
}