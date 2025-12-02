using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

    abstract class Car
    {
        public abstract void Info();
    }

    // ConcreteProductA1
    class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    // ConcreteProductA2
    class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    // н
    class Mersedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mersedes");
        }
    }

    abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine 4.4");
        }
    }

    // ConcreteProductB2
    class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine 3.2");
        }
    }

    // н
    class MersedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mersedes Engine 5.0 V8");
        }
    }

    interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }


    // ConcreteFactory1
    class FordFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Ford();
        }
        public Engine CreateEngine()
        {
            return new FordEngine();
        }
    }

    // ConcreteFactory2
    class ToyotaFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Toyota();
        }
        public Engine CreateEngine()
        {
            return new ToyotaEngine();
        }
    }

    // н
    class MersedesFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Mersedes(); 
        }
        public Engine CreateEngine()
        {
            return new MersedesEngine();
        }
    }

    // (Main)
    public class FactoryClient
    {
        static void Main(string[] args)
        {
            // Toyota
            ICarFactory carFactory = new ToyotaFactory();
            Car myCar = carFactory.CreateCar();
            myCar.Info();
            Engine myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            // Ford
            carFactory = new FordFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            // Mersedes
            Console.WriteLine("\n--- Створення Mersedes ---");
            carFactory = new MersedesFactory();
            myCar = carFactory.CreateCar();
            myCar.Info();
            myEngine = carFactory.CreateEngine();
            myEngine.GetPower();

            Console.ReadKey();
        }
    }
}