using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public abstract class TestBase
    {
        public virtual void Verify(string input, List<string> expected, bool shortWordFirst = false)
        {
            var tokenizer = new ThaiTokenizer(shortWordFirst: shortWordFirst);

            Verify(tokenizer, input, expected);
        }

        public virtual void Verify(ThaiTokenizer tokenizer, string input, List<string> expected)
        {
            var results = tokenizer.Split(input);

            Console.WriteLine("==============");
            Console.WriteLine("input = {0}", input);
            Console.WriteLine("expected = [{0}]", string.Join('|', expected));
            Console.WriteLine("result = [{0}]", string.Join('|', results));

            for (int i = 0; i < results.Count; i++)
            {
                Assert.Equal(expected[i], results[i]);
            }
        }

        public virtual void Verify(ThaiTokenizer tokenizer, string input, List<string> expected, List<string> results)
        {
            Console.WriteLine("==============");
            Console.WriteLine("input = {0}", input);
            Console.WriteLine("expected = [{0}]", string.Join('|', expected));
            Console.WriteLine("result = [{0}]", string.Join('|', results));

            for (int i = 0; i < results.Count; i++)
            {
                Assert.Equal(expected[i], results[i]);
            }
        }
    }
}