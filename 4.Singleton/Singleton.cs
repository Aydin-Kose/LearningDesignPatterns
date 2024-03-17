using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._4.Singleton
{
    
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase()
        {
            Console.WriteLine("Initializing Db");
            capitals = File.ReadAllLines("capitals.txt")
                .Select((line, index) => new { line, index })
                .GroupBy(x => x.index / 2)
                .ToDictionary(
                    list => list.ElementAt(0).line.Trim(),
                    list => int.Parse(list.ElementAt(1).line));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
    }
}
