using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SubThaiStringTest
    {
        [Fact]
        public void SubThaiStringTest1()
        {
            var input = "ค่าธรรมเนียม บริการฝากเงินข้ามเขต จากบัญชี 111-111111-1 จำนวนเงินฝาก 20,500.00 บาท";
            var expected = new List<string> { input };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 80);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}