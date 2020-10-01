using FormCover;
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
    public partial class PartTime : ContentPage

    {
        ConfigPage Cp = new ConfigPage();
        
        public PartTime()
        {
            InitializeComponent();
            
            //GetTempDados();
            SetTempDados();
            TempDados.PartNullOrNot = true;
        }

        private async void BtnMainPage_ClickedAsync(object sender, EventArgs e)
        {
            try {
                MaPage();
                GetTempDados();
               TempDados.PartNullOrNot = false;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error ", " " + ex.Message, " ");
            };





        }

        private async void MaPage()
        {
            await Navigation.PushAsync(new MainPage());

        }
        public void EmptyFields()
        {
            if (string.IsNullOrEmpty(Qt1Cvr1.Text))
                Qt1Cvr1.Text = "0";
            if (string.IsNullOrEmpty(Cover1.Text))
                Cover1.Text = "0";
            if (string.IsNullOrEmpty(Qt2Cvr1.Text))
                Qt2Cvr1.Text = "0";
            if (string.IsNullOrEmpty(Cover2.Text))
                Cover2.Text = "0";
            if (string.IsNullOrEmpty(Qt3Cvr1.Text))
                Qt3Cvr1.Text = "0";
            if (string.IsNullOrEmpty(Cover3.Text))
                Cover3.Text = "0";
            if (string.IsNullOrEmpty(Qt4Cvr1.Text))
                Qt4Cvr1.Text = "0";
            if (string.IsNullOrEmpty(Cover4.Text))
                Cover4.Text = "0";
            if (string.IsNullOrEmpty(O1kilo1_2.AutomationId))
                O1kilo1_2.SelectedItem = "K1";
            if (string.IsNullOrEmpty(O1PTimek1.Text))
                O1PTimek1.Text = "00:00";
            if (string.IsNullOrEmpty(O2kilo1_2.AutomationId))
                O2kilo1_2.SelectedItem = "K1";
            if (string.IsNullOrEmpty(O2PTimek1.Text))
                O2PTimek1.Text = "00:00";
            if (string.IsNullOrEmpty(O3kilo1_2.AutomationId))
                O3kilo1_2.SelectedItem = "K1";
            if (string.IsNullOrEmpty(O3PTimek1.Text))
                O3PTimek1.Text = "00:00";
            if (string.IsNullOrEmpty(O4kilo1_2.AutomationId))
                O4kilo1_2.SelectedItem = "K1";
            if (string.IsNullOrEmpty(O4PTimek1.Text))
                O4PTimek1.Text = "00:00";
        }
        public void ParTimek1k2()
        {
            //GetTempDados();
            //EmptyFields();
            HourToPercent hourToPercent = new HourToPercent();
            double h = hourToPercent.convertTime(TempDados.MainNormalTime);
            h += hourToPercent.convertTime(TempDados.MainOverTime);
            GetSetBonners getsetBonners = new GetSetBonners();
            string[,] partBonners = {  { TempDados.PartO1kilo1_2, TempDados.PartO2kilo1_2, TempDados.PartO3kilo1_2, TempDados.PartO4kilo1_2 }, { TempDados.PartO1PTimek1, TempDados.PartO2PTimek1, TempDados.PartO3PTimek1, TempDados.PartO4PTimek1 } };
            getsetBonners.CachPartK1k2(partBonners,h);
        
        }
        public void Coverk1k2()
        {
            //Cp.emptyField();
            //EmptyFields();
            GetSetBonners getsetBonners = new GetSetBonners();
            string[,] coverBonners = { {TempDados.PartQt1Cvr1, TempDados.PartQt2Cvr1, TempDados.PartQt3Cvr1, TempDados.PartQt4Cvr1}, 
            {TempDados.PartCover1, TempDados.PartCover2, TempDados.PartCover3, TempDados.PartCover4} };
            getsetBonners.CoverK1K2Time(coverBonners);
        
        }
        public void GetTempDados()
        {
            EmptyFields();
            if(TempDados.PartNullOrNot==true)
            { 
            TempDados.PartCover1 = Cover1.Text;
            TempDados.PartCover2 = Cover2.Text;
            TempDados.PartCover3 = Cover3.Text;
            TempDados.PartCover4 = Cover4.Text;
            TempDados.PartO1kilo1_2 =  O1kilo1_2.SelectedItem.ToString();//"K1";
            TempDados.PartO2kilo1_2 =  O2kilo1_2.SelectedItem.ToString();
            TempDados.PartO3kilo1_2 = O3kilo1_2.SelectedItem.ToString();
            TempDados.PartO4kilo1_2 = O4kilo1_2.SelectedItem.ToString();
            TempDados.PartO1PTimek1 = O1PTimek1.Text;
            TempDados.PartO2PTimek1 = O2PTimek1.Text;
            TempDados.PartO3PTimek1 = O3PTimek1.Text;
            TempDados.PartO4PTimek1 = O4PTimek1.Text;
            TempDados.PartQt1Cvr1 = Qt1Cvr1.Text;
            TempDados.PartQt2Cvr1 = Qt2Cvr1.Text;
            TempDados.PartQt3Cvr1 = Qt3Cvr1.Text;
            TempDados.PartQt4Cvr1 = Qt4Cvr1.Text;
            }

        }
        private void SetTempDados()
        {
            Cover1.Text = TempDados.PartCover1;
            Cover2.Text = TempDados.PartCover2;
            Cover3.Text = TempDados.PartCover3;
            Cover4.Text = TempDados.PartCover4;
            O1kilo1_2.SelectedItem = TempDados.PartO1kilo1_2;
            O2kilo1_2.SelectedItem = TempDados.PartO2kilo1_2;
            O3kilo1_2.SelectedItem = TempDados.PartO3kilo1_2;
            O4kilo1_2.SelectedItem = TempDados.PartO4kilo1_2;
            O1PTimek1.Text = TempDados.PartO1PTimek1;
            O2PTimek1.Text = TempDados.PartO2PTimek1;
            O3PTimek1.Text = TempDados.PartO3PTimek1;
            O4PTimek1.Text = TempDados.PartO4PTimek1;
            Qt1Cvr1.Text = TempDados.PartQt1Cvr1;
            Qt2Cvr1.Text = TempDados.PartQt2Cvr1;
            Qt3Cvr1.Text = TempDados.PartQt3Cvr1;
            Qt4Cvr1.Text = TempDados.PartQt4Cvr1;

        }
    }
}