using Battleships.Extensions;
using Battleships.Models.BoardModels;
using Battleships.Models.GameModels;
using System;
using Xamarin.Forms;

namespace Battleships.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        public Game Game { get; set; }

        public string WinnerName
        {
            get
            {
                if (Game.Finished)
                {
                    return Game.Winner.Name;
                }
                return "Nobody (?)";
            }
        }

        public BoardViewModel()
        {
            Title = "Board";

            InitNewGame();
        }

        public void InitNewGame()
        {
            Game = new Game();
        }

        public void InitBoard(Board board, Grid grid)
        {
            foreach (var tile in board.Tiles)
            {
                grid.Children.Add(
                    new Label
                    {
                        Style = (Style)Application.Current.Resources["Tile"],
                        Text = tile.Type.GetSymbol()
                    }, tile.Coordinates.Row, tile.Coordinates.Column);
            }
        }

        public void Simulate()
        {
            Game.PlayGame();
        }
    }
}
