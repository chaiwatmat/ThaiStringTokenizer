using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ThaiStringTokenizer
{
    public class ThaiTokenizer
    {
        private Dictionary<char, List<string>> _dictionary = new Dictionary<char, List<string>>();

        public ThaiTokenizer(List<string> words = null)
        {
            var originalWords = ThaiWord.Words.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

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

    public class ConsonantCharacter
    {
        private List<int> consonants => new List<int>
        {
            0x0e01,
            0x0e02,
            0x0e03,
            0x0e04,
            0x0e05,
            0x0e06,
            0x0e07,
            0x0e08,
            0x0e09,
            0x0e0a,
            0x0e0b,
            0x0e0c,
            0x0e0d,
            0x0e0e,
            0x0e0f,
            0x0e10,
            0x0e11,
            0x0e12,
            0x0e13,
            0x0e14,
            0x0e15,
            0x0e16,
            0x0e17,
            0x0e18,
            0x0e19,
            0x0e1a,
            0x0e1b,
            0x0e1c,
            0x0e1d,
            0x0e1e,
            0x0e1f,
            0x0e20,
            0x0e21,
            0x0e22,
            0x0e23,
            0x0e24,
            0x0e25,
            0x0e26,
            0x0e27,
            0x0e28,
            0x0e29,
            0x0e2a,
            0x0e2b,
            0x0e2c,
            0x0e2d,
            0x0e2e,
            0x0e2f,

            0x0e30,
            0x0e32,
            0x0e33,
            0x0e3f,
            0x0e40,
            0x0e41,
            0x0e42,
            0x0e43,
            0x0e44,
            0x0e45,
            0x0e46,

            0x0e50,
            0x0e51,
            0x0e52,
            0x0e53,
            0x0e54,
            0x0e55,
            0x0e56,
            0x0e57,
            0x0e58,
            0x0e59,
            0x0e51,
            0x0e5b
        };
        public ConsonantCharacter(string word) => Word = word;
        public string Word { get; set; }
        public int ConsonantCount => Word.ToCharArray().ToList().Count(x => consonants.Contains(x));
    }
}