using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest5
    {
        [Fact]
        public void TestSubstring_ThaiWithEnglish()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ";
            var expected = new List<string>
            {
                "Hello สวัสดี ไทยคำ อังกฤษคำ"
            };

            var tokenizer = new ThaiTokenizer(removeSpace: false);

            var results = tokenizer.SubThaiString(input, input.Length);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSubstring_ThaiWithEnglishWithNumber()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ 1234";
            var expected = new List<string>
            {
                "Hello สวัสดี ไทยคำ อังกฤษคำ 1234"
            };

            var tokenizer = new ThaiTokenizer(removeSpace: false);

            var results = tokenizer.SubThaiString(input, input.Length);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSplit_ThaiWithEnglishWithNumber()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ 1234";
            var expected = new List<string>
            {
                "Hello",
                "สวัสดี",
                "ไทย",
                "คำ",
                "อังกฤษ",
                "คำ",
                "1234"
            };

            var tokenizer = new ThaiTokenizer();

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