namespace Battleships.Models.GameModels.Concrete
{
    public class Game
    {
        public Game()
        {
            PlayerA = new Player("Player A");
            PlayerB = new Player("Player B");
        }

        public Player PlayerA { get; }

        public Player PlayerB { get; }

        public bool IsFinished => PlayerA.HasLost || PlayerB.HasLost;

        public Player Winner
        {
            get
            {
                if (!IsFinished) return null;

                return PlayerA.HasLost ? PlayerB : PlayerA;
            }
        }

        public void PlayRound()
        {
            var coords = PlayerA.Fire();
            var result = PlayerB.ProcessFire(coords);
            PlayerA.ProcessFireResult(coords, result);

            if (PlayerB.HasLost) return;

            coords = PlayerB.Fire();
            result = PlayerA.ProcessFire(coords);
            PlayerB.ProcessFireResult(coords, result);
        }

        public void PlayGame()
        {
            while (!IsFinished) PlayRound();
        }
    }
}