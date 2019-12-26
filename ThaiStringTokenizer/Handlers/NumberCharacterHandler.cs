using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public class NumberCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            var tmpString = characters[index].ToString();
            for (int j = index + 1; j < characters.Length; j++)
            {
                if (IsMatch(characters[j]))
                {
                    tmpString += characters[j];
                    index = j;
                }
                else
                {
                    break;
                }
            }
            outputList.Add(tmpString);

            return index;
        }

        public bool IsMatch(char charNumber) => BasicLatinCharacter.Digits.Contains(charNumber);
    }
}