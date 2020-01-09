using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class AppendDicTest : TestBase
    {
        [Fact]
        public void Test2()
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
        public void Test3()
        {
            var appendDictionary = new List<string> { "หวัดดี", "หวักลี", "เชอแตม" };
            var tokenizer = new ThaiTokenizer(appendDictionary);
            var input = "หวักลีหวัดดีปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอดเชอแตม";
            var results = tokenizer.Split(input);

            var expected0 = new List<string> { "หวักลี", "หวัดดี" };
            var expected1 = GlobalExpectedResult.GetExpectedResult1();
            var expected2 = new List<string> { "เชอแตม" };

            var expected = expected0;
            expected.AddRange(expected1);
            expected.AddRange(expected2);

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void Test4()
        {
            var appendDictionary = new List<string> { "หวัดดี", "หวักลี", "เชอแตม" };
            var tokenizer = new ThaiTokenizer(appendDictionary);
            var input = "ฤารักฉันจะเป็นเพียงความฝัน";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "ฤา",
                "รัก",
                "ฉัน",
                "จะ",
                "เป็น",
                "เพียง",
                "ความฝัน",
            };

            Verify(tokenizer, input, expected, results);
        }
    }
}