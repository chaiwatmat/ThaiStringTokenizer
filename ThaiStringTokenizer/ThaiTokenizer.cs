using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ThaiStringTokenizer.Handlers;
using ThaiStringTokenizer.Models;

namespace ThaiStringTokenizer
{
    public class ThaiTokenizer
    {
        public Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public bool RemoveSpace { get; set; }

        public bool ShortWordFirst { get; set; }

        public string[] Words { get; set; }

        public ThaiTokenizer(List<string> words = null, bool removeSpace = true, bool shortWordFirst = false)
        {
            RemoveSpace = removeSpace;
            ShortWordFirst = shortWordFirst;

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("ThaiStringTokenizer.dictionary.txt"));
            var stream = assembly.GetManifestResourceStream(resourceName);
            var textStreamReader = new StreamReader(stream);
            var textWords = textStreamReader.ReadToEnd();

            var originalWords = textWords.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            var listWords = new List<string>();

            if (words != null)
            {
                listWords.AddRange(words);
            }

            listWords.AddRange(originalWords);

            Words = listWords.ToArray();

            foreach (var word in Words)
            {
                if (!Dictionary.ContainsKey(word[0]))
                {
                    Dictionary.Add(word[0], new List<string>());
                }
                Dictionary[word[0]].Add(word);
            }
        }

        private List<ICharacterHandler> GetCharacterHandlers()
        {
            return new List<ICharacterHandler>
            {
                new EnglishCharacterHandler(),
                new NumberCharacterHandler(),
                new ThaiCharacterHandler(),
                new UnknownCharacterHandler()
            };
        }

        public List<string> Split(string input)
        {
            var outputList = new List<string>();
            var words = RemoveSpace ? input.Split(' ') : new string[] { input };
            var handlers = GetCharacterHandlers();

            foreach (string word in words)
            {
                var characters = word.ToCharArray();
                var charactersLength = characters.Length;

                for (int i = 0; i < charactersLength; i++)
                {
                    var character = characters[i];

                    foreach (var handler in handlers)
                    {
                        if (!handler.IsMatch(character)) { continue; }

                        handler.Dictionary = Dictionary;
                        handler.RemoveSpace = RemoveSpace;
                        handler.ShortWordFirst = ShortWordFirst;
                        handler.Words = Words;

                        i = handler.HandleCharacter(outputList, characters, i);

                        break;
                    }
                }
            }

            return outputList;
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