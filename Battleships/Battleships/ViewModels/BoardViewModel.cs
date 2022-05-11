using Battleships.Models.BoardModels;
using Battleships.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
