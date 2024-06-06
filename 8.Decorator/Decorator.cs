using DesignPatterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._8.Decorator
{
    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }
    public class PlainPizza : IPizza
    {
        public string GetDescription()
        {
            return "Plain Pizza";
        }

        public double GetCost()
        {
            return 5.0;
        }
    }
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string GetDescription()
        {
            return _pizza.GetDescription();
        }

        public virtual double GetCost()
        {
            return _pizza.GetCost();
        }
    }
    public class Cheese : PizzaDecorator
    {
        public Cheese(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return $"{_pizza.GetDescription()}, Cheese";
        }

        public override double GetCost()
        {
            return _pizza.GetCost() + 1.0;
        }
    }

    public class Pepperoni : PizzaDecorator
    {
        public Pepperoni(IPizza pizza) : base(pizza)
        {
        }

        public override string GetDescription()
        {
            return $"{_pizza.GetDescription()}, Pepperoni";
        }

        public override double GetCost()
        {
            return _pizza.GetCost() + 2.0;
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Create a plain pizza
    //        IPizza pizza = new PlainPizza();
    //        Console.WriteLine($"Description: {pizza.GetDescription()}");
    //        Console.WriteLine($"Cost: ${pizza.GetCost()}");

    //        // Add cheese
    //        pizza = new Cheese(pizza);
    //        Console.WriteLine($"Description: {pizza.GetDescription()}");
    //        Console.WriteLine($"Cost: ${pizza.GetCost()}");

    //        // Add pepperoni
    //        pizza = new Pepperoni(pizza);
    //        Console.WriteLine($"Description: {pizza.GetDescription()}");
    //        Console.WriteLine($"Cost: ${pizza.GetCost()}");

    //        Console.ReadLine();
    //    }
    //}
}
