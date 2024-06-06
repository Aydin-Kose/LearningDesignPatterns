using System.Text;
using DesignPatterns._7.Composite;
using DesignPatterns.Builder;
using DesignPatterns.Builder.FacatedBuilder;

namespace DesignPatterns
{

    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            WriteLine(sentence); // writes "hello WORLD"
        }

        public class Sentence
        {
            private Dictionary<int, Tuple<string, WordToken>> _words;
            public Sentence(string plainText)
            {
                string[] words = plainText.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    string? word = words[i];
                    _words.Add(i, new(word, new WordToken()));
                }
            }

            public WordToken this[int index]
            {
                get
                {
                    return new WordToken();
                }
            }

            public override string ToString()
            {
                // output formatted text here
            }

            public class WordToken
            {
                public bool Capitalize;
            }
        }
    }
}