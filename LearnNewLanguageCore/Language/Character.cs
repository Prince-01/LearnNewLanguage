using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LearnNewLanguageCore.Language
{
    public class Character
    {
        public Character(char symbol, string internationalNotation, IAlphabet alphabet)
        {
            Symbol = symbol;
            InternationalNotation = internationalNotation;
            Alphabet = alphabet;
        }

        public char Symbol { get; set; }
        public string InternationalNotation { get; set; }
        public IAlphabet Alphabet { get; set; }

        public override string ToString()
        {
            return Symbol.ToString();
        }

        public override bool Equals(object obj)
        {
            var ch = obj as Character;
            return ch != null && Symbol == ch.Symbol;
        }
    }
}