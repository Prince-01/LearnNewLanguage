using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnNewLanguageCore.Language
{
    public class HiraganaAlphabet : IAlphabet
    {
        private readonly IEnumerable<Character> _characters;
        public IEnumerable<Character> Characters
        {
            get { return _characters; }
        }

        public HiraganaAlphabet()
        {
            _characters = Character.GetMany("あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめももやゆよらりるれろわゐゑをがぎぐげござじずぜぞだぢづでどばびぶべぼぱぴぷぺぽん");
        }
    }
}
