using Battleships.Extensions;
using Battleships.Models.BoardModels;
using Battleships.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Battleships.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        public Game Game { get; set; }

        public BoardViewModel()
        {
            Game = new Game();
        }

        public void OnAppearing()
        {
            Game.Player1 = new Player("Player A");
            Game.Player2 = new Player("Player B");
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
    }
}
