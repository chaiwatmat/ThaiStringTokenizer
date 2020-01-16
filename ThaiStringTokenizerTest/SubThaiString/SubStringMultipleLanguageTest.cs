using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SubStringMultipleLanguageTest : TestBase
    {
        [Fact]
        public void TestSubstring_ThaiWithEnglish()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ";
            var expected = new List<string>
            {
                "Hello สวัสดี ไทยคำ อังกฤษคำ"
            };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, input.Length);

            Verify(input, expected, results);
        }

        [Fact]
        public void TestSubstring_ThaiWithEnglishWithNumber()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ 1234";
            var expected = new List<string>
            {
                "Hello สวัสดี ไทยคำ อังกฤษคำ 1234"
            };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, input.Length);

            Verify(input, expected, results);
        }
    }
}