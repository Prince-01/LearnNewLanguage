using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnNewLanguageCore.Language
{
    public interface IAlphabet
    {
        IEnumerable<Character> Characters { get; }
    }
}
