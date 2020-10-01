using FormCover;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms.Internals;


namespace XamarinBonnersCalculator
{
    class GetSetBonners
    {
        private readonly HourToPercent hourToPercent = new HourToPercent();
       
        static private double partK1;
        static private double partK2;
        static private double coverNormalTime;
        static private double coverOverTime;

        public double MyPropertyPartK1
        {
            get { return partK1; }
            set { partK1 = value; }
        }
        public double MyPropertyPartK2
        {
            get { return partK2; }
            set { partK2 = value; }
        }
        public double MyPropertyNormalCover
        {
            get { return coverNormalTime; }
            set { coverNormalTime = value; }
        }
        public double MyPropertyOverCover
        {
            get { return coverOverTime; }
            set { coverOverTime = value; }
        }
       
        public void CoverK1K2Time(string[,] cover)
        {
            double temp;
            for (int i = 0; i < 4; i++)
                {
                temp = hourToPercent.convertTime(cover[1,i]);
                if(temp<=8)
                {
                    MyPropertyNormalCover += Convert.ToDouble(cover[0, i])*temp;
                }
                if(temp>8)
                {
                    temp -= 8; 
                    MyPropertyOverCover += Convert.ToDouble(cover[0, i]) * temp;
                    MyPropertyNormalCover += Convert.ToDouble(cover[0, i]) * 8;

                }
            }
        }
        /**public void cachPartK1k2(string[,] k1k2, string hour)
        {
            for(int i=0; i<4; i++)
            {   
                if(k1k2[1,i].Equals("K1"))
                {
                    MyPropertyPartK1 += hourToPercent.convertTime(k1k2[0,i]) / hourToPercent.convertTime(hour); 
                }
                if (k1k2[1,i].Equals("K2"))
                {
                    MyPropertyPartK2 += hourToPercent.convertTime(k1k2[0,i]) / hourToPercent.convertTime(hour);
                }
            }
            
        }**/
        public void CachPartK1k2(string[,] k1k2, double hour)
        {
             
                for (int i = 0; i < 4; i++)
                {
                string temp = k1k2[0, i];
                if (temp.Equals("K1"))
                {
                        MyPropertyPartK1 += hourToPercent.convertTime(k1k2[1, i]) / (hour);
                }
                if (temp.Equals("K2"))
                {
                    MyPropertyPartK2 += hourToPercent.convertTime(k1k2[1, i]) / (hour);
                }
                }

               
            

        }
        public void ZeroMethods()
        {
            MyPropertyPartK1 = 0;
            MyPropertyPartK2 = 0;
            MyPropertyNormalCover = 0;
            MyPropertyOverCover = 0;

        }

    }
}
