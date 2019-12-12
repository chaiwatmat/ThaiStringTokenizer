using System.Linq;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Models
{
    public class ThaiStringResponse
    {
        public string Words { get; set; }
        public int Countable => Words.ToCharArray().ToList().Count(x => !ThaiUnicodeCharacter.UncountForPrint.Contains(x));
        public int Uncountable => Words.ToCharArray().ToList().Count(x => ThaiUnicodeCharacter.UncountForPrint.Contains(x));
    }
}