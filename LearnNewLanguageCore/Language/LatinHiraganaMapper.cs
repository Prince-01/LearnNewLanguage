using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LearnNewLanguageCore.Language
{
    public class LatinHiraganaMapper
    {
        private readonly IEnumerable<CharacterMapping> _mappings;
        public IEnumerable<CharacterMapping> Mappings { get { return _mappings; } }

        public LatinHiraganaMapper()
        {
            _mappings = new List<CharacterMapping>
            {
                new CharacterMapping('あ', "a"),
                new CharacterMapping('い', "i"),
                new CharacterMapping('う', "u"),
                new CharacterMapping('え', "e"),
                new CharacterMapping('お', "o"),
                new CharacterMapping('か', "ka"),
                new CharacterMapping('き', "ki"),
                new CharacterMapping('く', "ku"),
                new CharacterMapping('け', "ke"),
                new CharacterMapping('こ', "ko"),
                new CharacterMapping('さ', "sa"),
                new CharacterMapping('し', "shi"),
                new CharacterMapping('す', "su"),
                new CharacterMapping('せ', "se"),
                new CharacterMapping('そ', "so"),
                new CharacterMapping('た', "ta"),
                new CharacterMapping('ち', "chi"),
                new CharacterMapping('つ', "tsu"),
                new CharacterMapping('て', "te"),
                new CharacterMapping('と', "to"),
                new CharacterMapping('な', "na"),
                new CharacterMapping('に', "ni"),
                new CharacterMapping('ぬ', "nu"),
                new CharacterMapping('ね', "ne"),
                new CharacterMapping('の', "no"),
                new CharacterMapping('は', "ha"),
                new CharacterMapping('ひ', "hi"),
                new CharacterMapping('ふ', "fu"),
                new CharacterMapping('へ', "he"),
                new CharacterMapping('ほ', "ho"),
                new CharacterMapping('ま', "ma"),
                new CharacterMapping('み', "mi"),
                new CharacterMapping('む', "mu"),
                new CharacterMapping('め', "me"),
                new CharacterMapping('も', "mo"),
                new CharacterMapping('や', "ya"),
                new CharacterMapping('ゆ', "yu"),
                new CharacterMapping('よ', "yo"),
                new CharacterMapping('ら', "ra"),
                new CharacterMapping('り', "ri"),
                new CharacterMapping('る', "ru"),
                new CharacterMapping('れ', "re"),
                new CharacterMapping('ろ', "ro"),
                new CharacterMapping('わ', "wa"),
                new CharacterMapping('ゐ', "wi"),
                new CharacterMapping('ゑ', "we"),
                new CharacterMapping('を', "wo"),
                new CharacterMapping('が', "ga"),
                new CharacterMapping('ぎ', "gi"),
                new CharacterMapping('ぐ', "gu"),
                new CharacterMapping('げ', "ge"),
                new CharacterMapping('ご', "go"),
                new CharacterMapping('ざ', "za"),
                new CharacterMapping('じ', "zi"),
                new CharacterMapping('ず', "zu"),
                new CharacterMapping('ぜ', "ze"),
                new CharacterMapping('ぞ', "zo"),
                new CharacterMapping('だ', "da"),
                new CharacterMapping('ぢ', "di"),
                new CharacterMapping('づ', "du"),
                new CharacterMapping('で', "de"),
                new CharacterMapping('ど', "do"),
                new CharacterMapping('ば', "ba"),
                new CharacterMapping('び', "bi"),
                new CharacterMapping('ぶ', "bu"),
                new CharacterMapping('べ', "be"),
                new CharacterMapping('ぼ', "bo"),
                new CharacterMapping('ぱ', "pa"),
                new CharacterMapping('ぴ', "pi"),
                new CharacterMapping('ぷ', "pu"),
                new CharacterMapping('ぺ', "pe"),
                new CharacterMapping('ぽ', "po"),
                new CharacterMapping('ん', "n")
            };
        }
    }
}
