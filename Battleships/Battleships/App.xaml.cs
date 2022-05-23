using Battleships.Models.GameModels.Concrete;
using Xamarin.Forms;

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