using System;

namespace LearnNewLanguageDroid.LearnLanguage
{
    public class CharacterRandomizer
    {
        private Random _random;
        public string Characters { get; set; }
        public string FilteredCharacters { get; set; }

        public CharacterRandomizer(string characters)
        {
            _random = new Random();
            Characters = characters;
            FilteredCharacters = characters;
        }

        public char GetRandomCharacter()
        {
            return FilteredCharacters[_random.Next(FilteredCharacters.Length)];
        }
    }
}