using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public class ThaiCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            var tmpString = characters[index].ToString();

            bool isFound = false;
            string moretmp = tmpString;

            for (int j = index + 1; j < characters.Length; j++)
            {
                moretmp += characters[j].ToString();
                var firstCharacter = moretmp[0];

                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                foreach (var word in Dictionary[firstCharacter])
                {
                    if (word == moretmp)
                    {
                        tmpString = moretmp;
                        index = j;
                        isFound = true;
                        break;
                    }
                }

                if (ShortWordFirst)
                {
                    break;
                }
            }

            if (isFound)
            {
                outputList.Add(tmpString);
            }
            else
            {
                var lastOutputIndex = outputList.Count - 1;

                outputList[lastOutputIndex] += tmpString;
            }

            return index;
        }

        public bool IsMatch(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);
    }
}