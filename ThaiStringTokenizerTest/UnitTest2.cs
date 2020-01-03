using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest2 : TestBase
    {
        [Fact]
        public void TestSplit_RemoveSpace()
        {
            var appendDics = new List<string> { "พุทธัง", "ธัมมัง", "สังฆัง", "อาราธนานัง" };
            var tokenizer = new ThaiTokenizer(appendDics);
            var input = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "พุทธัง",
                "อาราธนานัง",
                " ",
                "ธัมมัง",
                "อาราธนานัง",
                " ",
                "สังฆัง",
                "อาราธนานัง"
            };

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestSubThaiString_RemoveSpace()
        {
            var appendDics = new List<string> { "พุทธัง", "ธัมมัง", "สังฆัง", "อาราธนานัง" };
            var tokenizer = new ThaiTokenizer(appendDics);
            var input = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง"
            };

            Verify(tokenizer, input, expected, results);
        }
    }
}