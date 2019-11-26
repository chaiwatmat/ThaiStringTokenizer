using System.Collections.Generic;
using System.Linq;

namespace ThaiStringTokenizer
{
    internal class ConsonantCharacter
    {
        public ConsonantCharacter(string word) => Word = word;
        public string Word { get; set; }
        public int ConsonantCount => Word.ToCharArray().ToList().Count(x => !ThaiUnicodeCharacter.UncountForPrint.Contains(x));
    }
}