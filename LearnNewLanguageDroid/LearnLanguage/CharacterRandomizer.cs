using System;
using System.Collections.Generic;
using System.Linq;
using LearnNewLanguageCore.Language;

namespace LearnNewLanguageDroid.LearnLanguage
{
    public class CharacterRandomizer
    {
        private readonly Random _random;
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Character> FilteredCharacters { get; set; }

        public CharacterRandomizer(IEnumerable<Character> characters)
        {
            _random = new Random();
            Characters = characters;
            FilteredCharacters = characters;
        }

        public Character GetRandomCharacter()
        {
            if (!FilteredCharacters.Any())
                throw new NoCharactersAvailableException();

            return FilteredCharacters.ElementAt(_random.Next(FilteredCharacters.Count()));
        }
    }
}