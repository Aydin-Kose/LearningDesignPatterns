using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{

    //Builder Coding Exercise
    //You are asked to implement the Builder design pattern for rendering simple chunks of code.

    //Sample use of the builder you are asked to create:

    //var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
    //Console.WriteLine(cb);
    //The expected output of the above code is:

    //public class Person
    //{
    //  public string Name;
    //  public int Age;
    //}
    //Please observe the same placement of curly braces and use two-space indentation.

    public class ClassObj
    {
        public string Name;
        public List<Attiributes> Properties = new List<Attiributes>();

        public class Attiributes
        {
            public string Name, Type;
        }
    }

    public class CodeBuilder
    {
        private ClassObj c = new ClassObj();
        public CodeBuilder(string className)
        {
            c.Name = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            c.Properties.Add(new ClassObj.Attiributes()
            {
                Name = name,
                Type = type
            });
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"public class {c.Name}{Environment.NewLine}");
            sb.AppendLine("{");
            foreach ( var item in c.Properties )
            {
                sb.AppendLine($"  public {item.Type} {item.Name};");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
