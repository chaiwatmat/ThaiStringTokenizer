using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public class NumberCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override bool IsMatch(char charNumber) => BasicLatinCharacter.Digits.Contains(charNumber);
    }
}