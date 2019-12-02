using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SubThaiStringAndCountTest
    {
        [Fact]
        public void TestSubThaiStringAndCount()
        {
            var input = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว แล้วเขาจะรู้ว่ารักหรือเปล่า";

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiStringAndCount(input);

            var expectedList = 1;
            var expectedCount = 45;

            Assert.Equal(expectedList, results.Count);
            Assert.Equal(expectedCount, results[0].Countable);
        }
    }
}