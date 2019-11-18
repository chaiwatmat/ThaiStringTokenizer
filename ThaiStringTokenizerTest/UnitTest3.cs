using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class UnitTest3
    {
        [Fact]
        public void TestSplit_RemoveSpace()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string text = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
            var result = tokenizer.Split(text);

            var expected = new List<string>
            {
                "อาราธนา",
                "พระพุทธ",
                "อาราธนา",
                "พระธรรม",
                "อาราธนา",
                "พระสงฆ์"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void TestSplit_SupportSpace()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer(removeSpace: false);
            string text = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
            var result = tokenizer.SubThaiString(text, 50);

            var expected = new List<string>
            {
                "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}