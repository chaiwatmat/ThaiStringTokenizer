using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnicodeCharacterTest
    {
        [Fact]
        public void CountThaiUnicodeCharactersTest()
        {
            var characters = ThaiUnicodeCharacter.Characters;
            var expectedCharacters = 87;

            Assert.Equal(expectedCharacters, characters.Count);
        }

        [Fact]
        public void CountBasicLatinCharactersTest()
        {
            var characters = BasicLatinCharacter.Characters;
            var expectedCharactersExcludeSpace = 94;

            Assert.Equal(expectedCharactersExcludeSpace, characters.Count);
        }
    }
}