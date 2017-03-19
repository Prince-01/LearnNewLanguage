namespace LearnNewLanguageCore.Language
{
    public class CharacterMapping
    {
        public CharacterMapping(char character, string latinExpression)
        {
            LatinExpression = latinExpression;
            Character = (Character)character;
        }
        public string LatinExpression { get; set; }
        public Character Character { get; set; }
    }
}