using FormCover;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBonnersCalculator
{
    
    class CalculateFinal
    {
        public static string KiloPercentLess { get; set; }
        public static string ValueOverTime { get; set; }
        public static string ValueNormalTime { get; set; }
        public static string ValueNormalOverTime { get; set; }

        public static string CoverValue { get; set; }
        public static string ValueTotalLessCover { get; set; }
        public static string Kilo1Value { get; set; }
        public static string Kilo2Value { get; set; }
        public static string PartTimeK1 { get; set; }
        public static string PartTimeK2 { get; set; }

        GetSetBonners getSetBonners = new GetSetBonners();
        HourToPercent hourP = new HourToPercent();
        ConfigPage Cp = new ConfigPage();

        private void PercentLess()
        {
            KiloPercentLess = (Convert.ToDouble(TempDados.MainkiloTotal) *
            (100 - Convert.ToDouble(TempDados.ConfigPercentLess)) / 100).ToString();
        }

        private void CalculateNormalOverTime()
        {
            double hourTeste = (hourP.convertTime(TempDados.MainNormalTime) + hourP.convertTime(TempDados.MainOverTime));
            double avarage = Convert.ToDouble(KiloPercentLess) /
            (hourP.convertTime(TempDados.MainNormalTime) + hourP.convertTime(TempDados.MainOverTime));
            ValueNormalTime = (Convert.ToDouble(TempDados.ConfigNormalTimeValue)*(avarage* hourP.convertTime(TempDados.MainNormalTime))).ToString();
            ValueOverTime = (Convert.ToDouble(TempDados.ConfigOverTimeValue)*(avarage* hourP.convertTime(TempDados.MainOverTime))).ToString();
            ValueNormalOverTime = (Convert.ToDouble(ValueNormalTime) + Convert.ToDouble(ValueOverTime)).ToString();
        }
        private void CalculateCover()
        {

            CoverValue = (Convert.ToDouble(TempDados.ConfigCoverTimeValue)*
            (getSetBonners.MyPropertyNormalCover + 
            getSetBonners.MyPropertyOverCover)).ToString();
        }
        private void CalculateTotalLessCover()
        {
            ValueTotalLessCover = (Convert.ToDouble(ValueNormalOverTime)
            - Convert.ToDouble(CoverValue)).ToString();
        }
        private void PercentK1K2()
        {
            
            double denominador = Convert.ToDouble(TempDados.MainQtBonnersFullK1)*100 + 
                Convert.ToDouble(TempDados.MainQtBonnersFullK2)*Convert.ToDouble(TempDados.ConfigPercentK2) + 
                (getSetBonners.MyPropertyPartK1)*100 + getSetBonners.MyPropertyPartK2* Convert.ToDouble(TempDados.ConfigPercentK2);
            double coeficienteKilo1 = 100 / denominador;
            double coeficienteKilo2 = Convert.ToDouble(TempDados.ConfigPercentK2) / denominador;
            double coeficientePartKilo1 = getSetBonners.MyPropertyPartK1 * 100 / denominador; //porcentagem das soma do tempo trabalhado
            double coeficientePartKilo2 = getSetBonners.MyPropertyPartK2 * Convert.ToDouble(TempDados.ConfigPercentK2) / denominador;//porcentagem das soma do tempo trabalhado
            Kilo1Value = (coeficienteKilo1 * Convert.ToDouble(ValueTotalLessCover)).ToString();
            Kilo2Value = (coeficienteKilo2 * Convert.ToDouble(ValueTotalLessCover)).ToString();
            PartTimeK1 = (coeficientePartKilo1 * Convert.ToDouble(ValueTotalLessCover)).ToString();
            PartTimeK2 = (coeficientePartKilo2 * Convert.ToDouble(ValueTotalLessCover)).ToString();
        }

        public void AnswarePage(/**string calcKiloTotal, 
            string calcTextPercentLess, string calcPercentLess,
            string calcNormalTime, string calcOverTime, string calcKilo1,
            string calcKilo2, string calcCover, string calcTotalValue, 
            string calcTotalLessCover, string calcParTimeK1, string calcParTimeK2**/)
        {
           
            PercentLess();
            CalculateNormalOverTime();
            CalculateCover();
            CalculateTotalLessCover();
            PercentK1K2();

            /**calcKiloTotal = TempDados.MainkiloTotal;
            calcTextPercentLess = TempDados.ConfigPercentLess;
            calcPercentLess = kiloPercentLess;
            calcNormalTime = valueNormalTime;
            calcOverTime = valueOverTime;
            calcTotalValue = (Convert.ToDouble(valueNormalTime) + Convert.ToDouble(valueOverTime)).ToString();
            calcTotalLessCover = Convert.ToDouble(ValueTotalLessCover).ToString();
            calcParTimeK1 = Convert.ToDouble(partTimeK1).ToString();
            calcParTimeK2 = Convert.ToDouble(partTimeK2).ToString();
            calcKilo1 = kilo1Value;
            calcKilo2 = kilo2Value;
            calcCover = coverValue;**/

        }
    }
}
