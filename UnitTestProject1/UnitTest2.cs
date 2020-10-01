using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            string hour = "800";
            {
                int count = 0;
                if (string.IsNullOrEmpty(hour))
                {
                    hour = "0000";
                }
                foreach (char c in hour)
                {
                    count++;
                }
                for (int i = 0; i < 4 - count; i++)
                {
                    hour = "0" + hour;
                }

                string hoursTxt = hour.Substring(0, 2);
                string MinutsTxt = hour.Substring(2, 2);
                int hours = Convert.ToInt32(hoursTxt);
                double minuts = (Convert.ToDouble(MinutsTxt) / 60);
                double hoursMinuts = hours + minuts;
                Assert.AreEqual(hoursMinuts, 8);
            }
        }
    }
}
