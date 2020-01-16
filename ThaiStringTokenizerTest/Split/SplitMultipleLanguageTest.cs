using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SplitMultipleLanguageTest : TestBase
    {
        [Fact]
        public void TestSplit_ThaiWithEnglishWithNumber()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ 1234";
            var expected = GlobalExpectedResult.GetExpectedResult2();

            Verify(input, expected);
        }

        [Fact]
        public void TestSplit_ThaiWithEnglishWithNumber2()
        {
            var input = "Hello สวัสดี ไทยคำ อังกฤษคำ 1234a Hello สวัสดี ไทยคำ อังกฤษคำ 1234";

            var expected0 = GlobalExpectedResult.GetExpectedResult2();
            var expected1 = new List<string> { "a", " " };

            var expected = expected0;
            expected.AddRange(expected1);
            expected.AddRange(expected0);

            Verify(input, expected);
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

            Verify(input, expected);
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

            Verify(input, expected);
        }

        [Fact]
        public void TestSplit_ThaiWithEnglish()
        {
            var input = "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English";
            var expected = new List<string>
            {
                "ทดสอบ",
                "ไทย",
                "คำ",
                " ",
                "อังกฤษ",
                "คำ",
                " ",
                "Test",
                " ",
                "Thai",
                " ",
                "language",
                " ",
                "with",
                " ",
                "English"
            };

            Verify(input, expected);
        }
    }
}