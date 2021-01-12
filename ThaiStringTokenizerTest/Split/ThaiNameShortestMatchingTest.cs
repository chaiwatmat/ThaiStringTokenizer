using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ThaiNameShortestMatchingTest : TestBase
    {
        [Theory]
        [InlineData("ศิริวิมล", "ศิ", "ริ", "วิ", "มล")]
        [InlineData("นางสาว ศิริวิมล ยิ่งเจริญ", "นาง", "สาว", " ", "ศิ", "ริ", "วิ", "มล", " ", "ยิ่ง", "เจ", "ริญ")]
        [InlineData("เจริญยิ่ง การช่าง", "เจ", "ริญ", "ยิ่ง", " ", "การ", "ช่าง")]
        [InlineData("เจริญยนต์ การช่าง", "เจ", "ริญ", "ยนต์", " ", "การ", "ช่าง")]
        public void SampleTest0(string input, params string[] expects)
        {
            var expected = expects.ToList();

            Verify(input, expected, MatchingMode.Shortest);
        }

        [Theory]
        [InlineData("มายูรี", "มา", "ยู", "รี")]
        [InlineData("จันทร์จิราการ", "จัน", "ทร์", "จิ", "รา", "การ")]
        [InlineData("มารี", "มา", "รี")]
        [InlineData("เบิร์นเนอร์", "เบิร์น", "เน", "อร์")]
        [InlineData("น่อลา", "น่", "อลา")]
        public void HardToReadNameTest0(string input, params string[] expects)
        {
            var expected = expects.ToList();

            Verify(input, expected, MatchingMode.Shortest);
        }
    }
}