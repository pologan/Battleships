using System.Collections.Generic;

namespace Battleships.Models.BoardModels
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }

        public const int WIDTH = 10;

        public const int HEIGHT = 10;

        public Board()
        {
            Tiles = new List<Tile>();
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }
    }
}
