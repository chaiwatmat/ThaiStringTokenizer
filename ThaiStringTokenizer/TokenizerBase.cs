using System.Collections.Generic;
using ThaiStringTokenizer.Handlers;

namespace ThaiStringTokenizer
{
    public abstract class TokenizerBase
    {
        public Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public bool RemoveSpace { get; set; }

        public bool ShortWordFirst { get; set; }

        public string[] Words { get; set; }
        public List<ICharacterHandler> GetCharacterHandlers()
        {
            return new List<ICharacterHandler>
            {
                new EnglishCharacterHandler(),
                new NumberCharacterHandler(),
                new ThaiCharacterHandler(),
                new UnknownCharacterHandler()
            };
        }
    }
}