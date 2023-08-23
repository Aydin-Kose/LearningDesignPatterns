namespace DesignPatterns.Builder
{
    //Open-Closed Principle for adding builder new props
    public class Person
    {
        public string Name, Position;
        public int Experience;

        public class Builder : PersonExperienceBuilder<Builder> { }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(Experience)}: {Experience}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        { return person; }
    }

    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class PersonExperienceBuilder<SELF>
        : PersonJobBuilder<PersonExperienceBuilder<SELF>>
        where SELF : PersonExperienceBuilder<SELF>
    {
        public SELF HaveExperienceForYearsOf(int i)
        {
            person.Experience = i;
            return (SELF)this;
        }
    }
}