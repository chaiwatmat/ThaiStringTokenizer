using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Handlers
{
    public class EnglishCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override bool IsMatch(char charNumber) => BasicLatinCharacter.Alphabets.Contains(charNumber);
    }
}