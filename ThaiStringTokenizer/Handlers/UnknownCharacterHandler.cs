using System.Collections.Generic;

namespace ThaiStringTokenizer.Handlers
{
    public class UnknownCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override int HandleCharacter(List<string> resultWords, char[] characters, int index)
        {
            resultWords.Add(characters[index].ToString());

            return index;
        }
    }
}