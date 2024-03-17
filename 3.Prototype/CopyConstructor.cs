using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype.CopyConstructor
{
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            this.Address = address;
        }
        
        //Copy Constructor
        //better from IClonable
        public Person(Person other)
        {
            Names = other.Names.Clone() as string[];
            Address = new Address(other.Address);
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        //Copy Constructor
        public Address(Address other)
        {
            StreetName=other.StreetName;
            HouseNumber=other.HouseNumber;
        }
    }
}
