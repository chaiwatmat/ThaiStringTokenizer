using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SplitLongestMatchingTest : TestBase
    {
        [Fact]
        public void Test1()
        {
            var input = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var expected = GlobalExpectedResult.GetExpectedResult1();

            Verify(input, expected);
        }

        [Fact]
        public void Test2()
        {
            var input = "อดีตอาจทำให้เราเจ็บปวด แต่เราเลือกได้ว่าจะวิ่งหนีมันไป หรือใช้มันเป็นบทเรียน";
            var expected = new List<string>
            {
                "อดีต","อาจ","ทำให้","เรา","เจ็บปวด",
                " ",
                "แต่","เรา","เลือก","ได้","ว่า","จะ","วิ่งหนี","มัน","ไป",
                " ",
                "หรือ","ใช้","มัน","เป็น","บทเรียน"
            };

            Verify(input, expected);
        }

        [Fact]
        public void Test3()
        {
            var input = "บางครั้ง";
            var expected = new List<string>
            {
                "บางครั้ง"
            };

            Verify(input, expected);
        }

        [Fact]
        public void Test4()
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

            Verify(input, expected);
        }

        [Fact]
        public void Test5()
        {
            var input = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
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

            Verify(input, expected);
        }
    }
}