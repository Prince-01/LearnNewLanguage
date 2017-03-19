using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LearnNewLanguageCore.Language
{
    public class Character
    {
        public Character(char symbol)
        {
            Symbol = symbol;
        }

        public char Symbol { get; set; }

        public override string ToString()
        {
            return Symbol.ToString();
        }

        public override bool Equals(object obj)
        {
            var ch = obj as Character;
            return ch != null && Symbol == ch.Symbol;
        }

        public static explicit operator Character(char c)
        {
            return new Character(c);
        }

        public static IEnumerable<Character> GetMany(string s)
        {
            return s.Cast<char>().Select(character => (Character) character).ToList();
        }
    }
}