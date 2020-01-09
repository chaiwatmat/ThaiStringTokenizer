using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ThaiNameShortestMatchingTest : TestBase
    {
        [Fact]
        public void SampleTest0()
        {
            var input = "ศิริวิมล";
            var expected = new List<string> { "ศิ", "ริ", "วิ", "มล" };
            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }

        [Fact]
        public void SampleTest1()
        {
            var input = "นางสาว ศิริวิมล ยิ่งเจริญ";
            var expected = new List<string> { "นาง", "สาว", " ", "ศิ", "ริ", "วิ", "มล", " ", "ยิ่ง", "เจ", "ริญ" };
            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }

        [Fact]
        public void SampleTest2()
        {
            var input = "เจริญยิ่ง การช่าง";
            var expected = new List<string> { "เจ", "ริญ", "ยิ่ง", " ", "การ", "ช่าง" };
            Verify(input, expected, MatchingTechnique.ShortestMatching);
        }
    }
}