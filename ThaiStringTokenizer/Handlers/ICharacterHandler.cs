using System.Collections.Generic;

namespace ThaiStringTokenizer.Handlers
{
    public interface ICharacterHandler
    {
        Dictionary<char, List<string>> Dictionary { get; set; }

        bool RemoveSpace { get; set; }

        bool ShortWordFirst { get; set; }

        string[] Words { get; set; }
        bool IsMatch(char character);
        int HandleCharacter(List<string> resultWords, char[] characters, int index);
    }
}