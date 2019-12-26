using System.Collections.Generic;

namespace ThaiStringTokenizer
{
    public class UnknownCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        private char _character;
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            outputList.Add(_character.ToString());

            return index;
        }

        public bool IsMatch(char character)
        {
            _character = character;

            return true;
        }
    }
}