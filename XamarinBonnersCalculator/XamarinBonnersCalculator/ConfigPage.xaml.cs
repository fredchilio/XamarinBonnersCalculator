using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;



namespace XamarinBonnersCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigPage : ContentPage
    {
        
        public ConfigPage()
        {
            InitializeComponent();//testando primeiro commit
            UserPreferencesGet();
            GetTempDados();
            EmptyField();



        }

        private async void BtnMainPage_ClickedAsync(object sender, EventArgs e)
        {
            try { 
            

             
            MaPage();
                GetTempDados();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error ", " " + ex.Message, " ");
            };

        }

        public async void MaPage()
        {
            
            await Navigation.PushAsync(new MainPage());
        }

        public void GetTempDados()
        {
            
            TempDados.ConfigCoverOverValue = CoverOverValue.Text;
            TempDados.ConfigCoverTimeValue = CoverTimeValue.Text;
            TempDados.ConfigNormalTimeValue= NormalTimeValue.Text;
            TempDados.ConfigOverTimeValue = OverTimeValue.Text;
            TempDados.ConfigPercentLess = PercentLess.Text;
            TempDados.ConfigPercentK2 = PercentK2.Text;
        }
        private void SetTempDados()
        {
            
            CoverOverValue.Text = TempDados.ConfigCoverOverValue;
            CoverTimeValue.Text = TempDados.ConfigCoverTimeValue;
            NormalTimeValue.Text = TempDados.ConfigNormalTimeValue;
            OverTimeValue.Text = TempDados.ConfigOverTimeValue;
            PercentLess.Text = TempDados.ConfigPercentLess;
            PercentK2.Text = TempDados.ConfigPercentK2;
        }
        public void EmptyField()
        {
            if (string.IsNullOrEmpty(NormalTimeValue.Text))
            {
                NormalTimeValue.Text = Preferences.Get("NormalTimeValue", "default_value");
                TempDados.ConfigNormalTimeValue = Preferences.Get("NormalTimeValue", "default_value");
            }
            if (string.IsNullOrEmpty(OverTimeValue.Text))
            {
                OverTimeValue.Text = Preferences.Get("OverTimeValue", "default_value");
                TempDados.ConfigOverTimeValue = Preferences.Get("OverTimeValue", "default_value");
            }
            if (string.IsNullOrEmpty(CoverTimeValue.Text))
            {
                CoverTimeValue.Text = Preferences.Get("CoverTimeValue", "default_value");
                TempDados.ConfigCoverTimeValue = Preferences.Get("CoverTimeValue", "default_value");
            }
            if (string.IsNullOrEmpty(CoverOverValue.Text))
            { 
                CoverOverValue.Text = Preferences.Get("CoverOverValue", "default_value");
                TempDados.ConfigCoverOverValue = Preferences.Get("CoverOverValue", "default_value");
            }
            if (string.IsNullOrEmpty(PercentK2.Text))
            { 
                PercentK2.Text = Preferences.Get("PercentK2", "default_value");
                TempDados.ConfigPercentK2 = Preferences.Get("PercentK2", "default_value");
            }
            if (string.IsNullOrEmpty(PercentLess.Text))
            {
                PercentLess.Text = Preferences.Get("PercentLess", "default_value");
                TempDados.ConfigPercentLess = Preferences.Get("PercentLess", "default_value");
            }
            SetTempDados();
        }
        private void UserPreferencesGet()
        {
            NormalTimeValue.Text = Preferences.Get("NormalTimeValue", "0.045");
            OverTimeValue.Text = Preferences.Get("OverTimeValue", "0.065");
            CoverTimeValue.Text = Preferences.Get("CoverTimeValue", "10");
            CoverOverValue.Text = Preferences.Get("CoverOverValue", "10");
            PercentK2.Text = Preferences.Get("PercentK2", "75");
            PercentLess.Text = Preferences.Get("PercentLess", "7");

        }

        private void BtnSavePreferences_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("NormalTimeValue", NormalTimeValue.Text);
            Preferences.Set("OverTimeValue", OverTimeValue.Text);
            Preferences.Set("CoverTimeValue", CoverTimeValue.Text);
            Preferences.Set("CoverOverValue", CoverOverValue.Text);
            Preferences.Set("PercentK2", PercentK2.Text);
            Preferences.Set("PercentLess", PercentLess.Text);
            
        }
    }
}