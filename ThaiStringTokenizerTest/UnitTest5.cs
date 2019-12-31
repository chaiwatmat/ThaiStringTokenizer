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

            var tokenizer = new ThaiTokenizer(noSpace: false);

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

            var tokenizer = new ThaiTokenizer(noSpace: false);

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
            var expected = GlobalExpectedResult.GetExpectedResult2();

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSplit_ThaiWithEnglishWithNumber2()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ 1234a Hello สวัสดี ไทยคำ อังกฤษคำ 1234";

            var expected0 = GlobalExpectedResult.GetExpectedResult2();
            var expected1 = new List<string> { "a" };

            var expected = expected0;
            expected.AddRange(expected1);
            expected.AddRange(expected0);

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSplit_ThaiWithNumber()
        {
            var input = "สวัสดี1234";
            var expected = new List<string>
            {
                "สวัสดี",
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

        [Fact]
        public void TestSplit_EnglishWithNumber()
        {
            var input = "Hello1234";
            var expected = new List<string>
            {
                "Hello",
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