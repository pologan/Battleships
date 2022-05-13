using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models.GameModels
{
    public class Game
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Game()
        {
            Player1 = new Player("Player A");
            Player2 = new Player("Player B");
        }

        public void PlayRound()
        {
            var coords = Player1.Fire();
            var result = Player2.ProcessFire(coords);
            Player1.ProcessFireResult(coords, result);

            if(!Player2.HasLost)
            {
                coords = Player2.Fire();
                result = Player1.ProcessFire(coords);
                Player2.ProcessFireResult(coords, result);
            }
        }

        public void PlayGame()
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }
        }
    }
}
