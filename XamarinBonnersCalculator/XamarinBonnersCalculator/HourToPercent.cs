using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormCover
{
    class HourToPercent
    {

        public double convertTime(string hour) 
        { int count = 0;
            if(string.IsNullOrEmpty(hour))
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

            hour = String.Join("", System.Text.RegularExpressions.Regex.Split(hour, @"[^\d]"));

            string hoursTxt = hour.Substring(0,2);
            string MinutsTxt = hour.Substring(2, 2);
            int hours = Convert.ToInt32(hoursTxt);
            double minuts = (Convert.ToDouble(MinutsTxt)/60);
            double hoursMinuts = (hours + minuts);
            return hoursMinuts;
        }


    }
}
