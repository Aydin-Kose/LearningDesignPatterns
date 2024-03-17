using System.Text;

namespace DesignPatterns.Builder
{
    class TheStringBuilder
    {
        public string UseOfStringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append("hello");
            sb.Append("<p>");

            var words = new string[] { "hello", "world" };
            sb.Append(Environment.NewLine);
            sb.Append("ul");
            foreach (var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>");
            }
            sb.Append("/ul");
            return sb.ToString();
        }
    }
}