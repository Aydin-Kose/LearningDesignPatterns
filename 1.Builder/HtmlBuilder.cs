using System.Text;

namespace DesignPatterns.Builder
{
    class HtmlBuilder
    {
        private readonly string rootName;
        private HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            this.rootName = rootName;
        }
        //NotFluent
        public void AddChild(string childName, string childText)
        {
            root.Elements.Add(new HtmlElement(childName, childText));
        }
        //Fluent
        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            root.Elements.Add(new HtmlElement(childName, childText));
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }

    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }
        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);

            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }
            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}