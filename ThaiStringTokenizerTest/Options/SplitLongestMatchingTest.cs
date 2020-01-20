using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class TokenizerOptionsTest : TestBase
    {
        [Fact]
        public void Test1()
        {
            var input = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var expected = GlobalExpectedResult.GetExpectedResult1();

            var options = new TokenizerOptions { MatchingMode = MatchingMode.Longest };
            var tokenizer = new ThaiTokenizer(options);

            Verify(tokenizer, input, expected);
        }
    }
}