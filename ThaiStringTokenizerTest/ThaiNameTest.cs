using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ThaiNameTest
    {
        [Fact]
        public void SampleTest1()
        {
            var input = "โชติกานต์";
            var expected = new List<string> { "โชติกานต์" };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}