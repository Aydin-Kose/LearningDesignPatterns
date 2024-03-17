using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{

    //Factory Coding Exercise
    //You are given a class called Person . The person has two fields: Id , and Name .
    //Please implement a non-static PersonFactory  that has a CreatePerson()  method that takes a person's name.
    //The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0, second Id=1 and so on.
    
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        public int id = 0;
        public Person CreatePerson(string name)
        {
            return new Person { Id = id++, Name = name };
        }
    }
}
