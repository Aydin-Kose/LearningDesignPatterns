using System.Text;
using DesignPatterns.Builder;
using DesignPatterns.Builder.FacatedBuilder;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tsb = new TheStringBuilder();
            //Console.WriteLine(tsb.UseOfStringBuilder());

            //var builder = new HtmlBuilder("ul");
            //builder.AddChild("li", "hello");
            //builder.AddChild("li", "world");
            //Console.WriteLine(builder.ToString());

            //builder.Clear(); // disengage builder from the object it's building, then...
            //builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
            //Console.WriteLine(builder);

            //var personString = Person.New
            //    .Called("Aydin")
            //    .WorkAsA("Developer")
            //    .HaveExperienceForYearsOf(5)
            //    .Build()
            //    .ToString();
            //Console.WriteLine(personString);

            //var car = CarBuilder.Create()
            //    .OfType(CarType.Sedan)
            //    .WithWheels(17)
            //    .Build();

            //var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            //Console.WriteLine(cb);

            DotNetDesignPatternDemos.Structural.Adapter.NoCaching.Demo.MainAdapter();
        }
    }
}