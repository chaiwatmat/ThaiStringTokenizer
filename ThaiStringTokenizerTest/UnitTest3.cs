using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest3 : TestBase
    {
        [Fact]
        public void TestSplit_RemoveSpace()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "อาราธนา",
                "พระพุทธ",
                " ",
                "อาราธนา",
                "พระธรรม",
                " ",
                "อาราธนา",
                "พระสงฆ์"
            };

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestSplit_SupportSpace()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์"
            };

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestSplit_ThaiWithEnglish()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English";
            var results = tokenizer.Split(input);

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

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestSplitKeepSpace_ThaiWithEnglish()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English";
            var results = tokenizer.Split(input);

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

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestSubThaiString_ThaiWithEnglish()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English";
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English"
            };

            Verify(tokenizer, input, expected, results);
        }
    }
}