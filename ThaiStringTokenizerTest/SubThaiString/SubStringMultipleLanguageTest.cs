using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SubStringMultipleLanguageTest : TestBase
    {
        [Theory]
        [InlineData("Hello สวัสดี ไทยคำ อังกฤษคำ")]
        [InlineData("Hello สวัสดี ไทยคำ อังกฤษคำ 1234")]
        public void TestSubstring_ThaiWithEnglishWithNumber(string input)
        {
            var expected = new List<string>
            {
                input
            };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, input.Length);

            Verify(input, expected, results);
        }
    }
}