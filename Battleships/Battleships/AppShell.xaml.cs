using Battleships.Views;
using Xamarin.Forms;

namespace Battleships
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BoardPage), typeof(BoardPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}