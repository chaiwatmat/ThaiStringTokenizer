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
            var tokenizer = new ThaiTokenizer(matchingTechnique: MatchingTechnique.ShortestMatching);
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
            var tokenizer = new ThaiTokenizer(matchingTechnique: MatchingTechnique.ShortestMatching);
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
            var tokenizer = new ThaiTokenizer(matchingTechnique: MatchingTechnique.ShortestMatching);
            var input = "กวาง";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "กวาง"
            };

            Verify(tokenizer, input, expected);
        }

        [Fact]
        public void ShortWordTest4()
        {
            var tokenizer = new ThaiTokenizer(matchingTechnique: MatchingTechnique.ShortestMatching);
            var input = "บางครั้ง";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "บาง",
                "ครั้ง"
            };

            Verify(tokenizer, input, expected);
        }

        [Fact]
        public void ShortWordTest5()
        {
            var tokenizer = new ThaiTokenizer(matchingTechnique: MatchingTechnique.ShortestMatching);
            var input = "ยังอ่ะ";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "ยัง",
                "อ่ะ"
            };

            Verify(tokenizer, input, expected);
        }
    }
}