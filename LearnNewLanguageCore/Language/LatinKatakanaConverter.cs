using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnNewLanguageCore.Language
{
    public class LatinKatakanaConverter
    {
        private LatinKatakanaMapper _mapper;

        public LatinKatakanaConverter()
        {
            _mapper = new LatinKatakanaMapper();
        }

        public Character ConvertToKatakana(string s)
        {
            var mapping = _mapper.Mappings.FirstOrDefault(m => m.LatinExpression == s);
            return mapping != null ? mapping.Character : null;
        }

        public string ConvertToLatin(Character c)
        {
            var mapping = _mapper.Mappings.FirstOrDefault(m => Equals(m.Character, c));
            return mapping != null ? mapping.LatinExpression : string.Empty;
        }
    }
}
