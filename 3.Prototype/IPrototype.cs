using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype.IPrototype
{
    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            this.Address = address;
        }

        public Person DeepCopy()
        {
            return new Person((string[])Names.Clone(), Address.DeepCopy());
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }

    //Better designed IClonable for deepcopy
    public interface IPrototype<T>
    {
        public T DeepCopy();
    }
}
