using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Characters;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class ThaiNameTest
    {
        [Fact]
        public void SampleTest1()
        {
            var input = "โชติกานต์";
            var expected = new List<string> { "โชติกานต์" };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void SampleTest2()
        {
            var input = "กุญจ์สิริลัญฉกร พจชรดลญา ณ สงขลา";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ สงขลา" };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });

            Console.WriteLine("==============");
        }

        [Fact]
        public void SampleTest3()
        {
            var input = "กุญจ์สิริลัญฉกร พจชรดลญา ณ นคร";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ นคร" };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });

            Console.WriteLine("==============");
        }

        [Fact]
        public void SampleTest4()
        {
            var input = "กุญจ์สิริลัญฉกร พจชรดลญา ณ นครศรีธรรมราช";
            var expected = new List<string> { "กุญจ์", "สิริลัญ", "ฉกร", " ", "พจ", "ชร", "ดล", "ญา", " ", "ณ นคร", "ศรีธรรม", "ราช" };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.Split(input);

            var index = 0;
            results.ForEach(x =>
            {
                Console.WriteLine(x);
                Assert.Equal(expected[index], x);
                index++;
            });

            Console.WriteLine("==============");
        }
    }
}