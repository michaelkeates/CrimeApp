using System;
using Xamarin.Forms;
using Sharpnado.MaterialFrame;
using Xamarin.Forms.Xaml;

namespace CrimeAlertApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Sharpnado.MaterialFrame.Initializer.Initialize(loggerEnable: false);

            MainPage = new MainPage();
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
