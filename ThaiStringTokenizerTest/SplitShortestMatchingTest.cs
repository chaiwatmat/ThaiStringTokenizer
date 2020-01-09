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

            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }

        [Fact]
        public void ShortWordTest2()
        {
            var input = "ตากลม";
            var expected = new List<string>
            {
                "ตา",
                "กลม"
            };

            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }

        [Fact]
        public void ShortWordTest3()
        {
            var input = "กวาง";
            var expected = new List<string>
            {
                "กวาง"
            };

            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }

        [Fact]
        public void ShortWordTest4()
        {
            var input = "บางครั้ง";
            var expected = new List<string>
            {
                "บาง",
                "ครั้ง"
            };

            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }

        [Fact]
        public void ShortWordTest5()
        {
            var input = "ยังอ่ะ";
            var expected = new List<string>
            {
                "ยัง",
                "อ่ะ"
            };

            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }
    }
}