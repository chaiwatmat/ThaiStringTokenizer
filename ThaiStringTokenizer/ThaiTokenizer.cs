using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ThaiStringTokenizer
{
    public class ThaiTokenizer
    {
        private Dictionary<char, List<string>> _dictionary = new Dictionary<char, List<string>>();

        public ThaiTokenizer(string[] words = null)
        {
            var text = File.ReadAllText("dictionary.txt");
            var originalWords = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            var listWords = new List<string>();
            listWords.AddRange(originalWords);

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
            var inputSplitSpace = input.Split(' ');
            var outputList = new List<string>();

            foreach (string item in inputSplitSpace)
            {
                var inputChar = item.ToCharArray();
                var tmpString = "";
                for (int i = 0; i < inputChar.Length; i++)
                {
                    if (IsEnglishChar(inputChar[i]))
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
                    else if (IsVowelNeedConsonant(inputChar[i]))
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
                    else if (IsToken(inputChar[i]))
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
                    else if (IsConsonant(inputChar[i]) || isVowel(inputChar[i]))
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
                    else
                    {
                        outputList.Add(inputChar[i].ToString());
                    }
                }
            }

            return outputList;
        }

        private bool IsConsonant(char charNumber) => charNumber >= 3585 && charNumber <= 3630;
        private bool isVowel(char charNumber) => charNumber >= 3632 && charNumber <= 3653;
        private bool IsVowelNeedConsonant(char charNumber) => (charNumber >= 3632 && charNumber <= 3641) || charNumber == 3653;
        private bool IsToken(char charNumber) => charNumber >= 3656 && charNumber <= 3659;
        private bool IsEnglishChar(char charNumber) => (charNumber >= 65 && charNumber <= 90) || (charNumber >= 97 && charNumber <= 122);
    }
}
