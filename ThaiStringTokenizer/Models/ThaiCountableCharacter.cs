using System.Collections.Generic;
using System.Linq;

namespace ThaiStringTokenizer
{
    internal class ThaiCharacterCounter
    {
        public ThaiCharacterCounter(string word) => Word = word;
        public string Word { get; set; }
        public int Countable => Word.ToCharArray().ToList().Count(x => !ThaiUnicodeCharacter.UncountForPrint.Contains(x));
    }
}