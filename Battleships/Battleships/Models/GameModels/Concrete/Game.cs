using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models.GameModels
{
    public class Game
    {
        public Player PlayerA { get; set; }

        public Player PlayerB { get; set; }

        public bool IsFinished
        {
            get
            {
                return PlayerA.HasLost || PlayerB.HasLost;
            }

        }

        public Player Winner
        {
            get
            {
                if (IsFinished)
                {
                    if (PlayerA.HasLost)
                    {
                        return PlayerB;
                    }
                    else
                    {
                        return PlayerA;
                    }
                }

                return null;
            }
        }

        public Game()
        {
            PlayerA = new Player("Player A");
            PlayerB = new Player("Player B");
        }

        public void PlayRound()
        {
            var coords = PlayerA.Fire();
            var result = PlayerB.ProcessFire(coords);
            PlayerA.ProcessFireResult(coords, result);

            if (!PlayerB.HasLost)
            {
                coords = PlayerB.Fire();
                result = PlayerA.ProcessFire(coords);
                PlayerB.ProcessFireResult(coords, result);
            }
        }

        public void PlayGame()
        {
            while (!IsFinished)
            {
                PlayRound();
            }
        }
    }
}
