using Battleships.Models.GameModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battleships
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Settings.Init();

            MainPage = new AppShell();
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
