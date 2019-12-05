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

        [Fact]
        public void SubThaiStringTest2()
        {
            var input = "สบายมาก";
            var expected = GlobalExpectedResult.GetExpectedResult3();

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 4);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void SubThaiStringTest3()
        {
            var input = "สบายมาก";
            var expected = GlobalExpectedResult.GetExpectedResult3();

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 5);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void SubThaiStringTest4()
        {
            var input = "สบายมาก";
            var expected = GlobalExpectedResult.GetExpectedResult3();

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 6);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void SubThaiStringTest5()
        {
            var input = "สบายมาก";
            var expected = new List<string> {
                "สบายมาก"
            };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 7);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void SubThaiStringTest6()
        {
            var input = "ไก่จิกเด็กตายบนปากโอ่ง โอ่งมังกรราชบุรี";
            var expected = new List<string> {
                "ไก่จิกเด็กตายบนปาก",
                "โอ่ง โอ่งมังกรราชบุรี"
            };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 17);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Fact]
        public void SubThaiStringTest7()
        {
            var input = "ไก่จิกเด็กตายบนปากโอ่ง โอ่งมังกรราชบุรี";
            var expected = new List<string> {
                "ไก่จิกเด็กตายบนปากโอ่ง",
                " โอ่งมังกรราชบุรี"
            };

            var tokenizer = new ThaiTokenizer(removeSpace: false);
            var results = tokenizer.SubThaiString(input, 18);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }
    }
}