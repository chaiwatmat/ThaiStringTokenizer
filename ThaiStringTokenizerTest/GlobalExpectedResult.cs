using System.Collections.Generic;

namespace ThaiStringTokenizerTest
{
    public static class GlobalExpectedResult
    {
        public static List<string> GetExpectedResult1()
        {
            return new List<string>
            {
                "ปลา",
                "ที่",
                "ใหญ่",
                "ที่สุด",
                "ใน",
                "โลก",
                "คือ",
                "ปารีส",
                "ชุบ",
                "แป้ง",
                "ทอด"
            };
        }

        public static List<string> GetExpectedResult2()
        {
            return new List<string>
            {
                "Hello",
                "สวัสดี",
                "ไทย",
                "คำ",
                "อังกฤษ",
                "คำ",
                "1234"
            };
        }

        public static List<string> GetExpectedResult3()
        {
            return new List<string>
            {
                "สบาย",
                "มาก"
            };
        }
    }
}