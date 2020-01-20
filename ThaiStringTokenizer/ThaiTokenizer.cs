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

            return resultWords;
        }

        public List<string> SubThaiString(string input, int length)
        {
            var lines = new List<string>();
            var line = "";
            var lineCount = 0;
            var words = Split(input);
            var maxIndex = words.Count - 1;

            for (var i = 0; i <= maxIndex; i++)
            {
                var word = words[i];

                var consonant = new ThaiStringResponse { Words = word };
                lineCount += consonant.Countable;

                if (lineCount < length)
                {
                    line += word;

                    if (i == maxIndex)
                    {
                        lines.Add(line);
                    }
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

                    if (i == maxIndex)
                    {
                        lines.Add(line);
                    }
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