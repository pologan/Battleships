using Battleships.ViewModels.Base;
using Battleships.Views;
using Xamarin.Forms;

namespace Battleships.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            PlaceShipsCommand = new Command(PlaceShips);

            Title = "Welcome";
        }

        public Command PlaceShipsCommand { get; set; }

        private static async void PlaceShips()
        {
            await Shell.Current.GoToAsync($"//{nameof(BoardPage)}");
        }
    }
}