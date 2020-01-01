using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ShortWordTest : TestBase
    {
        [Fact]
        public void ShortWordTest1()
        {
            var tokenizer = new ThaiTokenizer(noSpace: false, shortWordFirst: true);
            var input = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "พุทธัง",
                "อา",
                "รา",
                "ธนา",
                "นัง",
                " ",
                "ธัม",
                "มัง",
                "อา",
                "รา",
                "ธนา",
                "นัง",
                " ",
                "สัง",
                "ฆัง",
                "อา",
                "รา",
                "ธนา",
                "นัง",
            };

            Verify(tokenizer, input, expected);
        }

        [Fact]
        public void ShortWordTest2()
        {
            var tokenizer = new ThaiTokenizer(noSpace: false, shortWordFirst: true);
            var input = "ตากลม";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "ตา",
                "กลม"
            };

            Verify(tokenizer, input, expected);
        }

        [Fact]
        public void ShortWordTest3()
        {
            var tokenizer = new ThaiTokenizer(noSpace: false, shortWordFirst: true);
            var input = "กวาง";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "กวาง"
            };

            Verify(tokenizer, input, expected);
        }
    }
}