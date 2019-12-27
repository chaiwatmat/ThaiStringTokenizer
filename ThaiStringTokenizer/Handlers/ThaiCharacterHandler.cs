using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Handlers
{
    public class ThaiCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override int HandleCharacter(List<string> resultWords, char[] characters, int index)
        {
            var resultWord = characters[index].ToString();
            var moreCharacters = resultWord;
            var isWordFound = false;

            for (int j = index + 1; j < characters.Length; j++)
            {
                moreCharacters += characters[j].ToString();
                var firstCharacter = moreCharacters[0];

                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                foreach (var word in Dictionary[firstCharacter])
                {
                    if (word != moreCharacters) { continue; }

                    resultWord = moreCharacters;
                    index = j;
                    isWordFound = true;
                    break;
                }

                if (ShortWordFirst)
                {
                    break;
                }
            }

            HandleResultWords(resultWords, resultWord, isWordFound);

            return index;
        }

        private void HandleResultWords(List<string> resultWords, string resultWord, bool isWordFound)
        {
            if (isWordFound)
            {
                resultWords.Add(resultWord);
            }
            else
            {
                var lastOutputIndex = resultWords.Count - 1;

                resultWords[lastOutputIndex] += resultWord;
            }
        }

        public override bool IsMatch(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);
    }
}