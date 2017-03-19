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
            _characters = new List<Character>
            {
                new Character('セ', "se", this),
                new Character('ソ', "so", this),
                new Character('タ', "ta", this),
                new Character('チ', "chi", this),
                new Character('ツ', "tsu", this),
                new Character('テ', "te", this),
                new Character('ト', "to", this),
                new Character('ナ', "na", this),
                new Character('ニ', "ni", this),
                new Character('ヌ', "nu", this),
                new Character('ネ', "ne", this),
                new Character('ノ', "no", this),
                new Character('ハ', "ha", this),
                new Character('ヒ', "hi", this),
                new Character('フ', "fu", this),
                new Character('ヘ', "he", this),
                new Character('ホ', "ho", this),
                new Character('マ', "ma", this),
                new Character('ミ', "mi", this),
                new Character('ム', "mu", this),
                new Character('メ', "me", this),
                new Character('モ', "mo", this),
                new Character('ヤ', "ya", this),
                new Character('ユ', "yu", this),
                new Character('ヨ', "yo", this),
                new Character('ラ', "ra", this),
                new Character('リ', "ri", this),
                new Character('ル', "ru", this),
                new Character('レ', "re", this),
                new Character('ロ', "ro", this),
                new Character('ワ', "wa", this),
                new Character('ヲ', "o (wo)", this),
                new Character('ン', "n", this)
            };
        }

        public string Name
        {
            get { return "Katakana"; }
        }

        public Character GetCharacter(char symbol)
        {
            return _characters.First(c => c.Symbol == symbol);
        }

        public Character GetCharacter(string internationalNotation)
        {
            return _characters.First(c => c.InternationalNotation == internationalNotation);
        }
    }
}
