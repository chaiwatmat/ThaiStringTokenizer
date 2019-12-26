using System.Collections.Generic;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer
{
    public abstract class CharacterHandlerBase
    {
        public virtual Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public virtual bool RemoveSpace { get; set; }

        public virtual bool ShortWordFirst { get; set; }

        public virtual string[] Words { get; set; }
    }

    public interface ICharacterHandler
    {
        Dictionary<char, List<string>> Dictionary { get; set; }

        bool RemoveSpace { get; set; }

        bool ShortWordFirst { get; set; }

        string[] Words { get; set; }
        bool IsMatch(char character);
        int HandleCharacter(List<string> outputList, char[] characters, int index);
    }

    public class EnglishCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            var tmpString = characters[index].ToString();
            for (int j = index + 1; j < characters.Length; j++)
            {
                if (IsMatch(characters[j]))
                {
                    tmpString += characters[j];
                    index = j;
                }
                else
                {
                    break;
                }
            }
            outputList.Add(tmpString);

            return index;
        }

        public bool IsMatch(char charNumber) => BasicLatinCharacter.Alphabets.Contains(charNumber);
    }

    public class NumberCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            var tmpString = characters[index].ToString();
            for (int j = index + 1; j < characters.Length; j++)
            {
                if (IsMatch(characters[j]))
                {
                    tmpString += characters[j];
                    index = j;
                }
                else
                {
                    break;
                }
            }
            outputList.Add(tmpString);

            return index;
        }

        public bool IsMatch(char charNumber) => BasicLatinCharacter.Digits.Contains(charNumber);
    }

    public class ThaiCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            var tmpString = characters[index].ToString();

            bool isFound = false;
            string moretmp = tmpString;

            for (int j = index + 1; j < characters.Length; j++)
            {
                moretmp += characters[j].ToString();
                var firstCharacter = moretmp[0];

                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                foreach (var word in Dictionary[firstCharacter])
                {
                    if (word == moretmp)
                    {
                        tmpString = moretmp;
                        index = j;
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

            return index;
        }

        public bool IsMatch(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);
    }

    public class UnknownCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        private char _character;
        public int HandleCharacter(List<string> outputList, char[] characters, int index)
        {
            outputList.Add(_character.ToString());

            return index;
        }

        public bool IsMatch(char character)
        {
            _character = character;

            return true;
        }
    }
}