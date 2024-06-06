using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._10.FlyWeight
{
    using System;
    using System.Collections.Generic;

    // Flyweight interface
    interface ICharacter
    {
        void Display();
    }

    // Concrete Flyweight class
    class Character : ICharacter
    {
        private char _symbol;
        private string _font;
        private int _size;
        private ConsoleColor _color;

        public Character(char symbol, string font, int size, ConsoleColor color)
        {
            _symbol = symbol;
            _font = font;
            _size = size;
            _color = color;
        }

        public void Display()
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"Character: {_symbol}, Font: {_font}, Size: {_size}");
            Console.ResetColor();
        }
    }

    // Flyweight factory
    class CharacterFactory
    {
        private Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

        public ICharacter GetCharacter(char symbol, string font, int size, ConsoleColor color)
        {
            if (!_characters.ContainsKey(symbol))
            {
                _characters[symbol] = new Character(symbol, font, size, color);
            }
            return _characters[symbol];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharacterFactory factory = new CharacterFactory();

            // Creating and displaying characters
            ICharacter char1 = factory.GetCharacter('A', "Arial", 12, ConsoleColor.Red);
            char1.Display();

            ICharacter char2 = factory.GetCharacter('B', "Arial", 12, ConsoleColor.Blue);
            char2.Display();

            // Reusing existing character
            ICharacter char3 = factory.GetCharacter('A', "Arial", 12, ConsoleColor.Red);
            char3.Display();

            // Check if the same instance is returned
            Console.WriteLine($"char1 == char3 : {ReferenceEquals(char1, char3)}");
        }
    }

}
