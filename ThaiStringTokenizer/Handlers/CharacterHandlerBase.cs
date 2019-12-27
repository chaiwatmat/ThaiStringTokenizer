using System.Collections.Generic;

namespace ThaiStringTokenizer.Handlers
{
    public abstract class CharacterHandlerBase
    {
        public virtual Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public virtual bool RemoveSpace { get; set; }

        public virtual bool ShortWordFirst { get; set; }

        public virtual string[] Words { get; set; }

        public virtual int HandleCharacter(List<string> resultWords, char[] characters, int index)
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
            resultWords.Add(tmpString);

            return index;
        }

        public virtual bool IsMatch(char charNumber) => false;
    }
}