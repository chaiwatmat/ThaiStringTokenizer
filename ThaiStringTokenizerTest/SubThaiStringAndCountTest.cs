using System.Collections.Generic;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Models;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SubThaiStringAndCountTest
    {
        [Fact]
        public void TestSubThaiStringAndCount()
        {
            var input = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว แล้วเขาจะรู้ว่ารักหรือเปล่า";

            var tokenizer = new ThaiTokenizer(noSpace: false);
            var results = tokenizer.SubThaiStringAndCount(input);

            var expectedList = 1;
            var expectedCount = 45;
            var expectedUncount = 16;

            Assert.Equal(expectedList, results.Count);
            Assert.Equal(expectedCount, results[0].Countable);
            Assert.Equal(expectedUncount, results[0].Uncountable);
        }

        [Fact]
        public void TestSubThaiStringAndCount_WithLimitLength()
        {
            var input = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว แล้วเขาจะรู้ว่ารักหรือเปล่า";

            var tokenizer = new ThaiTokenizer(noSpace: false);
            var results = tokenizer.SubThaiStringAndCount(input, 24);

            var expectedResults = new List<ThaiStringResponse>
            {
                new ThaiStringResponse { Words = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว" },
                new ThaiStringResponse { Words = " แล้วเขาจะรู้ว่ารักหรือเปล่า" }
            };

            Assert.Equal(expectedResults.Count, results.Count);

            for (var i = 0; i < expectedResults.Count; i++)
            {
                var expectedWord = expectedResults[i].Words;
                var expecptedCount = expectedResults[i].Countable;

                var actualWord = results[i].Words;
                var actualCount = results[i].Countable;

                Assert.Equal(expectedWord, actualWord);
                Assert.Equal(expecptedCount, actualCount);
            }
        }

        [Fact]
        public void TestSubThaiStringAndCount_CheckLength()
        {
            var input = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว แล้วเขาจะรู้ว่ารักหรือเปล่า";

            var tokenizer = new ThaiTokenizer(noSpace: false);
            var results = tokenizer.SubThaiStringAndCount(input, 24);

            var expectedResults = new List<int> { 24, 21 };

            Assert.Equal(expectedResults.Count, results.Count);

            for (var i = 0; i < expectedResults.Count; i++)
            {
                var expecptedCount = expectedResults[i];

                var actualWord = results[i].Words;
                var actualCount = results[i].Countable;

                Assert.Equal(expecptedCount, actualCount);
            }
        }
    }
}