using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnNewLanguageCore.Language
{
    public class KatakanaAlphabet : IAlphabet
    {
        private readonly IEnumerable<Character> _characters;
        public IEnumerable<Character> Characters
        {
            get { return _characters; }
        }

        public KatakanaAlphabet()
        {
            _characters = Character.GetMany("アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン");
        }
    }
}
