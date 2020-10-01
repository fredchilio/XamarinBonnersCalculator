using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBonnersCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnswarePage : ContentPage
    {
        //MainPage testet = new MainPage();
        readonly CalculateFinal calculateFinal = new CalculateFinal();
        public AnswarePage() //teste commit teste 2.0
        {
            InitializeComponent();
            ShowResults();

            //valores();
        }

        private async void MaPage()
        {
            await Navigation.PushAsync(new MainPage());
            new GetSetBonners().ZeroMethods();


        }

        /**public void valores()
        {
            string[] anPage = { "oioioioi" };
            Kteste.Text = anPage[0];
        }**/
        public void FieldsAnsware()
        {
            calculateFinal.AnswarePage(/**kiloTotal.Text, textPercentLess.Text,
                TotalPercentLess.Text, NormalTime.Text, OverTime.Text, Kilo1.Text, kilo2.Text,
                cover.Text, TotalValue.Text, TotalLessCover.Text, Kilo1Partial.Text, Kilo2Partial.Text**/);
        }
        private void ShowResults()
        {
            kiloTotal.Text = TempDados.MainkiloTotal;
            textPercentLess.Text = TempDados.ConfigPercentLess+"% less";
            TotalPercentLess.Text = CalculateFinal.KiloPercentLess;
            OverTime.Text = Convert.ToDouble(CalculateFinal.ValueOverTime).ToString("F");
            NormalTime.Text = Convert.ToDouble(CalculateFinal.ValueNormalTime).ToString("F");
            TotalValue.Text = Convert.ToDouble(CalculateFinal.ValueNormalOverTime).ToString("F");

            //cover.Text = Convert.ToDouble(CalculateFinal.coverValue).ToString("F");
            //TotalLessCover.Text = Convert.ToDouble(CalculateFinal.ValueTotalLessCover).ToString("F");
            Kilo1.Text = Convert.ToDouble(CalculateFinal.Kilo1Value).ToString("F");
            kilo2.Text = Convert.ToDouble(CalculateFinal.Kilo2Value).ToString("F");
            Kilo1Partial.Text = Convert.ToDouble(CalculateFinal.PartTimeK1).ToString("F");
            Kilo2Partial.Text = Convert.ToDouble(CalculateFinal.PartTimeK2).ToString("F");

            //=CalculateFinal.partTimeK1
            //=CalculateFinal.partTimeK2 
            //GetSetBonners.partK1;
            //GetSetBonners.partK2;
            //GetSetBonners.coverNormalTime;
            //5GetSetBonners.coverOverTime;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MaPage();
        }
    }
}