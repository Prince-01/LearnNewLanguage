using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnNewLanguageCore.Language
{
    public interface IAlphabet
    {
        string Name { get; }
        IEnumerable<Character> Characters { get; }
        Character GetCharacter(char symbol);
        Character GetCharacter(string internationalNotation);
    }
}
