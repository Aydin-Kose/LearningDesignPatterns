using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.FunctionalBuilder
{
    public class Person
    {
        public string Name, Position;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        public TSelf Do(Action<TSubject> action) => AddAction(action);

        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });
            return (TSelf)this;
        }

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        //public PersonBuilder Do(Action<Person> action) => AddAction(action);

        //private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        //private PersonBuilder AddAction(Action<Person> action)
        //{
        //    actions.Add(p => { action(p); return p; });
        //    return this;
        //}

        //public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
    }
    //OpenClosed
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position)
        {
            builder.Do(p => { p.Position = position; });
            return builder;
        }
    }
}
