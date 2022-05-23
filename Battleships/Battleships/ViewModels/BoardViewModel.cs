using Battleships.Extensions;
using Battleships.Models.BoardModels.Concrete;
using Battleships.Models.GameModels.Concrete;
using Battleships.ViewModels.Base;
using Battleships.Views;
using Xamarin.Forms;

namespace Battleships.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        public BoardViewModel()
        {
            Title = "Board";

            InitNewGame();
        }

        public Game Game { get; set; }

        public string WinnerName => Game.IsFinished ? Game.Winner.Name : "Nobody (?)";

        public void InitNewGame()
        {
            Game = new Game();
        }

        public void InitBoard(Board board, Grid grid)
        {
            foreach (var tile in board.Tiles)
                grid.Children.Add(
                    new Label
                    {
                        Style = (Style)Application.Current.Resources["Tile"],
                        Text = tile.Type.GetSymbol()
                    }, tile.Coordinates.Row, tile.Coordinates.Column);
        }

        public void GoBack()
        {
            Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        public void Simulate()
        {
            Game.PlayGame();
        }
    }
}