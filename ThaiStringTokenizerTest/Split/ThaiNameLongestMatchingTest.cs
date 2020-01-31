using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ThaiNameLongestMatchingTest : TestBase
    {
        [Theory]
        [InlineData("กุญจ์สิริลัญฉกร", "กุญจ์", "สิริลัญ", "ฉกร")]
        [InlineData("โชติกานต์ ศรีสุวรรณ์", "โชติกานต์", " ", "ศรีสุวรรณ์")]
        [InlineData("กุญจ์สิริลัญฉกร พจชรดลญา ณ สงขลา", "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ สงขลา")]
        [InlineData("กุญจ์สิริลัญฉกร พจชรดลญา ณ นคร", "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ นคร")]
        public void SampleTest2(string input, params string[] expects)
        {
            var expected = expects.ToList();

            Verify(input, expected);
        }

        [Fact]
        public void SampleTest4()
        {
            var input = "กุญจ์สิริลัญฉกร พจชรดลญา ณ นครศรีธรรมราช";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ นคร", "ศรีธรรม", "ราช" };
            Verify(input, expected);
        }
    }
}