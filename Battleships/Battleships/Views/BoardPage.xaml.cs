using Battleships.Extensions;
using Battleships.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battleships.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoardPage : ContentPage
    {
        private readonly BoardViewModel _vm;
        public BoardPage()
        {
            InitializeComponent();

            _vm = new BoardViewModel();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            _vm.InitNewGame();

            RefreshBoards();
        }

        protected override bool OnBackButtonPressed()
        {
            _vm.GoBack();

            return true;
        }

        private void Randomize_Clicked(object sender, EventArgs e)
        {
            _vm.InitNewGame();

            RefreshBoards();
        }

        private void RefreshBoards()
        {
            gridA.Clear();
            gridB.Clear();

            _vm.InitBoard(_vm.Game.PlayerA.Board, gridA);
            _vm.InitBoard(_vm.Game.PlayerB.Board, gridB);
        }

        private async void Simulate_Clicked(object sender, EventArgs e)
        {
            if (!_vm.Game.IsFinished)
            {
                _vm.Simulate();

                RefreshBoards();

                if (await DisplayWinner(_vm.WinnerName))
                {
                    _vm.InitNewGame();

                    RefreshBoards();
                }
            }
            else
            {
                await DisplayAlert("Forbidden action", "Cannot simulate already finished game", "Ok");
            }
        }

        private async Task<bool> DisplayWinner(string winnerName)
        {
            return await DisplayAlert("Game finished", $"The winner is {winnerName}!", "Randomize again", "Close window");
        }

    }
}