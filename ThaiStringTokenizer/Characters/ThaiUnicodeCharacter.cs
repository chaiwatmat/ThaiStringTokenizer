using System.Collections.Generic;

namespace ThaiStringTokenizer.Characters
{
    public static class ThaiUnicodeCharacter
    {
        public static List<int> Characters
        {
            get
            {
                var characters = Consonants;
                characters.AddRange(Vowels);
                characters.AddRange(Sign);
                characters.AddRange(CurrencySymbol);
                characters.AddRange(VowelLengthSign);
                characters.AddRange(RepetitionMark);
                characters.AddRange(ToneMarks);
                characters.AddRange(Signs);
                characters.AddRange(Digits);

                return characters;
            }
        }

        public static List<int> UncountForPrint
        {
            get
            {
                var uncountVowels = new List<int>
                {
                    0x0e31,
                    0x0e34,
                    0x0e35,
                    0x0e36,
                    0x0e37,
                    0x0e38,
                    0x0e39,
                    0x0e3a,
                    0x0e47,
                    0x0e4c,
                    0x0e4d,
                    0x0e4e
                };

                uncountVowels.AddRange(ToneMarks);

                return uncountVowels;
            }
        }

        /// ก - ฮ
        public static List<int> Consonants => new List<int>
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
            0x0e2e
        };

        public static List<int> Vowels
        {
            get
            {
                var vowels = new List<int>();
                vowels.AddRange(PrependVowels);
                vowels.AddRange(PostpendVowels);

                return vowels;
            }
        }

        public static List<int> PostpendVowels
        {
            get
            {
                var vowels = new List<int>();
                vowels.AddRange(PostpendVowelsUnrequiredSpelling);
                vowels.AddRange(PostpendVowelsRequiredSpelling);

                return vowels;
            }
        }

        public static List<int> PostpendVowelsUnrequiredSpelling => new List<int>
        {
            0x0e30, //  ะ
            0x0e32, //  า
            0x0e33, //  ำ
            0x0e34, //  ิ
            0x0e35, //  ี
            0x0e36, //  ึ
            0x0e38, //  ุ
            0x0e39, //  ู
            0x0e3a, //  ฺ   =>  ธมฺมํ
            0x0e4c, //  ์
            0x0e4d, //  ํ   =>  ธมฺมํ
            0x0e47 //   ็
        };

        public static List<int> PostpendVowelsRequiredSpelling => new List<int>
        {
            0x0e31, //  ั
            0x0e37, //  ื
        };

        public static List<int> PrependVowels => new List<int>
        {
            0x0e40, //  เ
            0x0e41, //  แ
            0x0e42, //  โ
            0x0e43, //  ใ
            0x0e44, //  ไ
        };
        public static List<int> Sign => new List<int> { 0x0e2f }; //ฯ
        public static List<int> CurrencySymbol => new List<int> { 0x0e3f }; //฿
        public static List<int> VowelLengthSign => new List<int> { 0x0e45 }; //ฤา (สระ า หางยาว)
        public static List<int> RepetitionMark => new List<int> { 0x0e46 }; //ๆ

        public static List<int> ToneMarks => new List<int>
        {
            0x0e48, //  ่
            0x0e49, //  ้
            0x0e4a, //  ๊
            0x0e4b  //  ๋
        };

        public static List<int> Signs => new List<int>
        {
            0x0e4e, //      => not use
            0x0e4f, //      => not use
            0x0e5a, //      => not use
            0x0e5b //       => not use
        };
        // ๐๑๒๓๔๕๖๗๘๙
        public static List<int> Digits => new List<int>
        {
            0x0e50,
            0x0e51,
            0x0e52,
            0x0e53,
            0x0e54,
            0x0e55,
            0x0e56,
            0x0e57,
            0x0e58,
            0x0e59
        };
    }
}