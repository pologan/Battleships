using Battleships.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Battleships.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command PlaceShipsCommand { get; set; }

        public HomeViewModel()
        {
            PlaceShipsCommand = new Command(() => PlaceShips());

            Title = "Welcome";
        }

        private async void PlaceShips()
        {
            await Shell.Current.GoToAsync($"//{nameof(BoardPage)}");
        }
    }
}
