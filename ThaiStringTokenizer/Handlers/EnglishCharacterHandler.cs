using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public class EnglishCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override bool IsMatch(char charNumber) => BasicLatinCharacter.Alphabets.Contains(charNumber);
    }
}