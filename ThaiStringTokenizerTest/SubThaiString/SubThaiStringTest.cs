using System.Collections.Generic;
using ThaiStringTokenizer;
using Xunit;

namespace ThaiStringTokenizerTest
{
    public class SubThaiStringTest : TestBase
    {
        [Fact]
        public void SubThaiStringTest1()
        {
            var input = "ค่าธรรมเนียม บริการฝากเงินข้ามเขต จากบัญชี 111-111111-1 จำนวนเงินฝาก 20,500.00 บาท";
            var expected = new List<string> { input };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, 80);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void SubThaiStringTest2(int length)
        {
            var input = "สบายมาก";
            var expected = GlobalExpectedResult.GetExpectedResult3();

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, length);

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
            var expected = new List<string>
            {
                "สบายมาก"
            };

            var tokenizer = new ThaiTokenizer();
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
            var expected = new List<string>
            {
                "ไก่จิกเด็กตายบนปาก",
                "โอ่ง โอ่งมังกรราชบุรี"
            };

            var tokenizer = new ThaiTokenizer();
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
            var expected = new List<string>
            {
                "ไก่จิกเด็กตายบนปากโอ่ง",
                " โอ่งมังกรราชบุรี"
            };

            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, 18);

            var index = 0;
            results.ForEach(x =>
            {
                Assert.Equal(expected[index], x);
                index++;
            });
        }

        [Theory]
        [InlineData("อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์")]
        [InlineData("ทดสอบไทยคำ อังกฤษคำ Test Thai language with English")]
        public void TestSubThaiString_SupportSpaceAndEnglish(string input)
        {
            var tokenizer = new ThaiTokenizer();
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                input
            };

            Verify(input, expected, results);
        }

        [Fact]
        public void TestSubThaiString1()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var results = tokenizer.SubThaiString(input, 10);

            var expected = new List<string>
            {
                "ปลาที่ใหญ่ที่สุด",
                "ในโลกคือ",
                "ปารีสชุบแป้ง",
                "ทอด"
            };

            Verify(input, expected, results);
        }

        [Fact]
        public void TestSubThaiString2()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
            var results = tokenizer.SubThaiString(input, 20);

            var expected = new List<string>
            {
                "ปลาที่ใหญ่ที่สุดในโลกคือ",
                "ปารีสชุบแป้งทอด"
            };

            Verify(input, expected, results);
        }

        [Fact]
        public void TestSubThaiString_RemoveSpace()
        {
            var appendDics = new List<string> { "พุทธัง", "ธัมมัง", "สังฆัง", "อาราธนานัง" };
            var tokenizer = new ThaiTokenizer(appendDics);
            var input = "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง";
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                "พุทธังอาราธนานัง ธัมมังอาราธนานัง สังฆังอาราธนานัง"
            };

            Verify(input, expected, results);
        }
    }
}