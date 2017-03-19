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
            _characters = new List<Character>
            {
                new Character('あ', "a", this),
                new Character('い', "i", this),
                new Character('う', "u", this),
                new Character('え', "e", this),
                new Character('お', "o", this),
                new Character('か', "ka", this),
                new Character('き', "ki", this),
                new Character('く', "ku", this),
                new Character('け', "ke", this),
                new Character('こ', "ko", this),
                new Character('さ', "sa", this),
                new Character('し', "shi", this),
                new Character('す', "su", this),
                new Character('せ', "se", this),
                new Character('そ', "so", this),
                new Character('た', "ta", this),
                new Character('ち', "chi", this),
                new Character('つ', "tsu", this),
                new Character('て', "te", this),
                new Character('と', "to", this),
                new Character('な', "na", this),
                new Character('に', "ni", this),
                new Character('ぬ', "nu", this),
                new Character('ね', "ne", this),
                new Character('の', "no", this),
                new Character('は', "ha", this),
                new Character('ひ', "hi", this),
                new Character('ふ', "fu", this),
                new Character('へ', "he", this),
                new Character('ほ', "ho", this),
                new Character('ま', "ma", this),
                new Character('み', "mi", this),
                new Character('む', "mu", this),
                new Character('め', "me", this),
                new Character('も', "mo", this),
                new Character('や', "ya", this),
                new Character('ゆ', "yu", this),
                new Character('よ', "yo", this),
                new Character('ら', "ra", this),
                new Character('り', "ri", this),
                new Character('る', "ru", this),
                new Character('れ', "re", this),
                new Character('ろ', "ro", this),
                new Character('わ', "wa", this),
                new Character('ゐ', "wi", this),
                new Character('ゑ', "we", this),
                new Character('を', "wo", this),
                new Character('が', "ga", this),
                new Character('ぎ', "gi", this),
                new Character('ぐ', "gu", this),
                new Character('げ', "ge", this),
                new Character('ご', "go", this),
                new Character('ざ', "za", this),
                new Character('じ', "zi", this),
                new Character('ず', "zu", this),
                new Character('ぜ', "ze", this),
                new Character('ぞ', "zo", this),
                new Character('だ', "da", this),
                new Character('ぢ', "di", this),
                new Character('づ', "du", this),
                new Character('で', "de", this),
                new Character('ど', "do", this),
                new Character('ば', "ba", this),
                new Character('び', "bi", this),
                new Character('ぶ', "bu", this),
                new Character('べ', "be", this),
                new Character('ぼ', "bo", this),
                new Character('ぱ', "pa", this),
                new Character('ぴ', "pi", this),
                new Character('ぷ', "pu", this),
                new Character('ぺ', "pe", this),
                new Character('ぽ', "po", this),
                new Character('ん', "n", this)
            };
        }

        public string Name {
            get { return "Hiragana"; }
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
