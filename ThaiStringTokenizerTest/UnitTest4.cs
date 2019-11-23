using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest4
    {
        [Fact]
        public void TestToneMarkSubstring()
        {
            var input = "สิ่งที่อยากจะมีมากที่สุดในชีวิตคือความรวย";

            var tokenizer = new ThaiTokenizer();

            var results = tokenizer.Split(input);
            results.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        [Fact]
        public void TestGetAllThaiUnicodeCharacters()
        {
            var characters = ThaiUnicodeCharacter.Characters;

            Assert.True(characters.Count > 44);
            foreach (var character in characters)
            {
                Console.WriteLine("{0}", character);
            }
        }
    }
}