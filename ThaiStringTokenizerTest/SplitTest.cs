using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SplitTest : TestBase
    {
        [Fact]
        public void Test1()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var results = tokenizer.Split(input);
            var expected = GlobalExpectedResult.GetExpectedResult1();

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void Test2()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "อดีตอาจทำให้เราเจ็บปวด แต่เราเลือกได้ว่าจะวิ่งหนีมันไป หรือใช้มันเป็นบทเรียน";
            var results = tokenizer.Split(input);

            var expected = new List<string>
            {
                "อดีต",
                "อาจ",
                "ทำให้",
                "เรา",
                "เจ็บปวด",
                " ",
                "แต่",
                "เรา",
                "เลือก",
                "ได้",
                "ว่า",
                "จะ",
                "วิ่งหนี",
                "มัน",
                "ไป",
                " ",
                "หรือ",
                "ใช้",
                "มัน",
                "เป็น",
                "บทเรียน"
            };

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestToneMarkSubstring()
        {
            var input = "ผมอยากจะเป็นมหาเศรษฐี";
            var expected = new List<string>
            {
                "ผม",
                "อยาก",
                "จะ",
                "เป็น",
                "มหาเศรษฐี"
            };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.Split(input);

            Verify(tokenizer, input, expected, results);
        }

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