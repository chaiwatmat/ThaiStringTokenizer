﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ThaiStringTokenizer
{
    public class ThaiTokenizer
    {
        private Dictionary<char, List<string>> _dictionary = new Dictionary<char, List<string>>();
        private bool _removeSpace;

        public ThaiTokenizer(List<string> words = null, bool removeSpace = true)
        {
            var originalWords = ThaiWord.Words.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            var listWords = new List<string>();
            listWords.AddRange(originalWords);

            _removeSpace = removeSpace;

            if (words != null)
            {
                listWords.AddRange(words);
            }

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
            var inputSplitSpace = _removeSpace ? input.Split(' ') : new string[] { input };
            var outputList = new List<string>();

            foreach (string item in inputSplitSpace)
            {
                var inputChar = item.ToCharArray();
                var tmpString = "";

                for (int i = 0; i < inputChar.Length; i++)
                {
                    if (IsEnglishChar(inputChar[i]))
                    {
                        HandleEnglishCharacter(outputList, inputChar, ref tmpString, ref i);
                    }
                    else if (IsVowelNeedConsonant(inputChar[i]))
                    {
                        HandleVowelRequireConsonant(outputList, inputChar, ref tmpString, ref i);
                    }
                    else if (IsToken(inputChar[i]))
                    {
                        HandleToken(outputList, inputChar, ref tmpString, ref i);
                    }
                    else if (IsConsonant(inputChar[i]) || isVowel(inputChar[i]))
                    {
                        HandleConsonantOrVowel(outputList, inputChar, ref tmpString, ref i);
                    }
                    else
                    {
                        outputList.Add(inputChar[i].ToString());
                    }
                }
            }
            return outputList;
        }

        private void HandleEnglishCharacter(List<string> outputList, char[] inputChar, ref string tmpString, ref int i)
        {
            tmpString += inputChar[i].ToString();
            for (int j = i + 1; j < inputChar.Length; j++)
            {
                if (IsEnglishChar(inputChar[j]))
                {
                    tmpString += inputChar[j];
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

        private void HandleVowelRequireConsonant(List<string> outputList, char[] inputChar, ref string tmpString, ref int i)
        {
            tmpString += inputChar[i].ToString();
            for (int j = i + 1; j < inputChar.Length; j++)
            {
                if (IsVowelNeedConsonant(inputChar[j]))
                {
                    tmpString += inputChar[j];
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

        private void HandleToken(List<string> outputList, char[] inputChar, ref string tmpString, ref int i)
        {
            tmpString += inputChar[i].ToString();
            for (int j = i + 1; j < inputChar.Length; j++)
            {
                if (IsToken(inputChar[j]))
                {
                    tmpString += inputChar[j];
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

        private void HandleConsonantOrVowel(List<string> outputList, char[] inputChar, ref string tmpString, ref int i)
        {
            tmpString += inputChar[i].ToString();
            string moretmp = tmpString;
            bool isFound = false;
            for (int j = i + 1; j < inputChar.Length; j++)
            {
                moretmp += inputChar[j].ToString();
                if (_dictionary.ContainsKey(moretmp[0]))
                {
                    foreach (var word in _dictionary[moretmp[0]])
                    {
                        if (word == moretmp)
                        {
                            tmpString = moretmp;
                            i = j;
                            isFound = true;
                            break;
                        }
                    }
                }
            }
            if (isFound)
            {
                outputList.Add(tmpString);
            }
            tmpString = "";
        }

        public List<string> SubThaiString(string input, int length)
        {
            var lines = new List<string>();
            var line = "";
            var lineCount = 0;
            var consonants = new List<ConsonantCharacter>();
            var words = Split(input);
            var maxIndex = words.Count - 1;

            for (var i = 0; i <= maxIndex; i++)
            {
                var word = words[i];

                var consonant = new ConsonantCharacter(word);
                lineCount += consonant.ConsonantCount;

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
                    lineCount = consonant.ConsonantCount;
                    line = word;

                    if (i == maxIndex)
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines;
        }

        private bool IsConsonant(char charNumber) => charNumber >= 3585 && charNumber <= 3630;
        private bool isVowel(char charNumber) => charNumber >= 3632 && charNumber <= 3653;
        private bool IsVowelNeedConsonant(char charNumber) => (charNumber >= 3632 && charNumber <= 3641) || charNumber == 3653;
        private bool IsToken(char charNumber) => charNumber >= 3656 && charNumber <= 3659; // ่ ้ ๊ ๋
        private bool IsEnglishChar(char charNumber) => (charNumber >= 65 && charNumber <= 90) || (charNumber >= 97 && charNumber <= 122);
    }
}