using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest2
    {
        [Fact]
        public void TestSplit_RemoveSpace()
        {
            var appendDics = new List<string> { "พุทธัง", "ธัมมัง", "สังฆัง", "อาราธนานัง" };
            ThaiTokenizer tokenizer = new ThaiTokenizer(appendDics);
            string text = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var result = tokenizer.Split(text);

            var expected = new List<string>
            {
                "พุทธัง",
                "อาราธนานัง",
                "ธัมมัง",
                "อาราธนานัง",
                "สังฆัง",
                "อาราธนานัง"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSubThaiString_RemoveSpace()
        {
            var appendDics = new List<string> { "พุทธัง", "ธัมมัง", "สังฆัง", "อาราธนานัง" };
            ThaiTokenizer tokenizer = new ThaiTokenizer(appendDics);
            string text = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var result = tokenizer.SubThaiString(text, 50);

            var expected = new List<string>
            {
                "พุทธังอาราธนานังธัมมังอาราธนานังสังฆังอาราธนานัง"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}