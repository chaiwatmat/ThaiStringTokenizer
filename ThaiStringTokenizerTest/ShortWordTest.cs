using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ShortWordTest
    {
        // [Fact]
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
                "ธัมมัง",
                "อา",
                "รา",
                "ธนา",
                "นัง",
                " ",
                "สังฆัง",
                "อา",
                "รา",
                "ธนา",
                "นัง",
            };

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}