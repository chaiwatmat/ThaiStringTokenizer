using System.Collections.Generic;

namespace ThaiStringTokenizer.Handlers
{
    public abstract class CharacterHandlerBase
    {
        public virtual Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public virtual MatchingMode MatchingMode { get; set; }

        public virtual int HandleCharacter(List<string> resultWords, char[] characters, int index)
        {
            var resultWord = characters[index].ToString();

            for (int j = index + 1; j < characters.Length; j++)
            {
                if (IsMatch(characters[j]))
                {
                    resultWord += characters[j];
                    index = j;
                }
                else
                {
                    break;
                }
            }

            resultWords.Add(resultWord);

            return index;
        }

        public virtual bool IsMatch(char character) => true;
    }
}