using DesignPatterns.Prototype.IDeepCopyable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype.DeepCopyWithSerialization
{
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }

    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Employee : Person
    {
        public int Salary;

        public Employee(string[] names, Address address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            string json = JsonSerializer.Serialize(self);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
