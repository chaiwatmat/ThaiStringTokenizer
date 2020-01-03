using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Handlers
{
    public class NumberCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override bool IsMatch(char character) => BasicLatinCharacter.Digits.Contains(character);
    }
}