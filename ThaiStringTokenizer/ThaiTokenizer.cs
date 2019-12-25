using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ThaiStringTokenizer.Models;

namespace ThaiStringTokenizer
{
    public class ThaiTokenizer : CharacterHandler
    {
        private Dictionary<char, List<string>> _dictionary = new Dictionary<char, List<string>>();
        private bool _removeSpace;
        private bool _shortWordFirst;

        public ThaiTokenizer(List<string> words = null, bool removeSpace = true, bool shortWordFirst = false)
        {
            _removeSpace = removeSpace;
            _shortWordFirst = shortWordFirst;

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
                if (!_dictionary.ContainsKey(word[0]))
                {
                    _dictionary.Add(word[0], new List<string>());
                }
                _dictionary[word[0]].Add(word);
            }
        }

        public string[] Words { get; private set; }
        public List<string> Split(string input)
        {
            var outputList = new List<string>();
            var words = _removeSpace ? input.Split(' ') : new string[] { input };

            foreach (string word in words)
            {
                var characters = word.ToCharArray();
                var tmpString = "";

                for (int i = 0; i < characters.Length; i++)
                {
                    var character = characters[i];

                    if (IsEnglishCharacter(character))
                    {
                        HandleEnglishCharacter(outputList, characters, ref tmpString, ref i);
                    }
                    else if (IsNumberCharacter(character))
                    {
                        HandleNumberCharacter(outputList, characters, ref tmpString, ref i);
                    }
                    else if (IsThaiCharacter(character))
                    {
                        HandleConsonantOrVowel(outputList, characters, ref tmpString, ref i);
                    }
                    else
                    {
                        outputList.Add(character.ToString());
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

        private void HandleEnglishCharacter(List<string> outputList, char[] characters, ref string tmpString, ref int i)
        {
            tmpString += characters[i].ToString();
            for (int j = i + 1; j < characters.Length; j++)
            {
                if (IsEnglishCharacter(characters[j]))
                {
                    tmpString += characters[j];
                    i = j;
                }
                else
                {
                    break;
                }
            }
            outputList.Add(tmpString);
            tmpString = "";
        }

        private void HandleNumberCharacter(List<string> outputList, char[] characters, ref string tmpString, ref int i)
        {
            tmpString += characters[i].ToString();
            for (int j = i + 1; j < characters.Length; j++)
            {
                if (IsNumberCharacter(characters[j]))
                {
                    tmpString += characters[j];
                    i = j;
                }
                else
                {
                    break;
                }
            }
            outputList.Add(tmpString);
            tmpString = "";
        }

        private void HandleConsonantOrVowel(List<string> outputList, char[] characters, ref string tmpString, ref int i)
        {
            tmpString += characters[i].ToString();

            bool isFound = false;
            string moretmp = tmpString;

            for (int j = i + 1; j < characters.Length; j++)
            {
                moretmp += characters[j].ToString();
                var firstCharacter = moretmp[0];

                if (!_dictionary.ContainsKey(firstCharacter)) { continue; }

                foreach (var word in _dictionary[firstCharacter])
                {
                    if (word == moretmp)
                    {
                        tmpString = moretmp;
                        i = j;
                        isFound = true;
                        break;
                    }
                }

                if (_shortWordFirst)
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
            tmpString = "";
        }
    }
}