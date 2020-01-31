using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ThaiStringTokenizer.Models;

namespace ThaiStringTokenizer
{
    public class ThaiTokenizer : TokenizerBase
    {
        public ThaiTokenizer(List<string> customWords = null, MatchingMode matchingMode = MatchingMode.Longest)
        {
            MatchingMode = matchingMode;

            InitialDictionary(customWords);
        }

        public ThaiTokenizer(TokenizerOptions tokenizerOptions)
        {
            MatchingMode = tokenizerOptions.MatchingMode;
            PreferDecodableWord = tokenizerOptions.PreferDecodableWord;

            InitialDictionary(tokenizerOptions.CustomWords);
        }

        public List<string> Split(string input)
        {
            var resultWords = new List<string>();
            var handlers = GetCharacterHandlers();

            var inputWordChars = input.ToCharArray();
            var charsLength = inputWordChars.Length;

            for (int i = 0; i < charsLength; i++)
            {
                var character = inputWordChars[i];

                foreach (var handler in handlers)
                {
                    if (!handler.IsMatch(character)) { continue; }

                    handler.Dictionary = Dictionary;
                    handler.MatchingMode = MatchingMode;

                    i = handler.HandleCharacter(resultWords, inputWordChars, i);

                    break;
                }
            }

            return AnalyzeWords(resultWords);
        }

        private List<string> AnalyzeWords(List<string> resultWords)
        {
            if (!PreferDecodableWord) { return resultWords; }

            var finalResults = new List<string>();
            var resultLength = resultWords.Count;

            for (int i = 0; i < resultLength; i++)
            {
                var word = resultWords[i];
                var isWordFound = Words.Contains(word);
                var isSpace = string.IsNullOrWhiteSpace(word);

                if (isWordFound || isSpace)
                {
                    finalResults.Add(word);
                    continue;
                }

                var lastFinalResultIndex = finalResults.Count - 1;
                if (lastFinalResultIndex < 0)
                {
                    finalResults.Add(word);
                    continue;
                }

                var previousWord = finalResults[lastFinalResultIndex];
                var mergeWord = $"{previousWord}{word}";
                var isMergeWordFound = Words.Contains(mergeWord);

                if (isMergeWordFound)
                {
                    finalResults[lastFinalResultIndex] += word;
                    continue;
                }

                finalResults.Add(word);
            }

            return finalResults;
        }

        public List<string> SubThaiString(string input, int length)
        {
            var lines = new List<string>();
            var line = "";
            var lineCount = 0;
            var words = Split(input);
            var lastIndex = words.Count - 1;

            for (var i = 0; i <= lastIndex; i++)
            {
                var word = words[i];

                var consonant = new ThaiStringResponse { Words = word };
                lineCount += consonant.Countable;

                if (lineCount < length)
                {
                    line += word;

                    if (i != lastIndex) { continue; }

                    lines.Add(line);
                }
                else if (lineCount == length)
                {
                    line += word;
                    lines.Add(line);
                    lineCount = 0;
                    line = "";
                }
                else
                {
                    lines.Add(line);
                    lineCount = consonant.Countable;
                    line = word;

                    if (i != lastIndex) { continue; }

                    lines.Add(line);
                }
            }

            return lines;
        }

        public IEnumerable<ThaiStringResponse> SubThaiStringAndCount(string input, int length = int.MaxValue)
        {
            var results = SubThaiString(input, length);
            var responses = new List<ThaiStringResponse>();

            foreach (string sentence in results)
            {
                yield return new ThaiStringResponse { Words = sentence };
            }
        }
    }
}