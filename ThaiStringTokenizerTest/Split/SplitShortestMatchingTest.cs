using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SplitShortestMatchingTest : TestBase
    {
        [Fact]
        public void ShortWordTest1()
        {
            var input = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var expected = new List<string>
            {
                "พุทธัง", "อา", "รา", "ธนา","นัง",
                " ",
                "ธัม", "มัง", "อา", "รา", "ธนา", "นัง",
                " ",
                "สัง", "ฆัง", "อา", "รา", "ธนา", "นัง",
            };

            Verify(input, expected, MatchingMode.Shortest);
        }

        [Theory]
        [InlineData("ตากลม", "ตา", "กลม")]
        [InlineData("กวาง", "กวาง")]
        [InlineData("บางครั้ง", "บาง", "ครั้ง")]
        [InlineData("ยังอ่ะ", "ยัง", "อ่ะ")]
        public void ShortWordTest2(string input, params string[] expected)
        {
            var expectedList = expected.ToList();

            Verify(input, expectedList, MatchingMode.Shortest);
        }
    }
}