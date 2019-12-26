using System.Collections.Generic;

namespace ThaiStringTokenizer
{
    public abstract class CharacterHandlerBase
    {
        public virtual Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public virtual bool RemoveSpace { get; set; }

        public virtual bool ShortWordFirst { get; set; }

        public virtual string[] Words { get; set; }
    }
}