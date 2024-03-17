using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public interface IHotDrink
    {
        public void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Drinks tea!");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Drinks Coffee!");
        }
    }

    internal interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("Prepares Tea");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("Prepares Coffee");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("DesignPatterns.Factory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int Amount)
        {
            return factories[drink].Prepare(Amount);
        }
    }
}
