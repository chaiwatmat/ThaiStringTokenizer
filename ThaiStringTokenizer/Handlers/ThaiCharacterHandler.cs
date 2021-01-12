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
            var firstCharacter = moreCharacters[0];
            var isWordFound = false;

            var previousWordHandled = HandlePreviousWord(resultWords);
            if (previousWordHandled)
            {
                HandleResultWords(resultWords, resultWord, isWordFound);

                return index;
            }

            for (int j = index + 1; j < characters.Length; j++)
            {
                var character = characters[j];
                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                moreCharacters += character.ToString();

                var dicWords = Dictionary[firstCharacter];
                var isMatchedWord = dicWords.Any(word => word == moreCharacters);
                if (isMatchedWord)
                {
                    isWordFound = true;
                    index = j;
                    resultWord = moreCharacters;
                }

                if (MatchingMode == MatchingMode.Shortest && isWordFound) { break; }
            }

            HandleResultWords(resultWords, resultWord, isWordFound);

            return index;
        }

        private bool HandlePreviousWord(List<string> resultWords)
        {
            var handled = false;
            var lastResultIndex = resultWords.Count - 1;
            if (lastResultIndex < 0) { return handled; }

            var previousWord = resultWords[lastResultIndex];
            var wordLength = previousWord.Length;
            var lastCharacter = Convert.ToChar(previousWord[wordLength - 1]);

            handled = IsRequiredSpelling(lastCharacter);

            return handled;
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
                var previousWord = resultWords.Count == 0 ? resultWord : resultWords[lastResultIndex];

                if (string.IsNullOrWhiteSpace(previousWord) || resultWords.Count == 0)
                {
                    resultWords.Add(resultWord);
                }
                else
                {
                    resultWords[lastResultIndex] += resultWord;
                }
            }
        }

        private bool IsRequiredSpelling(char character) => ThaiUnicodeCharacter.PostpendVowelsRequiredSpelling.Contains(character);

        public override bool IsMatch(char character) => ThaiUnicodeCharacter.Characters.Contains(character);
    }
}