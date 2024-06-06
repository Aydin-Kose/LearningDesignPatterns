using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._7.Composite
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color { get; set; }

        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string(' ', depth))
               .Append(string.IsNullOrEmpty(Color) ? "" : $"{Color} ")
               .AppendLine($"{Name}");
            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
        
    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class DemoComposite
    {
        public static void Composite()
        {
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            Console.WriteLine(drawing);
        }
    }

    // Component
    public abstract class FileSystemComponent
    {
        protected string name;

        public FileSystemComponent(string name)
        {
            this.name = name;
        }

        public abstract void Display(int depth);
    }

    // Leaf
    public class File : FileSystemComponent
    {
        public File(string name) : base(name) { }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    // Composite
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _children = new List<FileSystemComponent>();

        public Directory(string name) : base(name) { }

        public void Add(FileSystemComponent component)
        {
            _children.Add(component);
        }

        public void Remove(FileSystemComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }
}
