using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public abstract class CharacterHandler
    {
        public Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();
        public bool RemoveSpace { get; set; }
        public bool ShortWordFirst { get; set; }

        public string[] Words { get; set; }

        public bool IsEnglishCharacter(char charNumber) => BasicLatinCharacter.Alphabets.Contains(charNumber);

        public bool IsNumberCharacter(char charNumber) => BasicLatinCharacter.Digits.Contains(charNumber);

        public bool IsThaiCharacter(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);

    }
}