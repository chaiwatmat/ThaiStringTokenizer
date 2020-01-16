using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ThaiNameLongestMatchingTest : TestBase
    {
        [Fact]
        public void SampleTest0()
        {
            var input = "กุญจ์สิริลัญฉกร";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร" };
            Verify(input, expected);
        }

        [Fact]
        public void SampleTest1()
        {
            var input = "โชติกานต์ ศรีสุวรรณ์";
            var expected = new List<string> { "โชติกานต์", " ", "ศรีสุวรรณ์" };
            Verify(input, expected);
        }

        [Fact]
        public void SampleTest2()
        {
            var input = "กุญจ์สิริลัญฉกร พจชรดลญา ณ สงขลา";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ สงขลา" };
            Verify(input, expected);
        }

        [Fact]
        public void SampleTest3()
        {
            var input = "กุญจ์สิริลัญฉกร พจชรดลญา ณ นคร";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ นคร" };
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