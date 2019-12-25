using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public abstract class CharacterHandler
    {

        public bool IsEnglishCharacter(char charNumber) => BasicLatinCharacter.Alphabets.Contains(charNumber);

        public bool IsNumberCharacter(char charNumber) => BasicLatinCharacter.Digits.Contains(charNumber);

        public bool IsThaiCharacter(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);

    }
}