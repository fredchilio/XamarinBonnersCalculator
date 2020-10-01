using FormCover;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBonnersCalculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        AnswarePage ans = new AnswarePage();
        PartTime pt = new PartTime();
        ConfigPage Cp = new ConfigPage();
        //TimePicker tpNormal = new TimePicker 
        //{
           // Time = new TimeSpan(8, 00, 00)
       // };
       // TimePicker tpOver = new TimePicker();






        public MainPage()
        {
            InitializeComponent();
            setTempDados();
            




        }

        private  void ButtonPage1_ClickedAsync(object sender, EventArgs e)
        {

            PaPage();
            getTempDados();


        }

        private void ButtonConfig_ClickedAsync(object sender, EventArgs e)
        {
            CoPage();
            getTempDados();
        }

        private async void BtnEnter_Clicked(object sender, EventArgs e)
        {
            try {
                
                
                

                if (string.IsNullOrEmpty(KiloTotal.Text))
                    throw new Exception("Kilo Total is empty");
                if (string.IsNullOrEmpty(KiloTotal.Text))
                    throw new Exception("Kilo Total is empty");
                if (Convert.ToDouble(String.Join("", System.Text.RegularExpressions.Regex.Split(NormalTimeH.Text, @"[^\d]")))> 800)
                    NormalTimeH.Text="08:00";
                if (Convert.ToDouble(String.Join("", System.Text.RegularExpressions.Regex.Split(NormalTimeH.Text, @"[^\d]"))) <0)
                    NormalTimeH.Text = "00:00";
                if (Convert.ToDouble(String.Join("", System.Text.RegularExpressions.Regex.Split(OverTimeH.Text, @"[^\d]"))) < 0)
                    OverTimeH.Text = "00:00";
                if (Convert.ToDouble(String.Join("", System.Text.RegularExpressions.Regex.Split(OverTimeH.Text, @"[^\d]"))) > 10)
                    OverTimeH.Text = "01:00";
                //if (Convert.ToInt32(NormalTimeH.Text)>8 | (Convert.ToInt32(NormalTimeH.Text)<0))
                //NormalTimeH.Text = "8";
                if (string.IsNullOrEmpty(OverTimeH.Text))
                NormalTimeH.Text = "00:00";
                if (string.IsNullOrEmpty(NormalTimeH.Text))
                    NormalTimeH.Text = "00:00";
                //if (Convert.ToInt32(OverTimeH.Text) > 9 | (Convert.ToInt32(NormalTimeH.Text) < 0))
                //NormalTimeH.Text = "2";**/
                if (string.IsNullOrEmpty(QtBonnersFullK1.Text))
                    QtBonnersFullK1.Text = "0";
                if (string.IsNullOrEmpty(QtBonnersFullK2.Text))
                    QtBonnersFullK2.Text = "0";

                getTempDados();
                pt.GetTempDados();
                //pt.EmptyFields();
                pt.Coverk1k2();
                pt.ParTimek1k2();
                CoPage();
                ans.FieldsAnsware();

                //resolver problemas com respostas vazias
                
                AnPage();
               
                //cf.emptyField();
                

            }
           catch (Exception ex)
            {
                await DisplayAlert("Error ", " "+ ex.Message, " ");
            };
        }

        private async void AnPage()
        {
            
            await Navigation.PushAsync(new AnswarePage());
        }
        private async void CoPage()
        {
            await Navigation.PushAsync(new ConfigPage());
        }
        private async void PaPage()
        {
            await Navigation.PushAsync(new PartTime());
        }
        

        private void getTempDados()
        {
            TempDados.MainkiloTotal = KiloTotal.Text;
            TempDados.MainNormalTime = NormalTimeH.Text;
            TempDados.MainOverTime = OverTimeH.Text;
            TempDados.MainQtBonnersFullK1 = QtBonnersFullK1.Text;
            TempDados.MainQtBonnersFullK2 = QtBonnersFullK2.Text;
        }
        public void setTempDados()
        {
            
            KiloTotal.Text = TempDados.MainkiloTotal;
            NormalTimeH.Text = TempDados.MainNormalTime;
            OverTimeH.Text = TempDados.MainOverTime;
            QtBonnersFullK1.Text = TempDados.MainQtBonnersFullK1;
            QtBonnersFullK2.Text = TempDados.MainQtBonnersFullK2;

        }

        /**private void NormalTime_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(NormalTime.Time.TotalSeconds>tpNormal.Time.TotalSeconds)
            {
                NormalTime.Time = tpNormal.Time;
            }
        }**/

        //private async Task BtnConfig_ClickedAsync(object sender, EventArgs e)
        //{
        //     await Navigation.PushAsync(new ConfigPage());
        // }


    }
}
