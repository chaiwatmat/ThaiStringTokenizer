using System.Collections.Generic;
using System.Linq;

namespace ThaiStringTokenizer
{
    public class ConsonantCharacter
    {
        private List<int> consonants => new List<int>
        {
            0x0e01,
            0x0e02,
            0x0e03,
            0x0e04,
            0x0e05,
            0x0e06,
            0x0e07,
            0x0e08,
            0x0e09,
            0x0e0a,
            0x0e0b,
            0x0e0c,
            0x0e0d,
            0x0e0e,
            0x0e0f,
            0x0e10,
            0x0e11,
            0x0e12,
            0x0e13,
            0x0e14,
            0x0e15,
            0x0e16,
            0x0e17,
            0x0e18,
            0x0e19,
            0x0e1a,
            0x0e1b,
            0x0e1c,
            0x0e1d,
            0x0e1e,
            0x0e1f,
            0x0e20,
            0x0e21,
            0x0e22,
            0x0e23,
            0x0e24,
            0x0e25,
            0x0e26,
            0x0e27,
            0x0e28,
            0x0e29,
            0x0e2a,
            0x0e2b,
            0x0e2c,
            0x0e2d,
            0x0e2e,
            0x0e2f,

            0x0e30,
            0x0e32,
            0x0e33,
            0x0e3f,
            0x0e40,
            0x0e41,
            0x0e42,
            0x0e43,
            0x0e44,
            0x0e45,
            0x0e46,

            0x0e50,
            0x0e51,
            0x0e52,
            0x0e53,
            0x0e54,
            0x0e55,
            0x0e56,
            0x0e57,
            0x0e58,
            0x0e59,
            0x0e51,
            0x0e5b
        };
        public ConsonantCharacter(string word) => Word = word;
        public string Word { get; set; }
        public int ConsonantCount => Word.ToCharArray().ToList().Count(x => consonants.Contains(x));
    }
}