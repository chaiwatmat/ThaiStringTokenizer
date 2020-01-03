using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class LongWordTest : TestBase
    {
        [Fact]
        public void LongWordTest1()
        {
            var tokenizer = new ThaiTokenizer(shortWordFirst: false);
            var input = "บางครั้ง";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "บางครั้ง"
            };

            Verify(tokenizer, input, expected);
        }
    }
}