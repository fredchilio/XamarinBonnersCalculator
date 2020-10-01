using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBonnersCalculator
{
    public partial class App : Application
    {
        MainPage mPage = new MainPage();
        AnswarePage aPage = new AnswarePage();
        ConfigPage cPge = new ConfigPage();
        PartTime pPage = new PartTime();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); //(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
