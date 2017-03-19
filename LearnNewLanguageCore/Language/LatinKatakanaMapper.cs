using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnNewLanguageCore.Language
{
    public class LatinKatakanaMapper
    {
        private readonly IEnumerable<CharacterMapping> _mappings;
        public IEnumerable<CharacterMapping> Mappings { get { return _mappings; } }

        public LatinKatakanaMapper()
        {
            _mappings = new List<CharacterMapping>
            {
                new CharacterMapping('セ', "se"),
                new CharacterMapping('ソ', "so"),
                new CharacterMapping('タ', "ta"),
                new CharacterMapping('チ', "chi"),
                new CharacterMapping('ツ', "tsu"),
                new CharacterMapping('テ', "te"),
                new CharacterMapping('ト', "to"),
                new CharacterMapping('ナ', "na"),
                new CharacterMapping('ニ', "ni"),
                new CharacterMapping('ヌ', "nu"),
                new CharacterMapping('ネ', "ne"),
                new CharacterMapping('ノ', "no"),
                new CharacterMapping('ハ', "ha"),
                new CharacterMapping('ヒ', "hi"),
                new CharacterMapping('フ', "fu"),
                new CharacterMapping('ヘ', "he"),
                new CharacterMapping('ホ', "ho"),
                new CharacterMapping('マ', "ma"),
                new CharacterMapping('ミ', "mi"),
                new CharacterMapping('ム', "mu"),
                new CharacterMapping('メ', "me"),
                new CharacterMapping('モ', "mo"),
                new CharacterMapping('ヤ', "ya"),
                new CharacterMapping('ユ', "yu"),
                new CharacterMapping('ヨ', "yo"),
                new CharacterMapping('ラ', "ra"),
                new CharacterMapping('リ', "ri"),
                new CharacterMapping('ル', "ru"),
                new CharacterMapping('レ', "re"),
                new CharacterMapping('ロ', "ro"),
                new CharacterMapping('ワ', "wa"),
                new CharacterMapping('ヲ', "o (wo)"),
                new CharacterMapping('ン', "n")
            };
        }
    }
}
