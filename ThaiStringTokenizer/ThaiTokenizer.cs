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
        public ThaiTokenizer(List<string> customWords = null, bool removeSpace = true, bool shortWordFirst = false)
        {
            RemoveSpace = removeSpace;
            ShortWordFirst = shortWordFirst;

            GenerateWords(customWords);
            GenerateDictionary();
        }

        public List<string> Split(string input)
        {
            var resultWords = new List<string>();
            var inputWords = RemoveSpace ? input.Split(' ') : new string[] { input };
            var handlers = GetCharacterHandlers();

            foreach (string inputWord in inputWords)
            {
                var inpuWordChars = inputWord.ToCharArray();
                var inputWordCharsLength = inpuWordChars.Length;

                for (int i = 0; i < inputWordCharsLength; i++)
                {
                    var character = inpuWordChars[i];

                    foreach (var handler in handlers)
                    {
                        if (!handler.IsMatch(character)) { continue; }

                        handler.Dictionary = Dictionary;
                        handler.RemoveSpace = RemoveSpace;
                        handler.ShortWordFirst = ShortWordFirst;
                        handler.Words = Words;

                        i = handler.HandleCharacter(resultWords, inpuWordChars, i);

                        break;
                    }
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

        public List<ThaiStringResponse> SubThaiStringAndCount(string input, int length = int.MaxValue)
        {
            var results = SubThaiString(input, length);
            var responses = new List<ThaiStringResponse>();

            foreach (var sentence in results)
            {
                var response = new ThaiStringResponse { Words = sentence };

                responses.Add(response);
            }

            return responses;
        }
    }
}