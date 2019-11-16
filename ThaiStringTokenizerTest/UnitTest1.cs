using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;

namespace ThaiStringTokenizerTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string test = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var result = tokenizer.Split(test);

            var expected = new List<string>
            {
                "ปลา",
                "ที่",
                "ใหญ่",
                "ที่สุด",
                "ใน",
                "โลก",
                "คือ",
                "ปารีส",
                "ชุบ",
                "แป้ง",
                "ทอด"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void Test2()
        {
            ThaiTokenizer tokenizer = new ThaiTokenizer();
            string test = "อดีตอาจทำให้เราเจ็บปวด แต่เราเลือกได้ว่าจะวิ่งหนีมันไป หรือใช้มันเป็นบทเรียน";
            var result = tokenizer.Split(test);

            var expected = new List<string>
            {
                "อดีต",
                "อาจ",
                "ทำให้",
                "เรา",
                "เจ็บปวด",
                "แต่",
                "เรา",
                "เลือก",
                "ได้",
                "ว่า",
                "จะ",
                "วิ่งหนี",
                "มัน",
                "ไป",
                "หรือ",
                "ใช้",
                "มัน",
                "เป็น",
                "บทเรียน"
            };

            Assert.Equal(expected.Count, result.Count);

            var index = 0;
            result.ForEach(x =>
            {
                Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}
