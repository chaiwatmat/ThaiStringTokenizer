using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Handlers
{
    public class ThaiCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override int HandleCharacter(List<string> resultWords, char[] characters, int index)
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
                resultWords.Add(tmpString);
            }
            else
            {
                var lastOutputIndex = resultWords.Count - 1;
                var lastWord = resultWords[lastOutputIndex];

                var firstCharacter = tmpString[0];
                if (Dictionary.ContainsKey(firstCharacter) && Dictionary[firstCharacter].Contains(lastWord))
                {
                    resultWords.Add(tmpString);
                }
                else
                {
                    resultWords[lastOutputIndex] += tmpString;
                }
            }

            return index;
        }

        public override bool IsMatch(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);
    }
}