using System.Collections.Generic;

namespace ThaiStringTokenizer
{
    public class TokenizerOptions
    {
        public List<string> CustomWords { get; set; }
        public MatchingMode MatchingMode { get; set; } = MatchingMode.Longest;
    }
}