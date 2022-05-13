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

        public BoardViewModel()
        {
            InitNewGame();
        }

        public void InitNewGame()
        {
            Game = new Game();
        }

        public void InitBoard(Board board, Grid grid)
        {

            for (int i = 0; i < Board.HEIGHT; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            }
            for (int j = 0; j < Board.WIDTH; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            foreach (var tile in board.Tiles)
            {
                grid.Children.Add(
                    new Label
                    {
                        Style = (Style)Application.Current.Resources["Tile"],
                        Text = tile.Type.GetSymbol()
                    }, tile.Coordinates.Column, tile.Coordinates.Row);
            }
        }

        public void Simulate()
        {
            Game.PlayGame();
        }
    }
}
