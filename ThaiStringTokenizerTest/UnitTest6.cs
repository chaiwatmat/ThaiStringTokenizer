using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest6
    {
        [Fact]
        public void TestCountBasicLatinCharacters()
        {
            var characters = BasicLatinCharacter.Characters;
            var expectedCharactersExcludeSpace = 94;

            Assert.Equal(expectedCharactersExcludeSpace, characters.Count);
        }
    }
}