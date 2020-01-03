using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Handlers
{
    public class EnglishCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override bool IsMatch(char character) => BasicLatinCharacter.Alphabets.Contains(character);
    }
}