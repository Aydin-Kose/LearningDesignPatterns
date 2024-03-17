using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    //ICloneable is bad. Not makes deep copies. returns object
    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            this.Address = address;
        }

        public object Clone()
        {
            //Makes a shadow copy of address
            //return new Person(Names, Address);

            //this version needs cast because Clone returns object
            return new Person((string[])Names.Clone(), (Address)Address.Clone());
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}
