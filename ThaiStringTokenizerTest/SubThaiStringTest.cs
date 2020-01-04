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

        [Fact]
        public void SubThaiStringTest2()
        {
            var input = "สบายมาก";
            var expected = GlobalExpectedResult.GetExpectedResult3();

            var tokenizer = new ThaiTokenizer();
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

            var tokenizer = new ThaiTokenizer();
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

            var tokenizer = new ThaiTokenizer();
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

        [Fact]
        public void TestSubThaiString_SupportSpace()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์"
            };

            Verify(tokenizer, input, expected, results);
        }

        [Fact]
        public void TestSubThaiString_ThaiWithEnglish()
        {
            var tokenizer = new ThaiTokenizer();
            var input = "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English";
            var results = tokenizer.SubThaiString(input, 50);

            var expected = new List<string>
            {
                "ทดสอบไทยคำ อังกฤษคำ Test Thai language with English"
            };

            Verify(tokenizer, input, expected, results);
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

            Verify(tokenizer, input, expected, results);
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

            Verify(tokenizer, input, expected, results);
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

            Verify(tokenizer, input, expected, results);
        }
    }
}