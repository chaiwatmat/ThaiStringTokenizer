using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest4 : TestBase
    {
        [Fact]
        public void TestToneMarkSubstring()
        {
            var input = "ผมอยากจะเป็นมหาเศรษฐี";
            var expected = new List<string>
            {
                "ผม",
                "อยาก",
                "จะ",
                "เป็น",
                "มหาเศรษฐี"
            };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.Split(input);

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestGetAllThaiUnicodeCharacters()
        {
            var characters = ThaiUnicodeCharacter.Characters;

            Assert.True(characters.Count == 87);
        }
    }
}