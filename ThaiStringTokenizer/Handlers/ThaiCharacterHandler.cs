using System;
using System.Collections.Generic;
using System.Linq;
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
            var firstCharacter = moreCharacters[0];

            for (int j = index + 1; j < characters.Length; j++)
            {
                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                moreCharacters += characters[j].ToString();
                var dicWords = Dictionary[firstCharacter];

                foreach (var word in dicWords)
                {
                    if (word != moreCharacters) { continue; }

                    resultWord = moreCharacters;
                    index = j;
                    isWordFound = true;
                    break;
                }

                if (ShortWordFirst) { break; }
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
                var lastResultIndex = resultWords.Count - 1;

                resultWords[lastResultIndex] += resultWord;
            }
        }

        public override bool IsMatch(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);
    }
}