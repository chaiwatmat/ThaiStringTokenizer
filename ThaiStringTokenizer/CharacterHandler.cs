using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public abstract class CharacterHandler
    {
        public Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public bool RemoveSpace { get; set; }

        public bool ShortWordFirst { get; set; }

        public string[] Words { get; set; }

        public bool IsEnglishCharacter(char charNumber) => BasicLatinCharacter.Alphabets.Contains(charNumber);

        public bool IsNumberCharacter(char charNumber) => BasicLatinCharacter.Digits.Contains(charNumber);

        public bool IsThaiCharacter(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);

        public void HandleConsonantOrVowel(List<string> outputList, char[] characters, ref string tmpString, ref int i)
        {
            tmpString += characters[i].ToString();

            bool isFound = false;
            string moretmp = tmpString;

            for (int j = i + 1; j < characters.Length; j++)
            {
                moretmp += characters[j].ToString();
                var firstCharacter = moretmp[0];

                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                foreach (var word in Dictionary[firstCharacter])
                {
                    if (word == moretmp)
                    {
                        tmpString = moretmp;
                        i = j;
                        isFound = true;
                        break;
                    }
                }

                if (ShortWordFirst)
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

        public void HandleEnglishCharacter(List<string> outputList, char[] characters, ref string tmpString, ref int i)
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

        public void HandleNumberCharacter(List<string> outputList, char[] characters, ref string tmpString, ref int i)
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
    }
}